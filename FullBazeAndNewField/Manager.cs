namespace FullBazeAndNewField
{
    public interface ICreateable
    {
        void CreateNewClient(string LastName, string Name, string MiddleName, string newPhoneNumber, string valuePassportSeriesAndNumber);
    }

    internal class Manager : Consultant, ICreateable
    {
        public override string ToString()
        {
            return "Manager";
        }

        protected override void CheckDisplayPassport(double passportSeriesAndNumber)
        {
            if (passportSeriesAndNumber < 1)
                _displayPassportSeriesAndNumber = "Данных нет";
            else
                _displayPassportSeriesAndNumber = passportSeriesAndNumber.ToString();
        }

        public void ChangeDate(string LastName, string Name, string MiddleName, string newPhoneNumber, string valuePassportSeriesAndNumber)
        {
            SetNewName(ChangeControl.WhatField.LastName, TryNewName(LastName, _lastName), ref _lastName);
            SetNewName(ChangeControl.WhatField.Name, TryNewName(Name, _name), ref _name);
            SetNewName(ChangeControl.WhatField.MiddleName, TryNewName(MiddleName, _middleName), ref _middleName);
            SetNewNumber(ChangeControl.WhatField.PhoneNumber, CheckInput(newPhoneNumber, _phoneNumber), ref _phoneNumber);
            SetNewNumber(ChangeControl.WhatField.PassportSeriesAndNumber, CheckInput(valuePassportSeriesAndNumber, _valuePassportSeriesAndNumber), ref _valuePassportSeriesAndNumber);
            CheckDisplayPassport(_valuePassportSeriesAndNumber);
        }

        public void CreateNewClient(string LastName, string Name, string MiddleName, string PhoneNumber, string valuePassportSeriesAndNumber)
        {
            string newLastName;
            string newName;
            string newMiddleName;
            double newPhoneNumber;
            double newPassportSeriesAndNumber;

            newLastName = TryNewName(LastName);
            newName = TryNewName(Name);
            newMiddleName = TryNewName(MiddleName);
            newPhoneNumber = CheckInput(PhoneNumber);
            newPassportSeriesAndNumber = CheckInput(valuePassportSeriesAndNumber);
            Сlient сlient = new Сlient(newLastName, newName, newMiddleName, newPhoneNumber, newPassportSeriesAndNumber);
            NewClient(сlient);
        }

        protected double CheckInput(string tryNewPhoneNumber)
        {
            double tempPhoneNumber = 0;
            if (double.TryParse(tryNewPhoneNumber, out double newPhoneNumber))
            {
                tempPhoneNumber = newPhoneNumber;
            }
            return tempPhoneNumber;
        }

        private string TryNewName(string tryNewName)
        {
            string tempName = " ";
            if (tryNewName != null)
            {
                tempName = tryNewName;
            }
            return tempName;
        }

        protected void SetNewNumber(ChangeControl.WhatField field, double newPhoneNumber, ref double oldPhoneNumber)
        {
            if (oldPhoneNumber != newPhoneNumber)
            {
                if (oldPhoneNumber == 0)
                {
                    ClientInfo.SetLastChange(field, ChangeControl.WhatHasChanged.Add, ChangeControl.User.Manager);
                }
                else
                {
                    ClientInfo.SetLastChange(field, ChangeControl.WhatHasChanged.Change, ChangeControl.User.Manager);
                }
                oldPhoneNumber = newPhoneNumber;
            }
        }

        private void SetNewName(ChangeControl.WhatField field, string NewName, ref string oldName)
        {
            if (oldName != NewName)
            {
                if (oldName == string.Empty)
                {
                    ClientInfo.SetLastChange(field, ChangeControl.WhatHasChanged.Add, ChangeControl.User.Manager);
                }
                else
                {
                    ClientInfo.SetLastChange(field, ChangeControl.WhatHasChanged.Change, ChangeControl.User.Manager);
                }
                oldName = NewName;
            }
        }

        private string TryNewName(string tryNewName, string oldName)
        {
            string tempName = oldName;
            if (tryNewName != null)
            {
                tempName = tryNewName;
            }
            return tempName;
        }
    }
}
