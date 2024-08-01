namespace FullBazeAndNewField
{
    public class Consultant
    {
        private double _newNumber;
        private bool _isCompleated;
        private int _lengthNumber = 11;

        public string LastName { get; private set; }

        public string Name { get; private set; }

        public string MiddleName { get; private set; }

        public double PhoneNumber { get; private set; }

        public string PassportSeriesAndNumber { get; protected set; }

        public override string ToString()
        {
            return "Consultant";
        }

        public void NewClient(Сlient сlients)
        {
            LastName = сlients.LastName;
            Name = сlients.Name;
            MiddleName = сlients.MiddleName;
            PhoneNumber = сlients.PhoneNumber;
            CheckCompleatePassport(сlients.PassportSeriesAndNumber);
        }

        protected virtual void CheckCompleatePassport(double passportSeriesAndNumber)
        {
            if (passportSeriesAndNumber < 1)
                PassportSeriesAndNumber = "Данных нет";
            else
                PassportSeriesAndNumber = new string('*', passportSeriesAndNumber.ToString().Length);
        }

        public string PrintLastName()
        {
            return LastName;
        }

        public string ShowName()
        {
            return Name;
        }

        public string ShowMiddleName()
        {
            return MiddleName;
        }

        public double ShowPhoneNumber()
        {
            return PhoneNumber;
        }

        public void TrySetPhoneNumber(string newNumber)
        {

            if (double.TryParse(newNumber, out double number))
            {
                if (TrySetNewNumber(number))
                    SetNewNumber();
            }
        }

        public virtual string ShowPassportSeriesAndNumber()
        {
            return PassportSeriesAndNumber;
        }

        private bool TrySetNewNumber(double newNumber)
        {
            _isCompleated = _lengthNumber == newNumber.ToString().Length;
            if (_isCompleated)
                _newNumber = newNumber;
            return _isCompleated;
        }

        private void SetNewNumber()
        {
            if (_isCompleated)
                PhoneNumber = _newNumber;
        }
    }
}
