using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using static FullBazeAndNewField.ChangeControl;

namespace FullBazeAndNewField
{
    internal class SerializeDataBaze
    {
        public bool DataCreated { get; private set; } = false;
        private string _path;
        private ObservableCollection<Сlient> _сlients;
        private string _lastName;
        private string _name;
        private string _middleName;
        private double _phoneNumber;
        private double _passportSeriesAndNumber;

        public SerializeDataBaze(string path = "Test.xml")
        {
            _path = path;
            _сlients = new ObservableCollection<Сlient>();
            MainWindow.Serilaze += SaveDate;
            DataCreated = File.Exists(_path);
            if (DataCreated)
                Deserialize();
        }

        public ObservableCollection<Сlient> DeserializeComplite()
        {
            return _сlients;
        }

        private void Deserialize()
        {
            using (FileStream stream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                string xmlFile = File.ReadAllText(_path);
                var deserializedClientBaze = XDocument.Parse(xmlFile)
                    .Descendants("СlientBaze")
                    .Descendants("Сlient").ToList();
                foreach (var СlientXml in deserializedClientBaze)
                {
                    ChangeControl changeControl = new ChangeControl(5);

                    XElement FullName = СlientXml.Element("FullName");
                    XElement InfoСlient = СlientXml.Element("InfoСlient");
                    XElement InfoСlientChangers = СlientXml.Element("InfoСlientChangers");

                    _lastName = FullName.Attribute("LastName").Value;
                    _name = FullName.Attribute("Name").Value;
                    _middleName = FullName.Attribute("MiddleName").Value;
                    _phoneNumber = double.Parse(InfoСlient.Attribute("PhoneNumber").Value);
                    _passportSeriesAndNumber = double.Parse(InfoСlient.Attribute("PassportSeriesAndNumber").Value);

                    XElement ChangersLastName = InfoСlientChangers.Element("ChangersLastName");
                    var LastNametimesChengers = ChangersLastName.Attribute("timesChengers").Value;
                    var LastNameaddOrChange = ChangersLastName.Attribute("addOrChange").Value;
                    var LastNamewhoChanged = ChangersLastName.Attribute("whoChanged").Value;
                    GatherСomponentsInfoСlientChangers(ref changeControl, WhatField.LastName, LastNametimesChengers, LastNameaddOrChange, LastNamewhoChanged);

                    XElement ChangersName = InfoСlientChangers.Element("ChangersName");
                    var NametimesChengers = ChangersName.Attribute("timesChengers").Value;
                    var NameaddOrChange = ChangersName.Attribute("addOrChange").Value;
                    var NamewhoChanged = ChangersName.Attribute("whoChanged").Value;
                    GatherСomponentsInfoСlientChangers(ref changeControl, WhatField.Name, NametimesChengers, NameaddOrChange, NamewhoChanged);

                    XElement ChangersMiddleName = InfoСlientChangers.Element("ChangersMiddleName");
                    var MiddleNametimesChengers = ChangersMiddleName.Attribute("timesChengers").Value;
                    var MiddleNameaddOrChange = ChangersMiddleName.Attribute("addOrChange").Value;
                    var MiddleNamewhoChanged = ChangersMiddleName.Attribute("whoChanged").Value;
                    GatherСomponentsInfoСlientChangers(ref changeControl, WhatField.MiddleName, MiddleNametimesChengers, MiddleNameaddOrChange, MiddleNamewhoChanged);

                    XElement ChangersPhoneNumber = InfoСlientChangers.Element("ChangersPhoneNumber");
                    var PhoneNumbertimesChengers = ChangersPhoneNumber.Attribute("timesChengers").Value;
                    var PhoneNumberaddOrChange = ChangersPhoneNumber.Attribute("addOrChange").Value;
                    var PhoneNumberwhoChanged = ChangersPhoneNumber.Attribute("whoChanged").Value;
                    GatherСomponentsInfoСlientChangers(ref changeControl, WhatField.PhoneNumber, PhoneNumbertimesChengers, PhoneNumberaddOrChange, PhoneNumberwhoChanged);

                    XElement ChangersPassportSeriesAndNumber = InfoСlientChangers.Element("ChangersPassportSeriesAndNumber");
                    var ChangersPassportSeriesAndNumbertimesChengers = ChangersPassportSeriesAndNumber.Attribute("timesChengers").Value;
                    var ChangersPassportSeriesAndNumberaddOrChange = ChangersPassportSeriesAndNumber.Attribute("addOrChange").Value;
                    var ChangersPassportSeriesAndNumberwhoChanged = ChangersPassportSeriesAndNumber.Attribute("whoChanged").Value;
                    GatherСomponentsInfoСlientChangers(ref changeControl, WhatField.PassportSeriesAndNumber, ChangersPassportSeriesAndNumbertimesChengers, ChangersPassportSeriesAndNumberaddOrChange, ChangersPassportSeriesAndNumberwhoChanged);

                    Сlient сlient = new Сlient(_lastName, _name, _middleName, _phoneNumber, _passportSeriesAndNumber);

                    сlient.changeControl = changeControl;
                    _сlients.Add(сlient);
                }
            }
        }

