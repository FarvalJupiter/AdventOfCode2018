using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    internal class December4
    {
        internal static int FirstPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december4.txt";
            var input = new List<string>();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }

            var list = new List<Tuple<DateTime, string>>();
            foreach(var inp in input)
            {
                var tup = new Tuple<DateTime, string>(DateTime.Parse(inp.Split(']')[0].Replace("[", "")), inp.Split(']')[1]);
                list.Add(tup);
            }

            var ordTup = list.OrderBy(l => l.Item1);

            var guardid = string.Empty;
            DateTime asleep = DateTime.Now;
            DateTime awake = DateTime.Now;
            var dictionary = new Dictionary<Tuple<string, int>, int>();
            foreach(var tup in ordTup)
            {
                if (tup.Item2.Contains('#'))
                {
                    guardid= tup.Item2.Split(' ')[2].Replace("#","");
                }
                else if(tup.Item2.Contains("falls asleep"))
                {
                    asleep = tup.Item1;
                }
                else if(tup.Item2.Contains("wakes up"))
                {
                    awake = tup.Item1;
                    for (var i = asleep.TimeOfDay.Minutes; i < awake.TimeOfDay.Minutes; i++)
                    {
                        if(dictionary.ContainsKey(new Tuple<string, int>(guardid, i)))
                        {
                            dictionary[new Tuple<string, int>(guardid, i)] = dictionary[new Tuple<string, int>(guardid, i)]+1;
                        }
                        else
                        {
                            dictionary.Add(new Tuple<string, int>(guardid, i), 1);
                        }
                    }
                }
                
            }

            var group=dictionary.GroupBy(d => d.Key.Item1).ToDictionary(gro => gro.Key,
                     gro => gro.ToDictionary(pair => pair.Key,
                                                 pair => pair.Value));
            var max = 0;
            var mostasleep = group.First();
            foreach (var gr in group)
            {
                var total = 0;
                foreach(var d in gr.Value)
                {
                    total = total + d.Value;
                }
                if(total > max)
                {
                    max = total;
                    mostasleep = gr;
                }
               
            }
            var mostminute = mostasleep.Value.OrderByDescending(m => m.Value);
            return int.Parse(mostasleep.Key)* mostminute.First().Key.Item2;
            
        }

        internal static object SecondPart()
        {

            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december4.txt";
            var input = new List<string>();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }

            var list = new List<Tuple<DateTime, string>>();
            foreach (var inp in input)
            {
                var tup = new Tuple<DateTime, string>(DateTime.Parse(inp.Split(']')[0].Replace("[", "")), inp.Split(']')[1]);
                list.Add(tup);
            }

            var ordTup = list.OrderBy(l => l.Item1);

            var guardid = string.Empty;
            DateTime asleep = DateTime.Now;
            DateTime awake = DateTime.Now;
            var dictionary = new Dictionary<Tuple<string, int>, int>();
            foreach (var tup in ordTup)
            {
                if (tup.Item2.Contains('#'))
                {
                    guardid = tup.Item2.Split(' ')[2].Replace("#", "");
                }
                else if (tup.Item2.Contains("falls asleep"))
                {
                    asleep = tup.Item1;
                }
                else if (tup.Item2.Contains("wakes up"))
                {
                    awake = tup.Item1;
                    for (var i = asleep.TimeOfDay.Minutes; i < awake.TimeOfDay.Minutes; i++)
                    {
                        if (dictionary.ContainsKey(new Tuple<string, int>(guardid, i)))
                        {
                            dictionary[new Tuple<string, int>(guardid, i)] = dictionary[new Tuple<string, int>(guardid, i)] + 1;
                        }
                        else
                        {
                            dictionary.Add(new Tuple<string, int>(guardid, i), 1);
                        }
                    }
                }

            }

            var group = dictionary.GroupBy(d => d.Key.Item1).ToDictionary(gro => gro.Key,
                     gro => gro.ToDictionary(pair => pair.Key,
                                                 pair => pair.Value));
            var max = 0;
            var mostasleep = group.First();
            foreach (var gr in group)
            {
                var fd=gr.Value.OrderByDescending(m => m.Value);
                if (fd.First().Value > max)
                {
                    max = fd.First().Value;
                    mostasleep = gr;
                }

            }
            var mostminute = mostasleep.Value.OrderByDescending(m => m.Value);
            return int.Parse(mostasleep.Key) * mostminute.First().Key.Item2;



        }
    }
}