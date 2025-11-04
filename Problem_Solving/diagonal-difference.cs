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

class Result
{

    /*
     * <author> StarshipladDev </author>
     * <param> arr - a 2d list of ints, each cell between -100 and 100 </param>
     * <summary> Takes a 2D array and compares the difference in 
     * sum of top left to bottom right with the inverse</summary>
     * <returns> The difference in diagonals, int</returns>
     */

    public static int diagonalDifference(List<List<int>> arr)
    {
        int totalCount = arr.Count();
        if (totalCount < 0)
        {
            return 0;
        }
        int leftToRight, rightToLeft;
        leftToRight = rightToLeft = 0;
        for (int i = 0; i < totalCount; i++)
        {
            leftToRight += arr[i][i];
            rightToLeft += arr[i][totalCount - (1 + i)];
        }
        Console.WriteLine($"Preforming difference, left is ${leftToRight}, right is ${rightToLeft}");
        return Math.Abs(leftToRight - rightToLeft);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.diagonalDifference(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
