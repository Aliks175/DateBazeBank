namespace FullBazeAndNewField
{
    public interface IWorkeble
    {
        void ChangeDate(string phoneNumber);
        Сlient SaveСlient();
    }

    public class Consultant : IWorkeble
    {
        protected string _lastName;

        protected string _name;

        protected string _middleName;

        protected double _phoneNumber;

        protected string _displayPassportSeriesAndNumber;

        protected double _valuePassportSeriesAndNumber;

        public ClientInfo clientInfo;

        public Consultant()
        {
            clientInfo = new ClientInfo();
        }

        public override string ToString()
        {
            return "Consultant";
        }

        public void NewClient(Сlient сlients)
        {
            _lastName = сlients.LastName;
            _name = сlients.Name;
            _middleName = сlients.MiddleName;
            _phoneNumber = сlients.PhoneNumber;
            _valuePassportSeriesAndNumber = сlients.PassportSeriesAndNumber;
            CheckDisplayPassport(сlients.PassportSeriesAndNumber);

        }

        protected virtual void CheckDisplayPassport(double passportSeriesAndNumber)
        {
            if (passportSeriesAndNumber < 1)
                _displayPassportSeriesAndNumber = "Данных нет";
            else
                _displayPassportSeriesAndNumber = new string('*', passportSeriesAndNumber.ToString().Length);
        }

        public void ShowInfo(out string lastName, out string name, out string middleName, out double phoneNumber, out string passportSeriesAndNumber)
        {
            lastName = this._lastName;
            name = _name;
            middleName = _middleName;
            phoneNumber = _phoneNumber;
            passportSeriesAndNumber = _displayPassportSeriesAndNumber;
        }

        public Сlient SaveСlient()
        {
            Сlient сlient = new Сlient(_lastName, _name, _middleName, _phoneNumber, _valuePassportSeriesAndNumber);
            сlient.changeControl = clientInfo.changeControl;
            return сlient;
        }

        public void ChangeDate(string tryPhoneNumber)
        {
            NewPhoneNumber(CheckInput(tryPhoneNumber, _phoneNumber));
        }

        protected void NewPhoneNumber(double newPhone)
        {
            if (_phoneNumber != newPhone)
            {
                if (_phoneNumber == 0)
                {
                    clientInfo.LastChange(ChangeControl.WhatField.PhoneNumber, ChangeControl.WhatHasChanged.Add, ChangeControl.User.Consultant);
                }
                else
                {
                    clientInfo.LastChange(ChangeControl.WhatField.PhoneNumber, ChangeControl.WhatHasChanged.Change, ChangeControl.User.Consultant);
                }
                _phoneNumber = newPhone;
            }
        }

        protected double CheckInput(string phoneNumber, double oldNumber)
        {
            double newPhone = oldNumber;
            if (double.TryParse(phoneNumber, out double newPhoneNumber))
            {
                newPhone = newPhoneNumber;
            }
            return newPhone;
        }
    }
}
