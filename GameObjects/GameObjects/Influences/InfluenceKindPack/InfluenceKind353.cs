﻿namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind353 : InfluenceKind
    {
        private float rate = 1f;

        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.RateOfCriticalArchitectureDamage += this.rate - 1;
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
            troop.RateOfCriticalArchitectureDamage -= this.rate - 1;
        }
    }
}

