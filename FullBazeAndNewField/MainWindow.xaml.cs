using System;
using System.Collections.Generic;
using System.Windows;

namespace FullBazeAndNewField
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConsultantPage _consultantPage;
        private ManagerPage _managerPage;
        private DataBaze _dataBaze;
        private List<Сlient> _сlients;
        private SerializeDataBaze _serializeDataBaze;
        public static event Action<List<Сlient>> Serilaze;
        public static event Action<Сlient> ShowClient;

        public MainWindow()
        {
            InitializeComponent();
            _serializeDataBaze = new SerializeDataBaze();

            _dataBaze = _serializeDataBaze.DataCreated ? new DataBaze(_serializeDataBaze.DeserializeComplite()) : new DataBaze();

            _сlients = new List<Сlient>();
            _consultantPage = new ConsultantPage();
            _managerPage = new ManagerPage();
            CompleateListСlient();
            ChooseClient.ItemsSource = _сlients;
            ChooseUser.ItemsSource = new string[]
            {
               "Consultant",
                "Manager",
            };
            ChooseClient.SelectedIndex = 0;
            ChooseUser.SelectedIndex = 1;
            _managerPage.CheckNewClient.Click += HideClient;
            _managerPage.SaveСlient += Save;
            _consultantPage.SaveСlient += Save;
        }

        private void ChooseUser_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ChangePage();
        }

        private void ChangePage()
        {
            switch (ChooseUser.SelectedValue.ToString())
            {
                case "Consultant":
                    FrameList.Content = _consultantPage;
                    break;
                case "Manager":
                    FrameList.Content = _managerPage;
                    break;
                default:
                    break;
            }
        }

        private void CompleateListСlient()
        {
            int count = 0;
            int lenght = 0;
            do
            {
                _сlients.Add(_dataBaze.GetListСlient(count, ref lenght));
                count++;
            } while (count < lenght);
        }

        private void Save(Сlient сlient)
        {
            int index = 0;
            if ((bool)_managerPage.CheckNewClient.IsChecked)
            {
                _сlients.Add(сlient);
                index = _сlients.Count-1;
            }
            else
            {
             index = ChooseClient.SelectedIndex;
            _сlients[index] = сlient;
            }
            ChooseClient.ItemsSource = null;
            ChooseClient.ItemsSource = _сlients;
            ChooseClient.SelectedIndex = index;
            Serilaze?.Invoke(_сlients);
        }
        private void HideClient(object sender, RoutedEventArgs e)
        {
            ChooseClient.Visibility= (bool)_managerPage.CheckNewClient.IsChecked? Visibility.Collapsed : Visibility.Visible;
        }

        private void ChooseClient_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var tempClient = ChooseClient.SelectedValue;
            if (tempClient != null && tempClient is Сlient _сlient)
                ShowClient?.Invoke(_сlient);
        }
    }
}
