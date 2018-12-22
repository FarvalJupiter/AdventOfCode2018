using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    internal class December6
    {
        internal static int FirstPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december6.txt";
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
            var nummer = 0;
            var maxx = 0;
            var minx = int.MaxValue;
            var miny = int.MaxValue;
            var maxy = 0;
            foreach(var inp in input)
            {
                var split = inp.Split(',');
                var x = int.Parse(split[0]);
                var y = int.Parse(split[1].Replace(" ", ""));
                dict.Add(new Tuple<int, int>(x, y), nummer);
                if (x > maxx)
                {
                    maxx = x;
                }
                if (y > maxy)
                {
                    maxy = y;
                }
                if (x < minx)
                {
                    minx = x;
                }
                if (y < miny)
                {
                    miny = y;
                }
                nummer++;
            }

            var newdict = new Dictionary<int, int>();
            var tupp = new List<Tuple<int, int>>();
            var dontallowed = new List<int>();
            for (int ix=minx; ix <= maxx; ix++)
            {
                for (int iy=minx; iy <= maxy; iy++)
                {
                    var tempdict = new Dictionary<int, int>();
                    var shortestdistance = int.MaxValue;
                    foreach(var di in dict)
                    {
                        var x = 0;
                        var y = 0;

                            x=Math.Abs(di.Key.Item1 - ix);
 
                            y = Math.Abs(di.Key.Item2 - iy);

                        if(shortestdistance >= x + y)
                        {
                            shortestdistance = x + y;
                            tempdict.Add(di.Value, shortestdistance);
                        }
                    }
                    var num = int.MaxValue;
                    if (tempdict.Count() > 1)
                    {
                        var ordertempdict = tempdict.OrderBy(t => t.Value);
                        if (ordertempdict.First().Value != ordertempdict.ToList()[1].Value)
                        {
                            num = ordertempdict.First().Key;
                        }
                    }
                    else
                    {
                        num = tempdict.First().Key;
                    }
                    if (iy == miny || iy == maxy || ix == maxx || ix == minx)
                    {
                        if (!dontallowed.Contains(num))
                        {
                            dontallowed.Add(num);
                        }
                    }
                    if (num != int.MaxValue)
                    {
                        if (newdict.ContainsKey(num))
                        {
                            newdict[num] = newdict[num] + 1;
                        }
                        else
                        {
                            newdict.Add(num, 1);
                        }
                    }

                }
            }
            foreach (var dont in dontallowed) {
                if (newdict.ContainsKey(dont))
                {
                    newdict.Remove(dont);
                }
                    }

            var test = newdict.OrderByDescending(d => d.Value);

            return test.First().Value;
            
        }

        internal static object SecondPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december6.txt";
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
            var nummer = 0;
            var maxx = 0;
            var minx = int.MaxValue;
            var miny = int.MaxValue;
            var maxy = 0;
            foreach (var inp in input)
            {
                var split = inp.Split(',');
                var x = int.Parse(split[0]);
                var y = int.Parse(split[1].Replace(" ", ""));
                dict.Add(new Tuple<int, int>(x, y), nummer);
                if (x > maxx)
                {
                    maxx = x;
                }
                if (y > maxy)
                {
                    maxy = y;
                }
                if (x < minx)
                {
                    minx = x;
                }
                if (y < miny)
                {
                    miny = y;
                }
                nummer++;
            }

            var sum = 0;
            for (int ix = minx; ix <= maxx; ix++)
            {
                for (int iy = minx; iy <= maxy; iy++)
                {
                    var distance = 0;
                    foreach (var di in dict)
                    {
                        var x = 0;
                        var y = 0;

                        x = Math.Abs(di.Key.Item1 - ix);

                        y = Math.Abs(di.Key.Item2 - iy);

                        distance = distance + x + y;
                    }
                    if (distance < 10000)
                    {
                        sum++;
                    }

                }
            }
            

            return sum;

        }
    }
}