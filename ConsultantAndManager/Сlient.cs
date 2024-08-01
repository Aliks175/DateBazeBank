namespace ConsultantAndManager
{
    public class Сlient
    {
        public string LastName { get; private set; }

        public string Name { get; private set; }

        public string MiddleName { get; private set; }

        public double PhoneNumber { get; private set; }

        public double PassportSeriesAndNumber { get; private set; }

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