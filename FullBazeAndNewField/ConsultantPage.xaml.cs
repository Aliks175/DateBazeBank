using System;
using System.Windows;
using System.Windows.Controls;

namespace FullBazeAndNewField
{
    public partial class ConsultantPage : Page
    {
        public event Action<Сlient> SaveСlient;
        private Consultant _consultant;
        private Сlient _сlient;

        public ConsultantPage()
        {
            InitializeComponent();
            _consultant = new Consultant();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            _consultant.ChangeDate(PhoneNumber.Text);
            _сlient = _consultant.SaveСlient();
            SaveСlient?.Invoke(_сlient);
            ShowInfo();
        }


        private void ShowInfoChangers()
        {
            VisibilityText();
            int indexTargetOnDictionary = 0;
            foreach (var InfoChanger in _consultant.ClientInfo.ChangeControl.InfoChanges)
            {
                for (int i = 0; i < InfoChanger.Value.Length; i++)
                {
                    if (InfoChanger.Value[i] != " ")
                        ChooseOutputField(i, indexTargetOnDictionary, InfoChanger.Value[i]);
                }
                indexTargetOnDictionary++;
            }
        }

        private void VisibilityText()
        {
            LastNameInfo.Visibility = Visibility.Hidden;
            LastNameInfo.Text = string.Empty;
            NameFieldInfo.Visibility = Visibility.Hidden;
            NameFieldInfo.Text = string.Empty;
            MiddleNameInfo.Visibility = Visibility.Hidden;
            MiddleNameInfo.Text = string.Empty;
            PhoneNumberInfo.Visibility = Visibility.Hidden;
            PhoneNumberInfo.Text = string.Empty;
            PassportSeriesAndNumberInfo.Visibility = Visibility.Hidden;
            PassportSeriesAndNumberInfo.Text = string.Empty;
        }

        private void ChooseOutputField(int indexFieldClient, int indexTargetOnDictionary, string Value)
        {
            switch (indexFieldClient)
            {
                case 0:
                    GroupingOfFields(LastNameInfo, indexTargetOnDictionary, Value);
                    break;
                case 1:
                    GroupingOfFields(NameFieldInfo, indexTargetOnDictionary, Value);
                    break;
                case 2:
                    GroupingOfFields(MiddleNameInfo, indexTargetOnDictionary, Value);
                    break;
                case 3:
                    GroupingOfFields(PhoneNumberInfo, indexTargetOnDictionary, Value);
                    break;
                case 4:
                    GroupingOfFields(PassportSeriesAndNumberInfo, indexTargetOnDictionary, Value);
                    break;
                default:
                    break;
            }
        }

        private void GroupingOfFields(TextBlock textBlock, int indexTargetOnDictionary, string Value)
        {
            if (indexTargetOnDictionary == 0)
            {
                textBlock.Visibility = Visibility.Visible;
                textBlock.Text += Value;
            }
            else if (indexTargetOnDictionary == 1)
            {
                textBlock.Text += $" from {Value}";
            }
            else if (indexTargetOnDictionary == 2)
            {
                textBlock.Text += $" by {Value}";
            }
        }

        public void ConsultantWork(Сlient сlient)
        {
            _consultant.NewClient(сlient);
            ShowInfo();
        }

        private void ShowInfo()
        {
            _consultant.ShowInfo(out string lastName, out string name, out string middleName, out string phoneNumber, out string passportSeriesAndNumber);

            LastName.Text = lastName;
            NameField.Text = name;
            MiddleName.Text = middleName;
            PhoneNumber.Text = phoneNumber;
            PassportSeriesAndNumber.Text = passportSeriesAndNumber;
            ShowInfoChangers();
        }

        private void RefrushButton(object sender, RoutedEventArgs e)
        {
            ShowInfo();
        }
    }
}
