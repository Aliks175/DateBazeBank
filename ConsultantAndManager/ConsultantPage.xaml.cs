using System;
using System.Windows;
using System.Windows.Controls;

namespace ConsultantAndManager
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
            CheckInput(out double newPhoneNumber);
            _сlient = new Сlient(LastName.Text, Name.Text, MiddleName.Text, newPhoneNumber, _сlient.PassportSeriesAndNumber);
            SaveСlient?.Invoke(_сlient);
            ConsultantWork(_сlient);
        }

        private void CheckInput(out double newPhoneNumber)
        {
            newPhoneNumber = _consultant.PhoneNumber;
            if (double.TryParse(PhoneNumber.Text, out double phoneNumber))
            {
                newPhoneNumber = phoneNumber;
            }
        }

        private void ConsultantWork(Сlient сlient)
        {
            _consultant.NewClient(сlient);
            _сlient = сlient;
            ShowInfo();
        }

        private void ShowInfo()
        {
            LastName.Text = _consultant.LastName;
            Name.Text = _consultant.Name;
            MiddleName.Text = _consultant.MiddleName;
            PhoneNumber.Text = _consultant.PhoneNumber.ToString();
            PassportSeriesAndNumber.Text = _consultant.PassportSeriesAndNumber;
        }

        private void RefrushButton(object sender, RoutedEventArgs e)
        {
            ShowInfo();
        }
    }
}
