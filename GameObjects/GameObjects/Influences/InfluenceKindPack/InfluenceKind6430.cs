﻿namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6430 : InfluenceKind
    {
        private float increment;
        private int disasterId;

        public override void ApplyInfluenceKind(Person person)
        {
            if (person.LocationArchitecture != null)
            {
                if (person.LocationArchitecture.disasterDamageRateDecrease.ContainsKey(disasterId))
                {
                    person.LocationArchitecture.disasterDamageRateDecrease[disasterId] += this.increment;
                }
                else
                {
                    person.LocationArchitecture.disasterDamageRateDecrease[disasterId] = this.increment;
                }
            }
        }

        public override void ApplyInfluenceKind(Architecture a)
        {
            if (a.disasterDamageRateDecrease.ContainsKey(disasterId))
            {
                a.disasterDamageRateDecrease[disasterId] += this.increment;
            }
            else
            {
                a.disasterDamageRateDecrease[disasterId] = this.increment;
            }
        }

        public override void PurifyInfluenceKind(Person person)
        {
            if (person.LocationArchitecture.disasterDamageRateDecrease.ContainsKey(disasterId))
            {
                person.LocationArchitecture.disasterDamageRateDecrease[disasterId] -= this.increment;
            }
        }

        public override void PurifyInfluenceKind(Architecture a)
        {
            if (a.disasterDamageRateDecrease.ContainsKey(disasterId))
            {
                a.disasterDamageRateDecrease[disasterId] -= this.increment;
            }
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.disasterId = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void InitializeParameter2(string parameter)
        {
            try
            {
                this.increment = float.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

