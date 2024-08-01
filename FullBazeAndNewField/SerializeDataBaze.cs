using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace FullBazeAndNewField
{
    internal class SerializeDataBaze
    {
        public bool DataCreated { get; private set; } = false;
        private string _path;
        private List<Сlient> _сlients;
        private string LastName;

        private string Name;

        private string MiddleName;

        private double PhoneNumber;
        private double PassportSeriesAndNumber;


        public SerializeDataBaze(string path = "Test.xml")
        {
            _path = path;
            _сlients = new List<Сlient>();
            MainWindow.Serilaze += Ser;
            DataCreated = File.Exists(_path);
            if (DataCreated)
                Deserialize();
        }

        public List<Сlient> DeserializeComplite()
        {
            return _сlients;
        }

        private void SaveDate(List<Сlient> сlients)
        {
            _сlients = new List<Сlient>(сlients);
        }

        private void Deserialize()
        {
            using (FileStream stream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                string xmlFile = File.ReadAllText(_path);
                var asdss = XDocument.Parse(xmlFile)
                    .Descendants("СlientBaze")
                    .Descendants("Сlient").ToList();

                foreach (var item in asdss)
                {

                    LastName = item.Element("FullName").Attribute("LastName").Value;
                    Name = item.Element("FullName").Attribute("Name").Value;
                    MiddleName = item.Element("FullName").Attribute("MiddleName").Value;
                    PhoneNumber = double.Parse(item.Element("InfoСlient").Attribute("PhoneNumber").Value);
                    PassportSeriesAndNumber = double.Parse(item.Element("InfoСlient").Attribute("PassportSeriesAndNumber").Value);
                    _сlients.Add(new Сlient(LastName, Name, MiddleName, PhoneNumber, PassportSeriesAndNumber));
                }
            }
        }

        private void Serialize()
        {
            XElement СlientBazeElement = new XElement("СlientBaze");
            foreach (var client in _сlients)
            {
                XAttribute LastNameAttsribute = new XAttribute("LastName", client.LastName);
                XAttribute NameAttsribute = new XAttribute("Name", client.Name);
                XAttribute MiddleNameAttsribute = new XAttribute("MiddleName", client.MiddleName);
                XAttribute PhoneNumberAttsribute = new XAttribute("PhoneNumber", client.PhoneNumber);
                XAttribute PassportSeriesAndNumberAttsribute = new XAttribute("PassportSeriesAndNumber", client.PassportSeriesAndNumber);

                XElement СlientElement = new XElement("Сlient");
                XElement FullNameElement = new XElement("FullName");
                XElement InfoСlientElement = new XElement("InfoСlient");

                FullNameElement.Add(LastNameAttsribute, NameAttsribute, MiddleNameAttsribute);
                InfoСlientElement.Add(PhoneNumberAttsribute, PassportSeriesAndNumberAttsribute);
                СlientElement.Add(FullNameElement, InfoСlientElement);
                СlientBazeElement.Add(СlientElement);
            }
            СlientBazeElement.Save(_path);
        }

        private void Ser(List<Сlient> сlients)
        {
            SaveDate(сlients);
            Serialize();
        }
    }
}
