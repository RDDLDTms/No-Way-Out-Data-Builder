using NWO_Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBuilder.Leverages
{
    public class LeverageEffectsApplying : ILeverageData
    {
        public double Cooldown { get; set; }

        public LeverageType Type { get; }

        public LeverageEffectsApplying(double cooldown, LeverageType type)
        {
            Cooldown = cooldown;
            Type = type;
        }
    }
}
