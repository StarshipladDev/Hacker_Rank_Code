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

///<summary>
///Defines the 3 states an integer can be for identifying it as a ratio of a total int set
///</summary>
///<date>
///05/11/2025
///</date>
///<author>
///Starshipladdev
///</author>

public enum RatioTypes{
    Negatives,
    Zeros,
    Positives
}

///<summary>
/// Captures counts of signs and zeros in an int array, as well as utility functions to add a new
/// int into captured values, as well as return a ratio of the total a certain sign makes up
///</summary>
///<author>
///Starshipladdev
///</author>
///</summary>
///<date>
///05/11/2025
///</date>
public class Ratios{
    public int negatives,zeros,positives;
    public decimal total{
        get => negatives + zeros + positives;
    }
    public Ratios(){
        negatives = zeros = positives = 0;
    }
    ///<summary>
    /// Function to add another int to values currently stored within the class
    ///</summary>
    ///<param name="inputInt">
    /// inputInt is an integer to add to the currently captured values in the class
    ///</param>
    ///<author>
    ///Starshipladdev
    ///</author>
    public void addNumber(int inputInt){
        if(inputInt != 0){
            if (inputInt > 0){
                this.positives++;
            }
            else{
                this.negatives++;
            }
        }
        else{
            this.zeros++;
        }
    }
    ///<summary>
    /// Function to get a 6 point decimal value representing the ratio of the total ints
    /// provided to this class that are of a given sign type.
    ///</summary>
    ///<param name="ratioType">
    /// ratioType which integer sign (or zero) the ratio should be for compared to totals
    ///</param>
    ///<return>
    /// return the string version of a 6decimal accuracy representation of the ratio of all ints added 
    ////via <see cref="Ratios.addNumber"/>
    ///</return>
    ///<author>
    ///Starshipladdev
    ///</author>
    ///<date>
    ///05/11/2025
    ///</date>
    public string getDecimals (RatioTypes ratioType){
        decimal returnRatio = 0;
        if(this.total == 0){
            return 0.ToString("0.000000");
        }
        switch(ratioType){
            case RatioTypes.Negatives:
                returnRatio = (this.negatives / this.total);
                break;
            case RatioTypes.Zeros:
                returnRatio = (this.zeros / this.total);
                break;
            case RatioTypes.Positives:
                returnRatio = (this.positives / this.total);
                break;
            default:
                returnRatio = 0;
                break;
        }
        return returnRatio.ToString("0.000000");
    }
}

class Result
{
    //<summary>
    /// static function to print the 6 decimal ratios of a given order of signs (or 0s) in a given array.
    ///</summary>
    ///<param name="arr">
    /// a list of integers
    ///</param>
    ///<param name="typeOrder">
    /// a list of signTypes <see cref="Ratios.RatioTypes"/> in order of how they should be printed
    ///</param>
    ///<author>
    ///Starshipladdev
    ///</author>
    ///<date>
    ///05/11/2025
    ///</date>
    public static void plusMinus(List<int> arr, List<RatioTypes> typeOrder)
    {
        if(typeOrder.Count() != 3){
            throw new InvalidOperationException("Result requires exactly 3 typeOrders");
        }
        Ratios ratios = new Ratios();
        for(int i =0; i< arr.Count(); i++){
            ratios.addNumber(arr[i]);
        }
        for(int i =0; i< typeOrder.Count(); i++){
            Console.WriteLine($"{ratios?.getDecimals(typeOrder[i])}");
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr,new List<RatioTypes>{RatioTypes.Positives,RatioTypes.Negatives,RatioTypes.Zeros});
    }
}
