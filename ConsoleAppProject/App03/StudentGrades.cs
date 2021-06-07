using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// This app will calculate the student marks which will be inputted into the user
    /// then converted it to a grade. 
    /// The output will be the grade and a profile of the student It can also output the mean, min and max of the grades.
    /// It can also output the mean of a grade
    /// </summary>
    /// <author>
    /// Taku Gotora.2
    /// </author>
    public class StudentGrades
    {
        //constants
        public const int LowestMark = 0;
        public const int HighestMark = 100;
        public const int LowestGradeD = 40;
        public const int LowestGradeC = 50;
        public const int LowestGradeB = 60;
        public const int LowestGradeA = 70;

        //properties
        public string[] Students { get; set; }
        public int[] Marks { get; set; }
        public int[] GradeProfile { get; set; }
        public double Mean { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public string StudentClass { get; set; }

        ///<summary>
        ///Class Constructor called when an object
        ///is created and sets up an array of students
        ///</summary>
        public StudentGrades()
        {
            Students = new string[]
            {
                 "Max", "Luke", "Jerrel", "Ivy", "Laura",
                "Warren", "Albert", "Lydia", "Megan", "Oggy"
            };

            GradeProfile = new int[(int)Grades.A + 1];
            Marks = new int[Students.Length];
        }

        /// <summary>
        /// Ouput the heading and display the menu
        /// </summary>
        public void StudentMenu()
        {
            ConsoleHelper.OutputHeading("Student Marks Application");
            DisplayMenu("Please enter your choice > ");
        }

        /// <summary>
        /// Allows user to select 
        /// their choice for the menu
        /// </summary>
        private void DisplayMenu(string prompt)
        {
            string[] choices =
            {
                "Input Marks",
                "Ouput Marks",
                "Output Stats",
                "Ouput Grade Profile",
                "Edit Name Student",
                "Quit"
            };
            int choiceNo = ConsoleHelper.SelectChoice(choices);
            ExecuteMenu(choiceNo);
        }

        /// <summary>
        /// peform other method depending on 
        /// user's chosen menu
        /// </summary>
        /// <param name="choiceNo"></param>
        private void ExecuteMenu(int choiceNo)
        {
            switch (choiceNo)
            {
                case 1:
                    InputMarks();
                    break;
                case 2:
                    OutputMarks();
                    break;
                case 3:
                    CalculateStats();
                    OutputStats();
                    break;
                case 4:
                    CalculateGradeProfile();
                    OutputGradeProfile();
                    break;
                case 5:
                    EditName();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    DisplayMenu("Please enter your choice > ");
                    break;
            }
        }

        /// <summary>
        /// Input a mark between 0 - 100 for each student 
        /// store mark in the Marks array
        /// </summary>
        public void InputMarks()
        {
            Console.WriteLine("\nPlease enter a mark for each student.\n");

            for (int i = 0; i < Students.Length; i++)
            {
                Marks[i] = (int)ConsoleHelper.InputNumber($"Enter {Students[i]} marks: ", LowestMark, HighestMark);
            }

            Console.WriteLine();
            DisplayMenu("\nPlease enter your choice > ");
        }

        /// <summary>
        /// List all the students and display
        /// their names and current mark
        /// </summary>
        public void OutputMarks()
        {
            Console.WriteLine("\nOutput mark for each student.\n");

            for (int i = 0; i < Students.Length; i++)
            {
                Console.WriteLine($"Student Name: {Students[i]} \nStudent Mark: {Marks[i]}\n" +
                    $"Student Grade: {ConvertToGrade(Marks[i])}\nStudent Class: {StudentClass}\n");
            }

            DisplayMenu("\n\nPlease enter your choice > ");
        }

        /// <summary>
        /// Calculate a students mark to a grade
        /// from F(fail) to A(First Class)
        /// </summary>
        public Grades ConvertToGrade(int mark)
        {
            if (mark >= LowestMark && mark < LowestGradeD)
            {
                StudentClass = "Fail";
                return Grades.F;
            }
            else if (mark >= LowestGradeD && mark < LowestGradeC)
            {
                StudentClass = "Third Class";
                return Grades.D;
            }
            else if (mark >= LowestGradeC && mark < LowestGradeB)
            {
                StudentClass = "Lower Second";
                return Grades.C;
            }
            else if (mark >= LowestGradeB && mark < LowestGradeA)
            {
                StudentClass = "Upper Second";
                return Grades.B;
            }
            else if (mark >= LowestGradeA && mark <= HighestMark)
            {
                StudentClass = "First Class";
                return Grades.A;
            }
            else
            {
                return Grades.F;
            }
        }

        /// <summary>
        /// Calculate and display the minimum, maximum
        /// and mean mark for all the student
        /// </summary>
        public void CalculateStats()
        {
            Minimum = Marks[0];
            Maximum = Marks[0];

            double total = 0;

            foreach (int mark in Marks)
            {
                if (mark > Maximum)
                {
                    Maximum = mark;
                }
                else if (mark < Minimum)
                {
                    Minimum = mark;
                }
                total += mark;
            }

            Mean = total / Marks.Length;
        }

        /// <summary>
        /// Calculate percentage of students 
        /// that obtained the grade
        /// </summary>
        public void CalculateGradeProfile()
        {
            for (int i = 0; i < GradeProfile.Length; i++)
            {
                GradeProfile[i] = 0;
            }

            foreach (int mark in Marks)
            {
                Grades grade = ConvertToGrade(mark);
                GradeProfile[(int)grade]++;
            }
        }

        /// <summary>
        /// Output the grade profile for each grade
        /// </summary>
        public void OutputGradeProfile()
        {
            Grades grade = Grades.D;
            Console.WriteLine();

            foreach (int count in GradeProfile)
            {
                int percentage = count * 100 / Marks.Length;
                Console.WriteLine($"Grade {grade} {percentage}% Count {count}");
                grade++;
            }

            Console.WriteLine();
            DisplayMenu("\n\nPlease enter your choice > ");
        }

        /// <summary>
        /// Output the calculated statistics
        /// for mean, minimum and maximum grade
        /// </summary>
        public void OutputStats()
        {
            Console.WriteLine("\nOutput the Statistics of marks\n");
            Console.WriteLine($"Mean Mark: {Mean}\nMinimum Mark: {Minimum}\nMaximum Mark:{Maximum}");
            Console.WriteLine();
            DisplayMenu("\n\nPlease enter your choice > ");
        }

        /// <summary>
        /// Allows user to edit  
        /// name of the student
        /// </summary>
        public void EditName()
        {
            Console.WriteLine("Enter the name of the student you want to edit: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the new student name: ");
            string NewName = Console.ReadLine();
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i].Equals(name))
                {
                    Students[i] = NewName;
                }
            }
            Console.WriteLine();
            DisplayMenu("\nPlease enter your choice > ");
        }
    }
}