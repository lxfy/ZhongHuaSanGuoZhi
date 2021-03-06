﻿namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind3130 : InfluenceKind
    {
        private int multiple = 1;

        public override void ApplyInfluenceKind(Architecture architecture)
        {
            architecture.MultipleOfRecovery += this.multiple - 1;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.multiple = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void PurifyInfluenceKind(Architecture architecture)
        {
            architecture.MultipleOfRecovery -= this.multiple - 1;
        }

        public override double AIFacilityValue(Architecture a)
        {
            return (a.FrontLine ? this.multiple - 1 : 0.001) * (a.FrontLine ? 2 : 1) * (a.HostileLine ? 2 : 1) * (a.CriticalHostile ? 2 : 1);
        }
    }
}

