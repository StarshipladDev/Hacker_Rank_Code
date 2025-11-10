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
    * Provides functionality for printing a right-aligned staircase pattern
    * composed of the '#' character, where each line represents an incremental
    * level of the staircase.
    * </summary>
    *<author>Starshiplad</author>
    *<date>2025-11-10</date>
    */
public static class HashPrinter{
     /**
    * <summary> 
    * Method designed to take a given integer, and print a 'right facing' staircsee of
    * the '#' character, with one layer of '#' for each of the input 'stairLevels'
    *</summary>
    * <returns> 
    * A new-line defined string with incremental '#' and deincremented leading spaces that
    * appears as a staircase made up of '#' characters the height of 'StairLevels'
    *</returns>
    * <param name="stairLevels"> 
    * Int, the levels of '#' characters to print
    *</param>
    *<author>Starshiplad</author>
    *<date>2025-11-10</date>
    */
    public static string PrintStaricase(int stairLevels){
        int spaceNumber = stairLevels;
        string printHashText = "";
        string returnedStaricaseText = "";
        for(int hashCount=1 ; hashCount<= stairLevels; hashCount++){
            spaceNumber = spaceNumber--;
            printHashText = "";
            for(int f =0 ;f< hashCount; f++){
                printHashText += "#";
            }
            returnedStaricaseText += String.Concat(
                printHashText.PadLeft(spaceNumber,' '),
                "\n"
            );
        }
        return returnedStaricaseText;
    }
}
class Result
{
    /**
    * <summary> 
    * Function designed to take a given integer, and print a 'right facing' staircsee of
    * the '#' character, with one layer of '#' for each of the input 'stairLevels'
    *</summary>
    * <param name="n"> 
    * Int, the levels of '#' characters to print
    *</param>
    *<author>Starshiplad</author>
    *<date>2025-11-10</date>
    */
    public static void staircase(int n)
    {
        Console.Write(HashPrinter.PrintStaricase(n));
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        Result.staircase(n);
    }
}
