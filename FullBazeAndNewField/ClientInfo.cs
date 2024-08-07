using System;
using System.Collections.Generic;
using static FullBazeAndNewField.ChangeControl;

namespace FullBazeAndNewField
{
    public struct ChangeControl
    {
        public Dictionary<FiendTargetOnDictionary, string[]> InfoChanges;

        public ChangeControl(int count)
        {
            InfoChanges = new Dictionary<FiendTargetOnDictionary, string[]>();
            string[] timesChengers = new string[5] { " ", " ", " ", " ", " " };
            string[] addOrChange = new string[5] { " ", " ", " ", " ", " " };
            string[] whoChanged = new string[5] { " ", " ", " ", " ", " " };
            InfoChanges.Add(FiendTargetOnDictionary.addOrChange, addOrChange);
            InfoChanges.Add(FiendTargetOnDictionary.timesChengers, timesChengers);
            InfoChanges.Add(FiendTargetOnDictionary.whoChanged, whoChanged);
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
        public ChangeControl ChangeControl { get; private set; }

        public ClientInfo()
        {
            ChangeControl = new ChangeControl(5);
        }
        public ClientInfo(ChangeControl changeControl)
        {
            this.ChangeControl = changeControl;
        }

        public void NewChangeControl(ChangeControl newchangeControl)
        {
            ChangeControl = newchangeControl;
        }

        public void SetLastChange(ChangeControl.WhatField field, ChangeControl.WhatHasChanged changer, ChangeControl.User user)
        {
            ChangeControl.InfoChanges[FiendTargetOnDictionary.timesChengers][(int)field] = DateTime.Now.ToString();
            ChangeControl.InfoChanges[FiendTargetOnDictionary.addOrChange][(int)field] = changer.ToString();
            ChangeControl.InfoChanges[FiendTargetOnDictionary.whoChanged][(int)field] = user.ToString();
        }

        public string Show(FiendTargetOnDictionary fiendTarget, ChangeControl.WhatField field)
        {
            return ChangeControl.InfoChanges[fiendTarget][(int)field];
        }

        public bool NoEmptyDictionary(FiendTargetOnDictionary fiendTarget, ChangeControl.WhatField field, string nuleable)
        {
            return ChangeControl.InfoChanges[fiendTarget][(int)field] != nuleable;
        }
    }
}
