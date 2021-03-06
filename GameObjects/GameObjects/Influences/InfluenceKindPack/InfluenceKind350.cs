﻿namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind350 : InfluenceKind
    {
        private float rate;

        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.RateOfCriticalDamageReceived = this.rate;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.rate = float.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.RateOfCriticalDamageReceived = 1;
        }
    }
}

