using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This app will workout the input distance 
    /// measured in by one unit  then it will calculate the
    /// Output and equivalent distance from another unit (toUnit).
    /// </summary>
    /// <author>
    /// Taku Gotora.3
    /// </author>
    /// 

    // Distance conversion constants

    public class DistanceConverter
    {
        public const int FEET_IN_MILES = 4900;

        public const double METRES_IN_MILES = 1200.45;

        public const double FEET_IN_METRES = 3.62732;

        //public const double MILES_IN_METRES = 0.0002321; 

        // Distance Unit Names 

        public const string FEET = "Feet";
        public const string MILES = "Miles";
        public const string METRES = "Metres";


        // Distance variables 

        public double FromDistance { get; set; }

        public double ToDistance { get; set; }

        // Unit variables 
        public string FromUnit { get; set; }

        public string ToUnit { get; set; }

        public DistanceConverter()
        {
            FromUnit = MILES;
            ToUnit = FEET;
        }

        /// <summary>
        /// This is where the distance will be put in
        /// </summary>
        ///
        public void ConvertDistance()
        {
            ConsoleHelper.OutputHeading("Distance Converter");

            FromUnit = SelectUnit(" Please select from distance unit > ");
            ToUnit = SelectUnit(" Please select the to distance unit > ");

            Console.WriteLine($" Converting {FromUnit} to {ToUnit}");

            FromDistance = ConsoleHelper.InputNumber($" Please enter the number of {FromUnit} > ");

            CalculateDistance();

            OutputDistance();
        }

        public void CalculateDistance()
        {
            //converting distance from miles to feet 
            //
            if (FromUnit == MILES && ToUnit == FEET)
            {
                ToDistance = FromDistance * FEET_IN_MILES;
            }
            else if (FromUnit == FEET && ToUnit == MILES)
            {
                ToDistance = FromDistance / FEET_IN_MILES;
            }

            //converting distance from metres to feet 
            //
            if (FromUnit == METRES && ToUnit == FEET)
            {
                ToDistance = FromDistance * FEET_IN_METRES;
            }
            else if (FromUnit == FEET && ToUnit == METRES)
            {
                ToDistance = FromDistance / FEET_IN_METRES;
            }

            //convert distance from miles to metres
            //
            if (FromUnit == MILES && ToUnit == METRES)
            {
                ToDistance = FromDistance * METRES_IN_MILES;
            }
            //Convert Metres to Miles
            else if (FromUnit == METRES && ToUnit == MILES)
            {
                ToDistance = FromDistance / METRES_IN_MILES;
            }
        }

        /// <summary>
        /// displaying a menu which shows distance of units.  
        /// user is then prompt to choosing one. 
        /// </summary>
        /// 

        private string SelectUnit(string prompt)
        {
            string choice = DisplayChoices(prompt);

            string unit = ExecuteChoice(choice);
            Console.WriteLine($"\n You have chosen {unit}");
            return unit;
        }

        /// <summary>
        /// Displaying the choices
        /// </summary>       
        private string ExecuteChoice(string choice)
        {
            if (choice == "1")
            {
                return FEET;
            }
            else if (choice == "2")
            {
                return METRES;
            }
            else if (choice == "3")
            {
                return MILES;
            }
            else
            {
                Console.WriteLine("                                    ");
                Console.WriteLine("       ***ERROR MESSAGE***          ");
                Console.WriteLine("You did not select a valid option");
                Console.WriteLine("            try again...         ");
                return null;
            }
        }

        private static string DisplayChoices(string prompt)
        {
            Console.WriteLine();
            Console.WriteLine($" 1. {FEET}");
            Console.WriteLine($" 2. {METRES}");
            Console.WriteLine($" 3. {MILES}");
            Console.WriteLine();

            Console.Write(prompt);
            string choice = Console.ReadLine();
            return choice;
        }

        /// <summary>
        /// User enters distance
        /// </summary>
        private double InputDistance(string prompt)
        {
            Console.Write(prompt);
            String value = Console.ReadLine();
            return Convert.ToDouble(value);
        }

        private void OutputDistance()
        {
            Console.WriteLine($"\n {FromDistance}  {FromUnit}" +
                $" is {ToDistance} {ToUnit}!\n");
        }

        /// <summary>
        /// A short discription of the application 
        /// author name 
        /// inform the use which units are being converted.
        /// </summary>
        /// 
        private void OutputHeading()
        {
            Console.WriteLine("\n-------------------------------");
            Console.WriteLine("\n     Distance Converter        ");
            Console.WriteLine("\n       by TAKU GOTORA        ");
            Console.WriteLine("\n-------------------------------\n");
        }

    }

}
