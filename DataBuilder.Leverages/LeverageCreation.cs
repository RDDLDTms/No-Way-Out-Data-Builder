using NWO_Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBuilder.Leverages
{
    public class LeverageCreation : ILeverageData
    {
        public double Cooldown { get; set; }

        public LeverageType Type { get; }

        public LeverageCreation(double cooldown, LeverageType type)
        {
            Cooldown = cooldown;
            Type = type;
        }
    }
}
