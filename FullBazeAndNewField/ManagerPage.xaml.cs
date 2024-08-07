using System;
using System.Windows;
using System.Windows.Controls;

namespace FullBazeAndNewField
{
    public partial class ManagerPage : Page
    {
        public event Action<Сlient> SaveСlient;
        private Сlient _сlient;
        private Manager _manager;

        public ManagerPage()
        {
            InitializeComponent();
            _manager = new Manager();
        }

        private void ShowInfoChangers()
        {
            ChooseOutputField(ChangeControl.WhatField.Name);
            ChooseOutputField(ChangeControl.WhatField.LastName);
            ChooseOutputField(ChangeControl.WhatField.MiddleName);
            ChooseOutputField(ChangeControl.WhatField.PhoneNumber);
            ChooseOutputField(ChangeControl.WhatField.PassportSeriesAndNumber);
        }

        private void ChooseOutputField(ChangeControl.WhatField field)
        {
            switch (field)
            {
                case ChangeControl.WhatField.LastName:
                    GroupingOfFields(LastNameInfo, field);
                    break;
                case ChangeControl.WhatField.Name:
                    GroupingOfFields(NameFieldInfo, field);
                    break;
                case ChangeControl.WhatField.MiddleName:
                    GroupingOfFields(MiddleNameInfo, field);
                    break;
                case ChangeControl.WhatField.PhoneNumber:
                    GroupingOfFields(PhoneNumberInfo, field);
                    break;
                case ChangeControl.WhatField.PassportSeriesAndNumber:
                    GroupingOfFields(PassportSeriesAndNumberInfo, field);
                    break;
                default:
                    break;
            }
        }

        private void GroupingOfFields(TextBlock textBlock, ChangeControl.WhatField field) //TextBox textB2lock, TextBox textB1lock, ChangeControl.WhatField field)
        {
            textBlock.Visibility = Visibility.Hidden;
            bool isShowOutputDisplay = ShowOutputDisplay(_manager.ClientInfo.Show(ChangeControl.FiendTargetOnDictionary.addOrChange, field));
            if (isShowOutputDisplay)
            {
                textBlock.Text = "";
                string addOrChange = _manager.ClientInfo.Show(ChangeControl.FiendTargetOnDictionary.addOrChange, field);
                string timesChengers = _manager.ClientInfo.Show(ChangeControl.FiendTargetOnDictionary.timesChengers, field);
                string whoChanged = _manager.ClientInfo.Show(ChangeControl.FiendTargetOnDictionary.whoChanged, field);
                textBlock.Visibility = Visibility.Visible;
                textBlock.Text += $"{addOrChange} from {timesChengers} by {whoChanged} ";
            }
        }

        private bool ShowOutputDisplay(string checkString)
        {
            return checkString != " ";
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if ((bool)CheckNewClient.IsChecked)
                _manager.CreateNewClient(LastName.Text, NameField.Text, MiddleName.Text, PhoneNumber.Text, PassportSeriesAndNumber.Text);
            else
                _manager.ChangeDate(LastName.Text, NameField.Text, MiddleName.Text, PhoneNumber.Text, PassportSeriesAndNumber.Text);

            _сlient = _manager.SaveСlient();
            SaveСlient?.Invoke(_сlient);
            ShowInfo();
        }

        public void ManageWork(Сlient сlient)
        {
            _manager.NewClient(сlient);
            ShowInfo();
        }

        private void ShowInfo()
        {
            _manager.ShowInfo(out string lastName, out string name, out string middleName, out string phoneNumber, out string passportSeriesAndNumber);

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

        private void ClearShowInfoChangers()
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

        private void ClearShowInfo()
        {
            LastName.Text = "";
            NameField.Text = "";
            MiddleName.Text = "";
            PhoneNumber.Text = "";
            PassportSeriesAndNumber.Text = "";
            ClearShowInfoChangers();
        }

        private void CheckNewClient_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)CheckNewClient.IsChecked)
                ClearShowInfo();
            else
                ShowInfo();
        }
    }
}
