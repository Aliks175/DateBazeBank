using System;
using System.Windows;
using System.Windows.Controls;

namespace DateBazeBank
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       private Сlient _cient;
        public MainWindow()
        {
            InitializeComponent();
            ChooseUser.ItemsSource = new Сlient[]
                { new Сlient("Федотов", "Николай", "Архипович", 89161648230),
                new Сlient("Удотов", "Уколай", "Ухипович", 89153575230,"12556124744221"),
        };
            ChooseUser.SelectedIndex = 1;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChooseUser.SelectedItem is Сlient cient)
                _cient = cient;
                ShowInfo(_cient);
        }

        private void ShowInfo(Сlient client)
        {
            LastName.Text = client.LastName;
            Name.Text = client.Name;
            MiddleName.Text = client.MiddleName;
            PhoneNumber.Text = client.PhoneNumber.ToString();
            PassportSeriesAndNumber.Text = client.TryGetPassport();
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(PhoneNumber.Text, out double number))
            {
                if (_cient.TrySetNewNumber(number))
                {
                    _cient.SetNewNumber();
                }
            }
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            ShowInfo(_cient);
        }
    }
}
