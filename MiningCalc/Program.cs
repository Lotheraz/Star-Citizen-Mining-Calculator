using System;
using System.Text;
using static MiningCalc.Calculator;

namespace MiningCalc
{
    internal class Program
    {
        static string seperator = "------------------------------------------------------------------------------------------------------------------------";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to the Quantanium mining calculator");
            Console.WriteLine("This will give you an estimated SCU and aUEC value of based on your rock type, purity and mass input");

            bool isGoing = true;
            while (isGoing)
            {
                try
                {
                    loop(out isGoing);
                }catch(Exception kuken){
                    Console.WriteLine(kuken.Message);
                }
            }
        }

        static string PrintMenu()
        {
            StringBuilder sb = new StringBuilder();
            int maxAmount = Enum.GetValues(typeof(RockTypesEnum)).Length;
            sb.AppendLine($"Please enter the type of rock you have found corresponding to the correct number from 1 to {maxAmount}, or 0 to close the program.");
            sb.AppendLine(seperator);
            sb.AppendLine("Press 0 to exit the proram");
            foreach (RockTypesEnum rockType in Enum.GetValues(typeof(RockTypesEnum)))
            {
                sb.AppendLine($"Press {(int)rockType} for {rockType}");
            }
            sb.AppendLine($"We have not included any other materials other than these {maxAmount} as they are simply not worth mining at this time.");
            return sb.ToString();
        }

        static void loop(out bool keepLooping)
        {
            #region user selects rock
            int userChosenInput = GetIntValueFromConsole(PrintMenu());
            if (userChosenInput == 0)
            {
                Console.WriteLine("Exiting program.");
                keepLooping = false;
                return;
            }

            var rockTypeValues = Enum.GetValues(typeof(RockTypesEnum));
            if (userChosenInput > rockTypeValues.Length || userChosenInput < 0)
            {
                Console.WriteLine("You did not enter a valid value, please enter a number between 1 and 6 for your corresponding material or 0 to close the program");
                keepLooping = true;
                return;
            }

            RockTypesEnum rockType = (RockTypesEnum)userChosenInput;
            double rockValue = GetRockScuValue(rockType);
            Console.WriteLine($"You have chosen the material {rockType}, valued at {rockValue} aUEC per mass");
            #endregion

            double mass = GetDoubleValueFromConsole("Please enter the mass of the rock you have found");
            double purity = GetDoubleValueFromConsole("Thank you, now please enter the purity of the rock");

            double aUECValue = Math.Round(CalculateAuec(rockType, mass, purity));
            double scuValue = Math.Round(CalculateScu(mass, purity), 2);

            Console.WriteLine($"Thank you, the estimated SCU and value of this rock is {scuValue} SCU valued at {aUECValue} aUEC.");
            keepLooping = true;
        }

        static int GetIntValueFromConsole(string prompt)
        {
            Console.WriteLine(prompt);
            string userInput = Console.ReadLine();
            return int.Parse(userInput);
        }

        static double GetDoubleValueFromConsole(string prompt)
        {
            Console.WriteLine(prompt);
            string userInput = Console.ReadLine();
            double d = double.Parse(userInput);
            if (d <= 0)
            {
                throw new FormatException("Must be greater than 0");
            }
            return d;
        }
    }
}
