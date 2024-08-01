namespace ConsultantAndManager
{
    internal class Manager : Consultant
    {
        public override string ToString()
        {
            return "Manager";
        }

        public override string ShowPassportSeriesAndNumber()
        {
            if (PassportSeriesAndNumber == null)
                return "Данных нет";
            else
                return PassportSeriesAndNumber;
        }

        protected override void CheckCompleatePassport(double passportSeriesAndNumber)
        {
            if (passportSeriesAndNumber < 1)
                PassportSeriesAndNumber = "Данных нет";
            else
                PassportSeriesAndNumber = passportSeriesAndNumber.ToString();
        }
    }
}
