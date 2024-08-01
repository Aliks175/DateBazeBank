using System;
using System.Windows;
using System.Windows.Controls;

namespace ConsultantAndManager
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
            MainWindow.ShowClient += ManageWork;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            CheckInput(out double newPhoneNumber, out double newPassportSeriesAndNumber);
            _сlient = new Сlient(LastName.Text, Name.Text, MiddleName.Text, newPhoneNumber, newPassportSeriesAndNumber);
            SaveСlient?.Invoke(_сlient);
            ManageWork(_сlient);
        }

        private void CheckInput(out double newPhoneNumber, out double newPassportSeriesAndNumber)
        {
            newPhoneNumber = _сlient.PhoneNumber;
            newPassportSeriesAndNumber = _сlient.PassportSeriesAndNumber;
            if (double.TryParse(PhoneNumber.Text, out double phoneNumber))
                newPhoneNumber = phoneNumber;
            if (double.TryParse(PassportSeriesAndNumber.Text, out double passportSeriesAndNumber))
                newPassportSeriesAndNumber = passportSeriesAndNumber;
        }

        private void ManageWork(Сlient сlient)
        {
            _manager.NewClient(сlient);
            _сlient = сlient;
            ShowInfo();
        }

        private void ShowInfo()
        {
            LastName.Text = _manager.LastName;
            Name.Text = _manager.Name;
            MiddleName.Text = _manager.MiddleName;
            PhoneNumber.Text = _manager.PhoneNumber.ToString();
            PassportSeriesAndNumber.Text = _manager.PassportSeriesAndNumber;
        }

        private void RefrushButton(object sender, RoutedEventArgs e)
        {
            ShowInfo();
        }
    }
}
