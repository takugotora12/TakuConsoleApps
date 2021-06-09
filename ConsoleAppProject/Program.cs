using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using ConsoleAppProject.App04;

using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start Apps 01 to 05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Taku Gotora 04/06/2021
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("BNU CO453 Applications Programming 2020-2021!");
            Console.WriteLine();
            Console.WriteLine("                 Welcome!                    ");
            Console.WriteLine("      Please select your application         ");
            Console.WriteLine("  For Distance Converter please select 1 >   ");
            Console.WriteLine("    For BMI Calculator please select 2 >     ");
            Console.WriteLine("    For Student Grades please select 3 >     ");
            Console.WriteLine("    For ***** please select 4 >     ");


            string choice = Console.ReadLine();

            if (choice == "1")
            {
                DistanceConverter converter = new DistanceConverter();

                converter.ConvertDistance();
            }
            else if (choice == "2")
            {
                BMICalculator calculator = new BMICalculator();
                calculator.Run();
            }
            else if (choice == "3")
            {
                StudentGrades calculator = new StudentGrades();
                calculator.Run();
            }
            else if (choice == "4")
            {
                NetworkApp app04 = new NetworkApp();
                app04.DisplayMenu();
            }
            else
            {
                Console.WriteLine("                                    ");
                Console.WriteLine("       ***ERROR MESSAGE***          ");
                Console.WriteLine("You have not selected a valid option");
                Console.WriteLine("   Please restart the program...    ");
            }
        }
    }
}