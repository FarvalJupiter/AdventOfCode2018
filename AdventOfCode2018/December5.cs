using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    internal class December5
    {
        internal static int FirstPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december5.txt";
            var input = new List<string>();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }
            var inputen = input[0];
            var removed = true;
            int before = 1;
            int after = 0;
            while (before!=after)
            {
                before = inputen.Length;
                removed = false;
                for (var i = 0; i < inputen.Length; i = i + 1)
                {
                    if (i + 1 < inputen.Length)
                    {
                        if ((char.IsUpper(inputen[i]) && char.IsLower(inputen[i + 1])) || (char.IsLower(inputen[i]) && char.IsUpper(inputen[i + 1])))
                        {
                            if (char.ToUpper(inputen[i]) == char.ToUpper(inputen[i + 1]))
                            {
                                inputen =inputen.Remove(i, 2);
                                removed = true;
                            }
                        }
                    }
                }
                after = inputen.Length;
            }
            

            return inputen.Length;
            
        }

        internal static object SecondPart()
        {

            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december5.txt";
            var input = new List<string>();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }
            var inputen = input[0];
            var best = int.MaxValue;
            var allvalues = "abcdefghijklmnopqrstuvwxyz";
        foreach (var remove in allvalues) {

                var inputenToUse = inputen.Replace(char.ToLower(remove).ToString(), "");
                inputenToUse = inputenToUse.Replace(char.ToUpper(remove).ToString(), "");
            int before = 1;
            int after = 0;
            while (before != after)
            {
                before = inputenToUse.Length;
                for (var i = 0; i < inputenToUse.Length; i = i + 1)
                {
                    if (i + 1 < inputenToUse.Length)
                    {
                        if ((char.IsUpper(inputenToUse[i]) && char.IsLower(inputenToUse[i + 1])) || (char.IsLower(inputenToUse[i]) && char.IsUpper(inputenToUse[i + 1])))
                        {
                            if (char.ToUpper(inputenToUse[i]) == char.ToUpper(inputenToUse[i + 1]))
                            {
                                    inputenToUse = inputenToUse.Remove(i, 2);
                            }
                        }
                    }
                }
                after = inputenToUse.Length;
            }
            if (best > inputenToUse.Length)
            {
                best = inputenToUse.Length;
            }
        }
            return best;

        }
    }
}