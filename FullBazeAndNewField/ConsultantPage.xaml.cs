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
            MainWindow.ShowClient += ConsultantWork;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            _consultant.ChangeDate(PhoneNumber.Text);
            _сlient = _consultant.SaveСlient();
            SaveСlient?.Invoke(_сlient);
            ShowInfo();
        }


        private void JOol()
        {
            //SSS(ChangeControl.WhatField.Name);
            //SSS(ChangeControl.WhatField.LastName);
            //SSS(ChangeControl.WhatField.MiddleName);
            SSS(ChangeControl.WhatField.PhoneNumber);
            //SSS(ChangeControl.WhatField.PassportSeriesAndNumber);
        }

        private void SSS(ChangeControl.WhatField field)
        {
            switch (field)
            {
                //case ChangeControl.WhatField.LastName:
                //    OIU(PhoneNumberInfo, field);
                //    break;
                //case ChangeControl.WhatField.Name:
                //    OIU(LastName, NameField, MiddleName, field);
                //    break;
                //case ChangeControl.WhatField.MiddleName:
                //    OIU(LastName, NameField, MiddleName, field);
                //    break;
                case ChangeControl.WhatField.PhoneNumber:
                    OIU(PhoneNumberInfo,field);
                    break;
                //case ChangeControl.WhatField.PassportSeriesAndNumber:
                //    OIU(LastName, NameField, MiddleName, field);
                //    break;
                default:
                    break;
            }
        }

        private void OIU(TextBlock textBlock, ChangeControl.WhatField field) //TextBox textB2lock, TextBox textB1lock, ChangeControl.WhatField field)
        {
            textBlock.Text = "";
            HHHJ(_consultant.clientInfo.Show(ChangeControl.FiendTargetOnDictionary.addOrChange, field), textBlock);
            HHHJ(_consultant.clientInfo.Show(ChangeControl.FiendTargetOnDictionary.timesChengers, field), textBlock);
            HHHJ(_consultant.clientInfo.Show(ChangeControl.FiendTargetOnDictionary.whoChanged, field), textBlock);
        }

        private void HHHJ(string aaa, TextBlock textBlock)
        {
            textBlock.Visibility = Visibility.Hidden;
            if (aaa != null)
            {
                textBlock.Visibility = Visibility.Visible;
                textBlock.Text += aaa;
            }
        }

        private void ConsultantWork(Сlient сlient)
        {
            _consultant.NewClient(сlient);
            ShowInfo();
        }

        private void ShowInfo()
        {
            _consultant.ShowInfo(out string lastName, out string name, out string middleName, out double phoneNumber, out string passportSeriesAndNumber);

            LastName.Text = lastName;
            NameField.Text = name;
            MiddleName.Text = middleName;
            PhoneNumber.Text = phoneNumber.ToString();
            PassportSeriesAndNumber.Text = passportSeriesAndNumber;
            JOol();
        }

        private void RefrushButton(object sender, RoutedEventArgs e)
        {
            ShowInfo();
        }
    }
}
