using System;
using System.Collections.Generic;

namespace FullBazeAndNewField
{
    internal class ClientInfo
    {
        private Сlient _сlient;

        private List<DateTime> _timesChengers;
        private List<bool> _dateChengers;
        private List<bool> _addOrChange;
        private List<string> _whoChanged;

        //public string LastName { get; set; }

        //public string Name { get; set; }

        //public string MiddleName { get; set; }

        //public double PhoneNumber { get; set; }

        //public double PassportSeriesAndNumber { get; set; }
        public ClientInfo(Сlient сlient)
        {
            _сlient = сlient;
            _timesChengers = new List<DateTime>();
            _dateChengers = new List<bool>();
            _addOrChange = new List<bool>();
            _whoChanged = new List<string>();
        }

        public void SetLastName()
        {

        }
    }
}
