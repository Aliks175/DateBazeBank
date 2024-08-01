using System;
using System.Collections.Generic;

namespace FullBazeAndNewField
{
    public class Сlient
    {
        public string LastName { get; private set; }

        public string Name { get; private set; }

        public string MiddleName { get; private set; }

        public double PhoneNumber { get; private set; }

        public double PassportSeriesAndNumber { get; private set; }

        public ChangeControl changeControl;

        public Сlient(string lastName, string name, string middleName, double phoneNumber, double passportSeriesAndNumber = 0)
        {
            changeControl = new ChangeControl(6);
            LastName = lastName;
            Name = name;
            MiddleName = middleName;
            PhoneNumber = phoneNumber;
            PassportSeriesAndNumber = passportSeriesAndNumber;
        }
    }
}