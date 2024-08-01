namespace FullBazeAndNewField
{
    internal class Manager : Consultant
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

        protected void SetNewNumber(ChangeControl.WhatField field, double newPhone, ref double _phoneNumber)
        {
            if (_phoneNumber != newPhone)
            {
                if (_phoneNumber == 0)
                {
                    clientInfo.LastChange(field, ChangeControl.WhatHasChanged.Add, ChangeControl.User.Manager);
                }
                else
                {
                    clientInfo.LastChange(field, ChangeControl.WhatHasChanged.Change, ChangeControl.User.Manager);
                }
                _phoneNumber = newPhone;
            }
        }

        private void SetNewName(ChangeControl.WhatField field, string NewName, ref string oldName)
        {
            if (oldName != NewName)
            {

                if (oldName == null)
                {
                    clientInfo.LastChange(field, ChangeControl.WhatHasChanged.Add, ChangeControl.User.Manager);
                }
                else
                {
                    clientInfo.LastChange(field, ChangeControl.WhatHasChanged.Change, ChangeControl.User.Manager);
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
