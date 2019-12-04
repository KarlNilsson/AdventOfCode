using System;
using System.Collections.Generic;
using System.Linq;

namespace December1
{
    public class RocketEquation
    {
        public static List<string> LoadInput(string filepath)
        {
            string[] stringSeparator = { "\r\n" };
            var contents = System.IO.File.ReadAllText(filepath).Split(stringSeparator, StringSplitOptions.RemoveEmptyEntries);
            return new List<string>(contents);
        }

        public static int CalculateFuelRequirements(List<string> input)
        {
            var fuelRequirements = new List<int>(input.Count);
            input.ForEach(x =>
            {
                var mass = double.Parse(x);
                var fuelRequired = Math.Floor(mass / 3) - 2;
                mass = fuelRequired;
                while (mass > 0)
                {
                    var additionalFuel = mass;
                    var fuelFuel = Math.Floor(additionalFuel / 3) - 2;
                    mass = fuelFuel;
                    if (mass > 0)
                        fuelRequired += fuelFuel;
                }

                fuelRequirements.Add((int)fuelRequired);
            });
            return fuelRequirements.Sum();
        }

        public static void Main()
        {
        }
    }

}