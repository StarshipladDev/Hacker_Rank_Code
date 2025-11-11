using System;
using System.Collections.Generic;
using System.Linq;

/**
 * <summary>
 * The Result class contains utility methods for performing arithmetic operations
 * on integer lists. Specifically, it provides functionality to calculate the 
 * minimum and maximum sums from a list of five integers.
 * </summary>
 * <author>Starshiplad</author>
 * <date>2025-11-12</date>
 */
class Result
{

    /**
     * <summary>
     * Calculates the minimum and maximum sums that can be obtained by summing
     * exactly four out of five integers from the provided list. Captures ints as logns when ordering as the sum may have overflow.
     * </summary>
     * <param name="arr">
     * A list of exactly five integers for which the min and max sums are calculated.
     * </param>
     * <returns>
     * A list of strings containing two values: 
     * the maximum sum as the first element and the minimum sum as the second.
     * </returns>
     * <exception cref="InvalidOperationException">
     * Thrown when the provided list does not contain exactly five integers.
     * </exception>
     * <author>Starshiplad</author>
     * <date>2025-11-12</date>
     */
    public static List<string> miniMaxSum(List<int> arr)
    {
        if(arr.Count() < 5 || arr.Count() > 5){
            throw new InvalidOperationException("arr passed into miniMaxSum must be  5 ints");
        }
        List<int> arrSorted = arr.OrderByDescending(x => x).ToList();
        long lowerSum = (from item in arrSorted.GetRange(1,4)
            select (long)(item)
           )
           .DefaultIfEmpty(0).Sum();
        long upperSum = (from item in arrSorted.GetRange(0,4)
            select (long)(item)
           )
           .DefaultIfEmpty(0).Sum();
        //Console.WriteLine($"Long is {upperSum}, Short is {lowerSum}");
        return new List<string>{lowerSum.ToString(),upperSum.ToString()};
    }
}

/**
 * <summary>
 * The Solution class handles console input and output for testing the 
 * miniMaxSum method. It reads a space-separated list of integers from input,
 * computes the min and max sums, and prints them to the console.
 * </summary>
 * <author>Starshiplad</author>
 * <date>2025-11-12</date>
 */
class Solution
{
    /**
     * <summary>
     * The entry point of the program. Reads user input, parses it into integers,
     * calls the miniMaxSum method, and outputs the results.
     * </summary>
     * <param name="args">Command-line arguments (not used in this implementation).</param>
     * <author>Starshiplad</author>
     * <date>2025-11-12</date>
     */
    public static void Main(string[] args)
    {
        List<int> arr = Console.ReadLine()
                               .TrimEnd()
                               .Split(' ')
                               .ToList()
                               .Select(arrTemp => Convert.ToInt32(arrTemp))
                               .ToList();

        List<string> resultStrings = Result.miniMaxSum(arr);
        Console.Write($"{resultStrings[0]} {resultStrings[1]}");
    }
}
