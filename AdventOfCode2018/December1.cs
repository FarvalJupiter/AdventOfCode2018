using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2018
{
    internal class December1
    {
        internal static int FirstPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december1.txt";
            var input = new List<string>();
            int start = 0;
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }
            
            foreach(var val in input)
            {
                start += Int32.Parse(val);
            }
            return start;
        }

        internal static object SecondPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december1.txt";
            var input = new List<string>();
            int start = 0;
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }
            var allValues = new List<int>();
            allValues.Add(start);
            while (true)
            {
                foreach (var val in input)
                {
                    start += Int32.Parse(val);
                    if (!allValues.Contains(start))
                    {
                        allValues.Add(start);
                    }
                    else
                    {
                        return start;
                    }
                }
            }
        }
    }
}