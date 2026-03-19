using System;
using System.Collections.Generic;

class Course
{
    public string Code { get; set; }
    public int Unit { get; set; }
    public int Score { get; set; }
    public string Grade { get; set; }
    public int GradeUnit { get; set; }
    public int WeightPoint { get; set; }
    public string Remark { get; set; }
}

class PrintTable
{
    public static void Display(List<Course> courses, int totalCourseUnit, int totalCourseUnitPassed, int totalWeightPoint, double gpa)
    {
        Console.WriteLine("\n|-----------------|-------------|-------|------------|-------------|--------------|");
        Console.WriteLine("| COURSE & CODE  | COURSE UNIT | GRADE | GRADE-UNIT | WEIGHT Pt.  |    REMARK    |");
        Console.WriteLine("|-----------------|-------------|-------|------------|-------------|--------------|");

        foreach (var c in courses)
        {
            Console.WriteLine($"| {c.Code,-15} | {c.Unit,-11} | {c.Grade,-5} | {c.GradeUnit,-10} | {c.WeightPoint,-11} | {c.Remark,-12} |");
        }

        Console.WriteLine("|--------------------------------------------------------------------------------|");

        // Print summary
        Console.WriteLine($"\nTotal Course Unit Registered: {totalCourseUnit}");
        Console.WriteLine($"Total Course Unit Passed: {totalCourseUnitPassed}");
        Console.WriteLine($"Total Weight Point: {totalWeightPoint}");
        Console.WriteLine($"Your GPA is = {gpa:F2} (to 2 decimal places)");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of courses: ");
        int numCourses = int.Parse(Console.ReadLine());

        List<Course> courses = new List<Course>();

        for (int i = 0; i < numCourses; i++)
        {
            Console.WriteLine($"\nCourse {i + 1}:");
            Console.Write("Enter Course Name & Code (e.g., MTH101): ");
            string code = Console.ReadLine();

            Console.Write("Enter Course Unit: ");
            int unit = int.Parse(Console.ReadLine());

            Console.Write("Enter Score (0–100): ");
            int score = int.Parse(Console.ReadLine());

            // Determine grade
            string grade;
            int gradeUnit;
            string remark;

            if (score >= 70) { grade = "A"; gradeUnit = 5; remark = "Excellent"; }
            else if (score >= 60) { grade = "B"; gradeUnit = 4; remark = "Very Good"; }
            else if (score >= 50) { grade = "C"; gradeUnit = 3; remark = "Good"; }
            else if (score >= 45) { grade = "D"; gradeUnit = 2; remark = "Fair"; }
            else if (score >= 40) { grade = "E"; gradeUnit = 1; remark = "Pass"; }
            else { grade = "F"; gradeUnit = 0; remark = "Fail"; }

            int weightPoint = unit * gradeUnit;

            courses.Add(new Course
            {
                Code = code,
                Unit = unit,
                Score = score,
                Grade = grade,
                GradeUnit = gradeUnit,
                WeightPoint = weightPoint,
                Remark = remark
            });
        }

        // Totals
        int totalCourseUnit = 0;
        int totalCourseUnitPassed = 0;
        int totalWeightPoint = 0;

        foreach (var c in courses)
        {
            totalCourseUnit += c.Unit;
            if (c.GradeUnit > 0) totalCourseUnitPassed += c.Unit;
            totalWeightPoint += c.WeightPoint;
        }

        double gpa = (double)totalWeightPoint / totalCourseUnit;

        // Print table using PrintTable class
        PrintTable.Display(courses, totalCourseUnit, totalCourseUnitPassed, totalWeightPoint, gpa);
    }
}