        public void GatherСomponentsInfoСlientChangers(ref ChangeControl changeControl, ChangeControl.WhatField field, string timesChengers, string addOrChange, string whoChanged)
        {
            changeControl.InfoChanges[FiendTargetOnDictionary.timesChengers][(int)field] = timesChengers;
            changeControl.InfoChanges[FiendTargetOnDictionary.addOrChange][(int)field] = addOrChange;
            changeControl.InfoChanges[FiendTargetOnDictionary.whoChanged][(int)field] = whoChanged;
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

                XElement InfoСlientChangersElement = new XElement("InfoСlientChangers",
                     new XElement("ChangersLastName",
                             new XAttribute("timesChengers", client.changeControl.InfoChanges[FiendTargetOnDictionary.timesChengers][(int)WhatField.LastName]),
                             new XAttribute("addOrChange", client.changeControl.InfoChanges[FiendTargetOnDictionary.addOrChange][(int)WhatField.LastName]),
                             new XAttribute("whoChanged", client.changeControl.InfoChanges[FiendTargetOnDictionary.whoChanged][(int)WhatField.LastName])),
                      new XElement("ChangersName",
                              new XAttribute("timesChengers", client.changeControl.InfoChanges[FiendTargetOnDictionary.timesChengers][(int)WhatField.Name]),
                             new XAttribute("addOrChange", client.changeControl.InfoChanges[FiendTargetOnDictionary.addOrChange][(int)WhatField.Name]),
                             new XAttribute("whoChanged", client.changeControl.InfoChanges[FiendTargetOnDictionary.whoChanged][(int)WhatField.Name])),
                      new XElement("ChangersMiddleName",
                             new XAttribute("timesChengers", client.changeControl.InfoChanges[FiendTargetOnDictionary.timesChengers][(int)WhatField.MiddleName]),
                             new XAttribute("addOrChange", client.changeControl.InfoChanges[FiendTargetOnDictionary.addOrChange][(int)WhatField.MiddleName]),
                             new XAttribute("whoChanged", client.changeControl.InfoChanges[FiendTargetOnDictionary.whoChanged][(int)WhatField.MiddleName])),
                       new XElement("ChangersPhoneNumber",
                             new XAttribute("timesChengers", client.changeControl.InfoChanges[FiendTargetOnDictionary.timesChengers][(int)WhatField.PhoneNumber]),
                             new XAttribute("addOrChange", client.changeControl.InfoChanges[FiendTargetOnDictionary.addOrChange][(int)WhatField.PhoneNumber]),
                             new XAttribute("whoChanged", client.changeControl.InfoChanges[FiendTargetOnDictionary.whoChanged][(int)WhatField.PhoneNumber])),
                      new XElement("ChangersPassportSeriesAndNumber",
                              new XAttribute("timesChengers", client.changeControl.InfoChanges[FiendTargetOnDictionary.timesChengers][(int)WhatField.PassportSeriesAndNumber]),
                             new XAttribute("addOrChange", client.changeControl.InfoChanges[FiendTargetOnDictionary.addOrChange][(int)WhatField.PassportSeriesAndNumber]),
                             new XAttribute("whoChanged", client.changeControl.InfoChanges[FiendTargetOnDictionary.whoChanged][(int)WhatField.PassportSeriesAndNumber]))
                     );
                FullNameElement.Add(LastNameAttsribute, NameAttsribute, MiddleNameAttsribute);
                InfoСlientElement.Add(PhoneNumberAttsribute, PassportSeriesAndNumberAttsribute);
                СlientElement.Add(FullNameElement, InfoСlientElement, InfoСlientChangersElement);
                СlientBazeElement.Add(СlientElement);
            }
            СlientBazeElement.Save(_path);
        }

        private void SaveDate(ObservableCollection<Сlient> сlients)
        {
            _сlients = new ObservableCollection<Сlient>(сlients);
            Serialize();
        }
    }
}
