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

/**
 * <summary>
 * Provides utility methods for analyzing birthday cake candles and determining
 * which candles are the tallest. This class supports the birthday cake candles
 * problem where the goal is to count how many candles can be blown out (only
 * the tallest candles can be blown out).
 * </summary>
 */
public class BirthdayCakeResulter
{
    /**
     * <summary>
     * Counts how many candles have the maximum height.
     * </summary>
     * <param name="candles">List of candle heights.</param>
     * <returns>The count of candles with the highest height.</returns>
     * <exception cref="ArgumentNullException">Thrown when candles list is null.</exception>
     * <exception cref="InvalidOperationException">Thrown when candles list is empty.</exception>
     */
    public static int CountHighestCandles(List<int> candles)
    {
        if (candles == null)
        {
            throw new ArgumentNullException(nameof(candles));
        }
        
        if (candles.Count == 0)
        {
            throw new InvalidOperationException("Candles list cannot be empty.");
        }
        
        List<int> candlesSorted = candles.OrderDescending().ToList();
        int highestCandleLength = candlesSorted[0];
        Console.WriteLine($"Highest length is {highestCandleLength}");
        return candlesSorted.Where(x => x == highestCandleLength).Count();
    }
}

/**
 * <summary>
 * Main result class containing the solution to the birthday cake candles problem.
 * This class processes a list of candle heights and determines how many candles
 * are at the maximum height, since only those candles can be successfully blown out.
 * </summary>
 */
class Result
{
    /**
     * <summary>
     * Determines how many candles are tallest on the birthday cake.
     * </summary>
     * <param name="candles">List of candle heights as integers.</param>
     * <returns>The number of candles that match the maximum height, or 0 if the list is empty.</returns>
     * <remarks>
     * The function returns 0 if the candles list is empty rather than throwing an exception.
     * </remarks>
     */
    public static int birthdayCakeCandles(List<int> candles)
    {
        if (candles == null || candles.Count == 0)
        {
            return 0;
        }
        return BirthdayCakeResulter.CountHighestCandles(candles);
    }
}

/**
 * <summary>
 * Entry point class for the birthday cake candles solution. Handles console input/output
 * and file writing operations. Reads candle heights from standard input and writes the
 * result to a file path specified by the OUTPUT_PATH environment variable.
 * </summary>
 */
class Solution
{
    /**
     * <summary>
     * Main entry point that reads input, processes candles, and writes the result.
     * </summary>
     * <param name="args">Command line arguments (not used).</param>
     * <remarks>
     * Reads candle heights from console input (space-separated integers on the second line),
     * then writes the count of tallest candles to the path specified in OUTPUT_PATH environment variable.
     * </remarks>
     */
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<int> candles = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(candlesTemp => Convert.ToInt32(candlesTemp)).ToList();

        int result = Result.birthdayCakeCandles(candles);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}