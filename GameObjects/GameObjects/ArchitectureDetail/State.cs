﻿namespace GameObjects.ArchitectureDetail
{
    using GameObjects;
    using System;

    public class State : GameObject
    {
        public ArchitectureList Architectures = new ArchitectureList();
        public StateList ContactStates = new StateList();
        public string ContactStatesString;
        public Region LinkedRegion;
        public Architecture StateAdmin;
        public int StateAdminID;

        public int GetFactionScale(Faction faction)
        {
            if (this.Architectures.Count <= 0)
            {
                return 0;
            }
            int num = 0;
            foreach (Architecture architecture in this.Architectures)
            {
                if ((architecture.BelongedFaction == null) || (faction == architecture.BelongedFaction))
                {
                    num++;
                }
            }
            return ((num * 100) / this.Architectures.Count);
        }

        public int GetSectionScale(Section section)
        {
            if ((this.Architectures.Count <= 0) || (section.ArchitectureCount <= 0))
            {
                return 0;
            }
            int num = 0;
            foreach (Architecture architecture in this.Architectures)
            {
                if (architecture.BelongedSection == section)
                {
                    num++;
                }
                if (num >= section.ArchitectureCount)
                {
                    return 100;
                }
            }
            return ((num * 100) / section.ArchitectureCount);
        }

        public void LoadContactStatesFromString(StateList contactStates, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.ContactStates.Clear();
            foreach (string str in strArray)
            {
                State gameObject = contactStates.GetGameObject(int.Parse(str)) as State;
                if (gameObject != null)
                {
                    this.ContactStates.Add(gameObject);
                }
            }
        }

        public override string ToString()
        {
            return (base.Name + " " + this.LinkedRegionString);
        }

        public string ContactStatesDisplayString
        {
            get
            {
                string str = "";
                foreach (State state in this.ContactStates)
                {
                    str = str + state.Name + " ";
                }
                return str;
            }
        }

        public string LinkedRegionString
        {
            get
            {
                return ((this.LinkedRegion != null) ? this.LinkedRegion.Name : "----");
            }
        }

        public string StateAdminString
        {
            get
            {
                return ((this.StateAdmin != null) ? this.StateAdmin.Name : "----");
            }
        }
    }
}

