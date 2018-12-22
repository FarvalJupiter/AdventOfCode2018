using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    internal class December12
    {
        internal static object FirstPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december12.txt";
            var input = new List<string>();
            var initialstate =  "#......##...#.#.###.#.##..##.#.....##....#.#.##.##.#..#.##........####.###.###.##..#....#...###.##";//"#..#.#..##......###...###";
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }
            var dictstate = new Dictionary<int, bool>();
            var count = 0;
            foreach(var state in initialstate)
            {
                if (state == '.')
                {
                    dictstate.Add(count, false);
                }
                else
                {
                    dictstate.Add(count, true);
                }
                count++;
            }
            dictstate.Add(-1, false);
            dictstate.Add(-2, false);
            dictstate.Add(dictstate.OrderBy(d=>d.Key).Last().Key+1, false);
            dictstate.Add(dictstate.OrderBy(d => d.Key).Last().Key + 1, false);

            var converter = new Dictionary<Tuple<bool, bool, bool, bool, bool>, bool>();
            foreach(var inp in input)
            {
                var splitted = inp.Split(" => ");
                var state = splitted[0];
                var end = splitted[1];
                var tuple = new Tuple<bool, bool, bool, bool, bool>(state[0]=='.'?false:true, state[1] == '.' ? false : true, state[2] == '.' ? false : true, state[3] == '.' ? false : true, state[4] == '.' ? false : true);
                converter.Add(tuple, end == "." ? false : true);
            }

            var listdict = new List<Dictionary<int, bool>>();
            listdict.Add(dictstate);
            for (var year=1; year <= 20; year++)
            {
                //var consolelog = "";
                //foreach(var f in dictstate.OrderBy(d=>d.Key))
                //{
                //    if (f.Value)
                //    {
                //        consolelog = consolelog + "#";
                //    }
                //    else {
                //        consolelog = consolelog + ".";
                //    }
                //}
                //Console.WriteLine(consolelog);
                var tempdict = new Dictionary<int, bool>();
                foreach (var di in dictstate)
                {
                    if(year==4 )
                    {

                    }
                    var l2 = dictstate.ContainsKey(di.Key - 2) ? dictstate[(di.Key - 2)] : false;
                    var l1 = dictstate.ContainsKey(di.Key - 1) ? dictstate[(di.Key - 1)] : false;
                    var x = di.Value;
                    var r1 = dictstate.ContainsKey(di.Key + 1) ? dictstate[(di.Key + 1)] : false;
                    var r2 = dictstate.ContainsKey(di.Key + 2) ? dictstate[(di.Key + 2)] : false;
                    var tup = new Tuple<bool, bool, bool, bool, bool>(l2, l1, x, r1, r2);
                    if (converter.ContainsKey(tup))
                    {
                        tempdict.Add(di.Key,converter[tup]);
                    }
                    else
                    {
                        tempdict.Add(di.Key,false);
                    }
                }
                dictstate = tempdict.ToDictionary(entry => entry.Key,
                                               entry => entry.Value);
                dictstate.Add(dictstate.OrderBy(d => d.Key).First().Key -1, false);
                dictstate.Add(dictstate.OrderBy(d => d.Key).First().Key - 1, false);
                dictstate.Add(dictstate.OrderBy(d => d.Key).Last().Key + 1, false);
                dictstate.Add(dictstate.OrderBy(d => d.Key).Last().Key + 1, false);
                listdict.Add(dictstate);
            }

            var ot = 0;
            foreach(var i in listdict.Last())
            {
                if (i.Value)
                {
                    ot = ot + i.Key;
                }
            }
            return ot;
           
        }



        internal static object SecondPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december12.txt";
            var input = new List<string>();
            var initialstate = "#......##...#.#.###.#.##..##.#.....##....#.#.##.##.#..#.##........####.###.###.##..#....#...###.##";//"#..#.#..##......###...###";
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }
            var dictstate = new Dictionary<Int64, bool>();
            var count = 0;
            foreach (var state in initialstate)
            {
                if (state == '.')
                {
                    dictstate.Add(count, false);
                }
                else
                {
                    dictstate.Add(count, true);
                }
                count++;
            }
            dictstate.Add(-1, false);
            dictstate.Add(-2, false);
            dictstate.Add(dictstate.OrderBy(d => d.Key).Last().Key + 1, false);
            dictstate.Add(dictstate.OrderBy(d => d.Key).Last().Key + 1, false);

            var converter = new Dictionary<Tuple<bool, bool, bool, bool, bool>, bool>();
            foreach (var inp in input)
            {
                var splitted = inp.Split(" => ");
                var state = splitted[0];
                var end = splitted[1];
                var tuple = new Tuple<bool, bool, bool, bool, bool>(state[0] == '.' ? false : true, state[1] == '.' ? false : true, state[2] == '.' ? false : true, state[3] == '.' ? false : true, state[4] == '.' ? false : true);
                converter.Add(tuple, end == "." ? false : true);
            }

            var listdict = new List<Dictionary<Int64, bool>>();
            listdict.Add(dictstate);
            for (Int64 year = 1; year <= 200; year++) //50000000000
            {
               // var tempdict = new Dictionary<Int64, bool>();
               var tempdict= dictstate.ToDictionary(entry => entry.Key,
                                               entry => entry.Value);
                foreach (var di in dictstate)
                {
                    if (year == 4)
                    {

                    }
                    var l2 = dictstate.ContainsKey(di.Key - 2) ? dictstate[(di.Key - 2)] : false;
                    var l1 = dictstate.ContainsKey(di.Key - 1) ? dictstate[(di.Key - 1)] : false;
                    var x = di.Value;
                    var r1 = dictstate.ContainsKey(di.Key + 1) ? dictstate[(di.Key + 1)] : false;
                    var r2 = dictstate.ContainsKey(di.Key + 2) ? dictstate[(di.Key + 2)] : false;
                    var tup = new Tuple<bool, bool, bool, bool, bool>(l2, l1, x, r1, r2);
                    if (converter.ContainsKey(tup))
                    {
                        tempdict[di.Key] = converter[tup];
                        //tempdict.Add(di.Key, converter[tup]);
                    }
                    else
                    {
                        tempdict[di.Key] = false;

                        //tempdict.Add(di.Key, false);
                    }
                }
                dictstate = tempdict.ToDictionary(entry => entry.Key, entry => entry.Value);
                var sorted = dictstate.OrderBy(d => d.Key);
                dictstate.Add(sorted.First().Key - 1, false);
                dictstate.Add(sorted.First().Key - 1, false);
                dictstate.Add(sorted.Last().Key + 1, false);
                dictstate.Add(sorted.Last().Key + 1, false);
                listdict.Add(dictstate);
                //Int64 ot = 0;
                //foreach (var i in dictstate)
                //{
                //    if (i.Value)
                //    {
                //        ot = ot + i.Key;
                //    }
                //}
                //Console.WriteLine(ot);
            }

            Int64 ot = 0;
            foreach (var i in listdict.Last())
            {
                if (i.Value)
                {
                    ot = ot + i.Key;
                }
            }
            return ot+(50000000000-200)*75;
        }
    }
}