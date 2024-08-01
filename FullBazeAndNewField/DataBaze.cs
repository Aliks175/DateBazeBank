using System;
using System.Collections.Generic;

namespace FullBazeAndNewField
{
    internal class DataBaze
    {
        private List<Сlient> _сlients;
        private string _lastName;
        private string _name;
        private string _middleName;
        private double _phoneNumber;
        private double _passportSeriesAndNumber;
        private Random _random;

        public DataBaze(int count = 11)
        {
            _lastName = "Иванов";
            _name = "Иван";
            _middleName = "Иванович";
            _phoneNumber = 0;
            _passportSeriesAndNumber = 0;
            _random = new Random();
            _сlients = new List<Сlient>();
            for (int i = 1; i < count; i++)
            {
                _сlients.Add(CompleateСlientDate(i));
            }
        }

        public DataBaze(List<Сlient> сlients)
        {
            _сlients = сlients;
        }

        private Сlient CompleateСlientDate(int number)
        {
            _phoneNumber = _random.Next(10000000, 999999999);
            if (RundomPassportIsCompleted())
                _passportSeriesAndNumber = _random.Next(100000000, 999999999);
            return new Сlient(_lastName + number, _name + number, _middleName + number, _phoneNumber, _passportSeriesAndNumber);
        }

        public Сlient GetListСlient(int count, ref int lenghtList)
        {
            lenghtList = _сlients.Count;
            return _сlients[count];
        }

        private bool RundomPassportIsCompleted()
        {
            return _random.Next(0, 6) > 3;
        }
    }
}
