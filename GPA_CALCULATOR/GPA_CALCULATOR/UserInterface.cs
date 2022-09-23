using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GPA_CALCULATOR
{
    public class UserInterface
    {
        static readonly string[] header = new string[] { "COURSE & CODE", "COURSE UNIT", "GRADE", "GRADE-UNIT", "WEIGHT POINT", "REMARK" };
        PrintResult printResult = new PrintResult(header);
        GradeGPA gpa = new GradeGPA();
        readonly string options = @"Options:
        Add   Add Courses to your calculator
        Print Show All result
        Help  Show all options
        Exit  Terminate the application";

        public void StartUpDisplay()
        {

            while (true)
            {
                string course;
                int unit;
                double score;
                while (true)
                {
                    Console.WriteLine("Enter Course and Code");
                    course = Console.ReadLine();
                    if (CheckCourseNameCode(course))
                    {
                        break;
                    }
                    Console.WriteLine("Please input the right format like MTH101");
                }
                while (true)
                {
                    Console.WriteLine("Enter Course Unit");
                    bool checkUnit = int.TryParse(Console.ReadLine(), out unit);
                    if (CheckCourseUnit(unit) && checkUnit)
                    {
                        break;
                    }
                    Console.WriteLine("Please input numbers from range 1 - 9");
                }
                while (true)
                {
                    Console.WriteLine("Enter the Score");
                    bool checkScore = double.TryParse(Console.ReadLine(), out score);
                    if (CheckScore(score) && checkScore)
                    {
                        break;
                    }
                    Console.WriteLine("Please input score from 0 - 100");
                }


                string[] row = gpa.AddCourse(course, unit, score);
                printResult.AddRow(row);

                Console.Clear();
                Console.WriteLine("Do you want to enter another course: Enter 1 or any key to exit");
                if (Console.ReadLine() != "1")
                    break;
            }


        }

        public void DisplayResult()
        {
            double GPA = Math.Round(gpa.totalWeightPoints / gpa.totalUnits, 2);
            printResult.Print();
            Console.ResetColor();
            Console.WriteLine($"Total Course Unit Registered is {gpa.totalUnits}. ");
            Console.WriteLine($"Total Course Unit Passed is {gpa.totalUnitPassed}. ");
            Console.WriteLine($"Total Weight Point is {gpa.totalWeightPoints}. ");
            Console.WriteLine($"Your GPA is = {GPA}. ");
        }

        public void Help()
        {
            Console.WriteLine(options);
        }
        private bool CheckCourseNameCode(string course)
        {
            string strRegex = @"^[A-Z]{3}\d{3}$";

            Regex re = new Regex(strRegex);


            if (re.IsMatch(course))
                return (true);
            else
                return (false);
        }

        private bool CheckCourseUnit(int unit)
        {
            if (unit > 0 && unit < 10)
            {
                return true;
            }
            return false;
        }

        private bool CheckScore(double score)
        {
            if (score >= 0 && score <= 100)
            {
                return true;
            }
            return false;
        }
    }
}
