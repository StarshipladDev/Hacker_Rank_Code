using System;
using System.IO;

class Result
{
    /// <summary>
    /// Converts a 12-hour AM/PM time string into 24-hour military time.
    /// </summary>
    /// <param name="s">
    /// Time in the format hh:mm:ssAM or hh:mm:ssPM.
    /// Example: 07:05:45PM
    /// </param>
    /// <returns>
    /// A string in 24-hour format.
    /// Example: 19:05:45
    /// </returns>
    public static string timeConversion(string s)
    {
        // Extract the hour portion (first two characters)
        int hour = int.Parse(s.Substring(0, 2));

        // Extract AM / PM suffix
        string period = s.Substring(8, 2);

        // Handle AM conversion
        if (period == "AM")
        {
            // Midnight case: 12AM becomes 00
            if (hour == 12)
                hour = 0;
        }
        else // PM conversion
        {
            // Add 12 hours unless already 12PM
            if (hour != 12)
                hour += 12;
        }

        // Return converted hour + minutes/seconds
        return hour.ToString("D2") + s.Substring(2, 6);
    }
}

class Solution
{
    /// <summary>
    /// Program entry point.
    /// Reads input, converts time, writes result.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(
            Environment.GetEnvironmentVariable("OUTPUT_PATH"), true
        );

        // Read input time string
        string s = Console.ReadLine();

        // Convert to 24-hour format
        string result = Result.timeConversion(s);

        // Output result
        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}