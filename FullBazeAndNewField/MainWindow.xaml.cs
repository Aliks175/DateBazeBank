using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace FullBazeAndNewField
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _oldСlientindex = -1;
        private ConsultantPage _consultantPage;
        private ManagerPage _managerPage;
        private DataBaze _dataBaze;
        private Сlient _selectedClient;
        private ObservableCollection<Сlient> _сlients;
        private SerializeDataBaze _serializeDataBaze;
        public static event Action<ObservableCollection<Сlient>> Serilaze;

        public MainWindow()
        {
            InitializeComponent();
            _serializeDataBaze = new SerializeDataBaze();
            _сlients = new ObservableCollection<Сlient>();
            _consultantPage = new ConsultantPage();
            _managerPage = new ManagerPage();
            _dataBaze = _serializeDataBaze.DataCreated ? new DataBaze(_serializeDataBaze.DeserializeComplite()) : new DataBaze();
            CompleateListСlient();
            ChooseUser.ItemsSource = new string[]
            {
               "Consultant",
                "Manager",
            };
            ChooseClient.ItemsSource = _сlients;
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
                    _consultantPage.ConsultantWork(_selectedClient);
                    break;
                case "Manager":
                    FrameList.Content = _managerPage;
                    _managerPage.ManageWork(_selectedClient);
                    break;
                default:
                    break;
            }
        }

        private void CompleateListСlient()
        {
            bool iswork = true;
            for (int i = 0; iswork; i++)
            {
                iswork = _dataBaze.TryGetСlient(i);
                if (iswork)
                {
                    _сlients.Add(_dataBaze.GetСlient());
                }
            }
        }

        private void Save(Сlient сlient)
        {
            int index = 0;
            if ((bool)_managerPage.CheckNewClient.IsChecked)
            {
                _сlients.Add(сlient);
                index = _сlients.Count - 1;
            }
            else
            {
                index = ChooseClient.SelectedIndex;
                _сlients[index] = сlient;
            }
            ChooseClient.SelectedIndex = index;
            _selectedClient = сlient;
            Serilaze?.Invoke(_сlients);
        }

        private void HideClient(object sender, RoutedEventArgs e)
        {
            ChooseClient.Visibility = (bool)_managerPage.CheckNewClient.IsChecked ? Visibility.Hidden : Visibility.Visible;
        }

        private void ChooseClient_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            bool isOldСlient = ChooseClient.SelectedIndex != _oldСlientindex && ChooseClient.SelectedIndex >= 0;
            if (isOldСlient)
            {
                _oldСlientindex = ChooseClient.SelectedIndex;
                var tempClient = ChooseClient.SelectedValue;
                if (tempClient != null && tempClient is Сlient _сlient)
                    _selectedClient = _сlient;
                if (ChooseUser.SelectedIndex > -1)
                {
                    var selectedUser = ChooseUser.SelectedValue.ToString();
                    if (selectedUser == "Consultant")
                        _consultantPage.ConsultantWork(_selectedClient);
                    else if (selectedUser == "Manager")
                        _managerPage.ManageWork(_selectedClient);
                }
            }
        }
    }
}

