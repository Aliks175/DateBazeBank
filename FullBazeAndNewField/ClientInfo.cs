using System;
using System.Collections.Generic;
using static FullBazeAndNewField.ChangeControl;

namespace FullBazeAndNewField
{
    public struct ChangeControl
    {
        public Dictionary<string, string[]> InfoChanges;

        public ChangeControl(int value = 6)
        {
            InfoChanges = new Dictionary<string, string[]>();
            string[] timesChengers = new string[value];
            string[] addOrChange = new string[value];
            string[] whoChanged = new string[value];
            InfoChanges.Add("timesChengers", timesChengers);
            InfoChanges.Add("addOrChange", addOrChange);
            InfoChanges.Add("whoChanged", whoChanged);
        }

        public enum User
        {
            Manager,
            Consultant
        }

        public enum FiendTargetOnDictionary
        {
            timesChengers,
            addOrChange,
            whoChanged
        }

        public enum WhatHasChanged
        {
            Add,
           // Del,
            Change 
        }

        public enum WhatField
        {
            LastName,
            Name,
            MiddleName,
            PhoneNumber,
            PassportSeriesAndNumber
        }
    }

    public class ClientInfo
    {
        public ChangeControl changeControl {  get;private set; }

        public ClientInfo()
        {
            changeControl = new ChangeControl(6);
        }

        //public ClientInfo(ChangeControl newchangeControl)
        //{
        //    changeControl = newchangeControl;
        //}

        public void LastChange(ChangeControl.WhatField field, ChangeControl.WhatHasChanged changer, ChangeControl.User user)
        {
            changeControl.InfoChanges["timesChengers"][(int)field] = DateTime.Now.ToString();
            changeControl.InfoChanges["addOrChange"][(int)field] = changer.ToString();
            changeControl.InfoChanges["whoChanged"][(int)field] = user.ToString();
        }

        public string Show(FiendTargetOnDictionary fiendTarget, ChangeControl.WhatField field)
        {
            return changeControl.InfoChanges[fiendTarget.ToString()][(int)field];
        }
    }
}
