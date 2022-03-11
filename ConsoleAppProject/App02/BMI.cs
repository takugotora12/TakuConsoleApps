using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This app will work out the users BMIT
    /// This will be done through them entering their height and weight in either imperial or metric units 
    /// In either imperial or metric units. 
    /// </summary>
    /// <author>
    /// Takudzwa Gotora
    /// </author>
    public class BMICalculator
    {
        public const double Underweight = 18.5;
        public const double Normal = 24.9;
        public const double Overweight = 29.9;
        public const double ObeseLevel1 = 34.9;
        public const double ObeseLevel2 = 39.9;
        public const double ObeseLevel3 = 40.0;

        public const int InchesInFeet = 12;
        public const int PoundsInStones = 14;

        public const string METRIC = "metric";
        public const string IMPERIAL = "imperial";

        public double Index { get; set; }
        public string who;

        public double Centimetres { get; set; }
        public double Inches { get; set; }
        public double Kilograms { get; set; }
        public double Metres { get; set; }
        public double Feet { get; set; }

        public double Pounds { get; set; }
        public double Stones { get; set; }
        public double Bmi { get; set; }
        public double Metric_Conversion { get; private set; }


        /// <summary>
        /// Make user choose between Imperial or Metric units.
        /// Input the user's height and weight and then calculate
        /// their BMI value. Output which weight the category
        /// falls into.
        /// </summary>
        public void Run()
        {
            ConsoleHelper.OutputHeading("BMI Converter");
            string unit = SelectUnit();

            if (unit == METRIC)
            {
                InputMetricHeight();
                Metres = Centimetres / 100;
                InputMetricWeight();
                CalculateMetric();
            }
            else
            {
                InputImperialHeight();
                InputImperialWeight();
                CalculateImperial();
            }

            OutputBmi();
            GetHealthMessage();
            OutputWho();
            OutputRisk();
        }

        private string SelectUnit(string prompt)
        {
            string choice = DisplayChoices(prompt);

            string unit = ExecuteChoice(choice);
            Console.WriteLine($"\n You have chosen {unit}");
            return unit.ToLower();
        }

        public void OutputBmi()
        {
            Console.WriteLine($"Your current BMI is {Index:0.00}");
        }

        /// <summary>
        /// Output a short description of the application 
        /// and the name of the author.
        /// </summary>
        /// 
        private static string DisplayChoices(string prompt)
        {
            Console.WriteLine();
            Console.WriteLine($" 1. {METRIC}");
            Console.WriteLine($" 2. {IMPERIAL}");
            Console.WriteLine();

            Console.Write(prompt);
            string choice = Console.ReadLine();
            return choice;
        }

        /// <summary>
        /// Display a menu of measurement units and then prompt the 
        /// user to select one and return it. 
        /// </summary>
        /// 
        private string SelectUnit()
        {

            Console.WriteLine("                                                      ");
            string choice = DisplayChoices("Please select metric or imperial units > ");

            string unit = ExecuteChoice(choice);
            Console.WriteLine($" You have chosen {unit}");
            return unit.ToLower();
        }

        private string ExecuteChoice(string choice)
        {
            if (choice == "1")
            {
                return METRIC;
            }
            else if (choice == "2")
            {
                return IMPERIAL;
            }
            else
            {
                Console.WriteLine("You have not selected a valid option");
                return null;
            }
        }

        /// <summary>
        /// Prompt the user into entering height in metric 
        /// </summary>
        private void InputMetricHeight()
        {
            Centimetres = ConsoleHelper.InputNumber("Please enter your height in Centimeters > ");
        }

        /// <summary>
        /// Prompt the user into entering weight in metric 
        /// </summary>
        private void InputMetricWeight()
        {
            Kilograms = ConsoleHelper.InputNumber("Please enter your weight in Kilograms > ");
        }

        /// <summary>
        /// Prompt the user into entering height in imperial 
        /// </summary>
        private void InputImperialHeight()
        {
            Feet = ConsoleHelper.InputNumber("Please enter your height in Feet > ");
            Inches = ConsoleHelper.InputNumber("Please enter your height in Inches > ");
        }

        /// <summary>
        /// Prompt the user into entering weight in imperial 
        /// </summary>
        private void InputImperialWeight()
        {
            Stones = ConsoleHelper.InputNumber("Please enter your weight in (stones) > ");
            Pounds = ConsoleHelper.InputNumber("Please enter your weight in (pounds) > ");
        }

        /// <summary>
        /// Calculating imperial conversion 
        /// </summary>
        public void CalculateImperial()
        {
            Inches = Inches + Feet * InchesInFeet;
            Pounds = Pounds + Stones * PoundsInStones;
            Index = (double)Pounds * 703 / (Inches * Inches);
        }

        /// <summary>
        /// Calculating metric conversion 
        /// </summary>
        public void CalculateMetric()
        {
            Metres = Centimetres / 100;
            Index = (Kilograms / (Metres * Metres));
        }

        /// <summary>
        /// Calculating WHO weight status
        /// </summary>
        public string GetHealthMessage()
        {
            StringBuilder message = new StringBuilder("\n");

            if (Index < Underweight)
            {
                message.Append($" Your BMI is {Index:0.00}, " +
                    $"You are Underweight ");
            }
            else if (Index <= Normal)
            {
                message.Append($" Your BMI is {Index:0.00}, " +
                     $"Congratulations you are Healthy! ");
            }
            else if (Index <= Overweight)
            {
                message.Append($" Your BMI is {Index:0.00}, " +
                    $"You are Overweight ");
            }
            else if (Index <= ObeseLevel1)
            {
                message.Append($" Your BMI is {Index:0.00}, " +
                    $"You are in the Obese Category 1 ");
            }
            else if (Index <= ObeseLevel2)
            {
                message.Append($" Your BMI is {Index:0.00}, " +
                    $"You are in the Obese Category 2 ");
            }
            else if (Index <= ObeseLevel3)
            {
                message.Append($" Your BMI is {Index:0.00}, " +
                    $"You are in the Obese Category 3 ");
            }

            return message.ToString();
        }

        /// <summary>
        /// Tells user what weight category they're in by displaying a message.
        /// </summary>
        public void OutputWho()
        {
            Console.WriteLine("Your current WHO (World Health Organisation) weight status is as follows...  " + who);
        }

        /// <summary>
        /// Gives futher information of the risk they are at. 
        /// </summary>
        public void OutputRisk()
        {
            Console.WriteLine("\n-----------------------------------------------------");
            Console.WriteLine("\n                    Please note                      ");
            Console.WriteLine("\n              You may be at extra risk               ");
            Console.WriteLine("\n          if you are one of the following:           ");
            Console.WriteLine("\n                                                     ");
            Console.WriteLine("\n       Adult BMI 23.0 or more = increased risk       ");
            Console.WriteLine("\n         Adult BMI 27.5 or more = higher risk        ");
            Console.WriteLine("\n                                                     ");
            Console.WriteLine("\n                     Children                        ");
            Console.WriteLine("\n                     Pregnant                        ");
            Console.WriteLine("\n                   Muscle Builder                    ");
            Console.WriteLine("\n                                                     ");
            Console.WriteLine("\n------------------------------------------------------\n");
        }
    }
}
