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

        protected string _displayPhoneNumber;

        protected double _phoneNumber;

        protected string _displayPassportSeriesAndNumber;

        protected double _valuePassportSeriesAndNumber;

        public ClientInfo ClientInfo;

        public override string ToString()
        {
            return "Consultant";
        }

        public void NewClient(Сlient сlients)
        {
            ClientInfo = new ClientInfo(сlients.changeControl);
            _lastName = сlients.LastName;
            _name = сlients.Name;
            _middleName = сlients.MiddleName;
            _phoneNumber = сlients.PhoneNumber;
            _valuePassportSeriesAndNumber = сlients.PassportSeriesAndNumber;
            CheckDisplayPassport(сlients.PassportSeriesAndNumber);
            CheckDisplayPhoneNumber(сlients.PhoneNumber);
        }

        protected virtual void CheckDisplayPassport(double passportSeriesAndNumber)
        {
            if (passportSeriesAndNumber < 1)
                _displayPassportSeriesAndNumber = "Данных нет";
            else
                _displayPassportSeriesAndNumber = new string('*', passportSeriesAndNumber.ToString().Length);
        }

        protected virtual void CheckDisplayPhoneNumber(double phoneNumber)
        {
            if (phoneNumber < 1)
                _displayPhoneNumber = "Данных нет";
            else
                _displayPhoneNumber = phoneNumber.ToString();
        }

        public void ShowInfo(out string lastName, out string name, out string middleName, out string phoneNumber, out string passportSeriesAndNumber)
        {
            lastName = this._lastName;
            name = _name;
            middleName = _middleName;
            phoneNumber = _displayPhoneNumber;
            passportSeriesAndNumber = _displayPassportSeriesAndNumber;
        }

        public Сlient SaveСlient()
        {
            Сlient сlient = new Сlient(_lastName, _name, _middleName, _phoneNumber, _valuePassportSeriesAndNumber);
            сlient.changeControl = ClientInfo.ChangeControl;
            return сlient;
        }

        public void ChangeDate(string tryPhoneNumber)
        {
            NewPhoneNumber(CheckInput(tryPhoneNumber, _phoneNumber));
        }

        private void NewPhoneNumber(double newPhone)
        {
            if (_phoneNumber != newPhone)
            {
                if (_phoneNumber == 0)
                {
                    ClientInfo.SetLastChange(ChangeControl.WhatField.PhoneNumber, ChangeControl.WhatHasChanged.Add, ChangeControl.User.Consultant);
                }
                else
                {
                    ClientInfo.SetLastChange(ChangeControl.WhatField.PhoneNumber, ChangeControl.WhatHasChanged.Change, ChangeControl.User.Consultant);
                }
                _phoneNumber = newPhone;
                CheckDisplayPhoneNumber(_phoneNumber);
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
