using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    internal class December3
    {
        internal static int FirstPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december3.txt";
            var input = new List<string>();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }

            var dict = new Dictionary<Tuple<int, int>, int>();
            foreach(var row in input)
            {
                //#1 @ 56,249: 24x16
                var values = row.Split(' ');
                var xorigin = int.Parse(values[2].Split(',')[0]);
                var yorigin = int.Parse(values[2].Split(',')[1].Split(':')[0]);
                for (var i = 0; i < int.Parse(values[3].Split('x')[0]); i++)
                {
                    var x = xorigin + i;
                    for (var j = 0; j < int.Parse(values[3].Split('x')[1]); j++)
                    {
                        var y = yorigin + j;
                        if (dict.ContainsKey(new Tuple<int, int>(x, y)))
                        {
                            dict[new Tuple<int, int>(x, y)] = dict[new Tuple<int, int>(x, y)] + 1;
                        }
                        else
                        {
                            dict.Add(new Tuple<int, int>(x, y), 1);

                        }
                    }
                }

            }
            var totaloverlap = 0;
            foreach(var alldict in dict)
            {
                if(alldict.Value > 1)
                {
                    totaloverlap++;
                }
            }
            return totaloverlap;
        }

        internal static object SecondPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december3.txt";
            var input = new List<string>();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }

            var dict = new Dictionary<Tuple<int, int>, string>();
            var allId = new List<int>();
            foreach (var row in input)
            {
                //#1 @ 56,249: 24x16
                var values = row.Split(' ');
                var xorigin = int.Parse(values[2].Split(',')[0]);
                var yorigin = int.Parse(values[2].Split(',')[1].Split(':')[0]);
                for (var i = 0; i < int.Parse(values[3].Split('x')[0]); i++)
                {
                    var x = xorigin + i;
                    for (var j = 0; j < int.Parse(values[3].Split('x')[1]); j++)
                    {
                        var y = yorigin + j;
                        if (dict.ContainsKey(new Tuple<int, int>(x, y)))
                        {
                            dict[new Tuple<int, int>(x, y)] = dict[new Tuple<int, int>(x, y)] + ','+ values[0].Split('#')[1];
                        }
                        else
                        {
                            dict.Add(new Tuple<int, int>(x, y), values[0].Split('#')[1]);

                        }
                    }
                    
                }
                allId.Add(int.Parse(values[0].Split('#')[1]));

            }
            var totaloverlap = 0;
            foreach (var alldict in dict)
            {
                if (alldict.Value.Contains(','))
                {
                    foreach (var val in alldict.Value.Split(','))
                    {
                        allId.Remove(int.Parse(val));
                    }
                }
            }
            return allId.First();


        }
    }
}