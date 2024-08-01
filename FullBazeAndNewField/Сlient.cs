using System;
using System.Collections.Generic;

namespace FullBazeAndNewField
{
    public class Сlient
    {
        public string LastName { get;  set; }

        public string Name { get;  set; }

        public string MiddleName { get;  set; }

        public double PhoneNumber { get;  set; }

        public double PassportSeriesAndNumber { get;  set; }

        public Сlient(string lastName, string name, string middleName, double phoneNumber, double passportSeriesAndNumber = 0)
        {
            LastName = lastName;
            Name = name;
            MiddleName = middleName;
            PhoneNumber = phoneNumber;
            PassportSeriesAndNumber = passportSeriesAndNumber;
        }
    }
}