using System;
using System.Collections.Generic;
using System.Text;

namespace MiningCalc
{
    public class Calculator
    {
        public enum RockTypesEnum
        {
            Quantainium = 1,
            Bexalite = 2,
            Taranite = 3,
            Borase = 4,
            Laranite = 5,
            Hepaestanite = 6,
            Aluminium = 7,
        }

        private static readonly Dictionary<RockTypesEnum, double> rockValues = new Dictionary<RockTypesEnum, double>() 
        { 
            { RockTypesEnum.Quantainium, 176.18 },
            { RockTypesEnum.Bexalite, 80.960 },
            { RockTypesEnum.Taranite, 64.9 },
            { RockTypesEnum.Borase, 64.88 },
            { RockTypesEnum.Laranite, 60.5 },
            { RockTypesEnum.Hepaestanite, 29.280 },
            { RockTypesEnum.Aluminium, 1.4 },
        };

        public static double GetRockScuValue(RockTypesEnum rockType)
        {
            return rockValues[rockType];
        }

        public static double CalculateAuec(RockTypesEnum rockType, double mass, double purity)
        {
            if (purity <= 0 || mass <= 0) return 0;

            double rockValue = rockValues[rockType];
            return (mass * rockValue) * (purity / 100);
        }

        public static double CalculateScu(double mass, double purity)
        {
            if (purity <= 0 || mass <= 0) return 0;
            
            return (mass * 0.02) * (purity / 100);
        }

        public void example()
        {
            double QuantainiumRockValue = rockValues[RockTypesEnum.Quantainium];

        }
}
}
