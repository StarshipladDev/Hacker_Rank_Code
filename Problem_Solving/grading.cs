using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

/// <summary>
/// A class to handle the rounding of grades that are within 3 of a multiple of 5.
/// </summary>
class Result
{
    /// <summary>
    /// A function to be called externally when a list of ints needs to be rounded.
    /// </summary>
    /// <param name="grades">The original grades of a given class</param>
    /// <returns>A list of grades, in the same order as the input list, rounded using <see cref="roundGrade(int)"/> </returns>
    public static List<int> gradingStudents(List<int> grades)
    {
        List<int> updatedGrades = new List<int>();
        grades.ForEach((grade) => {
            updatedGrades.Add(roundGrade(grade));
        });
        return updatedGrades;
    }
    /// <summary>
    /// Rounds grade using the following logic: Any grade below 38 remains the same, any grade within 3
    /// of a multiple of 5 is rounded to that number.
    /// </summary>
    /// <param name="grade">The original grade</param>
    /// <returns>The input grade rounded using the above logic.</returns>
    public static int roundGrade(int grade)
    {
        Console.WriteLine(grade % 5);
        if (grade >= 38 && (1.0 / (grade % 5) < 0.5))
        {
            return grade + (5 - (grade % 5));
        }
        return grade;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int gradesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> grades = new List<int>();

        for (int i = 0; i < gradesCount; i++)
        {
            int gradesItem = Convert.ToInt32(Console.ReadLine().Trim());
            grades.Add(gradesItem);
        }

        List<int> result = Result.gradingStudents(grades);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
