namespace DateBazeBank
{
    public class Сlient
    {
        private int _lengthNumber = 11;
        private double _newNumber;
        private bool _isCompleated = false;
        private bool _isHaveAccess = false;
        private string _passportSeriesAndNumber;

        public string LastName { get; private set; }

        public string Name { get; private set; }

        public string MiddleName { get; private set; }

        public double PhoneNumber { get; private set; }

        public Сlient(string lastName, string name, string middleName, double phoneNumber, string passportSeriesAndNumber = null)
        {
            LastName = lastName;
            Name = name;
            MiddleName = middleName;
            PhoneNumber = phoneNumber;
            _passportSeriesAndNumber = passportSeriesAndNumber;
        }

        public bool TrySetNewNumber(double newNumber)
        {
            _isCompleated = _lengthNumber == newNumber.ToString().Length;
            if (_isCompleated)
            {
                _newNumber = newNumber;
            }
            return _isCompleated;
        }

        public void SetNewNumber()
        {
            if (_isCompleated)
            {
                PhoneNumber = _newNumber;
            }
        }

        public string TryGetPassport()
        {
            if (_passportSeriesAndNumber == null)
            {
                return "Нет данных";
            }
            else
            {
                return _isHaveAccess ? _passportSeriesAndNumber : new string('*', _passportSeriesAndNumber.Length);
            }
        }
    }
}
