using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA_CALCULATOR
{
    internal class GradeGPA
    {
        public double totalWeightPoints = 0;
        public int totalUnits = 0;
        public int totalUnitPassed = 0;

        public string[] AddCourse(string courseCode, int courseUnit, double score)
        {
            var gradeTuple = Gradescore(score);
            double qualityPoint = courseUnit * gradeTuple.Item2;
            string[] row = new string[6];
            row[0] = courseCode;
            row[1] = courseUnit.ToString();
            row[2] = gradeTuple.Item1;
            row[3] = gradeTuple.Item2.ToString();
            row[4] = qualityPoint.ToString();
            row[5] = gradeTuple.Item3;
            totalWeightPoints += qualityPoint;
            totalUnits += courseUnit;
            if (gradeTuple.Item1 != "F")
                totalUnitPassed += courseUnit;
            return row;
        }

        private static Tuple<string, int, string> Gradescore(double score)
        {

            if (score >= 70 && score <= 100)
            {
                return Tuple.Create("A", 5, "Excellent");
            }
            else if (score >= 60 && score <= 69)
            {
                return Tuple.Create("B", 4, "Very Good");
            }
            else if (score >= 50 && score <= 59)
            {
                return Tuple.Create("C", 3, "Good");
            }
            else if (score >= 45 && score <= 49)
            {
                return Tuple.Create("D", 2, "Pass");
            }
            else if (score >= 40 && score <= 44)
            {
                return Tuple.Create("E", 1, "Poor");
            }
            else if (score >= 0 && score <= 39)
            {
                return Tuple.Create("F", 0, "Fail");
            }
            else
            {
                return Tuple.Create("Invalid", -1, "Invalid");
            }
        }
    }
}
