using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string inputString = "DOTNET TRAINING";

        Dictionary<char, int> letterCounts = CountLetterOccurrences(inputString);
        Console.WriteLine("Letter occurrences in the string:");
        foreach (var pair in letterCounts)
        {
            Console.WriteLine("'" + pair.Key + "' occurs " + pair.Value + " time(s)");
        }
    }

    public static Dictionary<char, int> CountLetterOccurrences(string input)
    {
        Dictionary<char, int> letterCounts = new Dictionary<char, int>();

        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                char lowercaseChar = char.ToLower(c);

                if (letterCounts.ContainsKey(lowercaseChar))
                {
                    letterCounts[lowercaseChar]++;
                }
                else
                {
                    letterCounts[lowercaseChar] = 1;
                }
            }
        }

        return letterCounts;
    }
}

