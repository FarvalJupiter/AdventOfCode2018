using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    internal class December10
    {
        internal static object FirstPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december10.txt";
            var input = new List<string>();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }
            //position=<-20830, -10364> velocity=< 2,  1>
            var list = new List<Tuple<int, int, int, int>>();
            foreach(var inp in input)
            {
                var split = inp.Split(new char[] { '<', '>', ',' });
                var newitem = new Tuple<int, int, int, int>(int.Parse(split[1]), int.Parse(split[2]),int.Parse(split[4]), int.Parse(split[5]));
                if (!list.Contains(newitem) )
                {
                    list.Add(newitem);
                }
                else
                {

                }
            }
            var message = false;
            while (!message)
            {
                for(var i=0; i<list.Count(); i++)
                {
                    list[i] = new Tuple<int, int, int, int>(list[i].Item1 + list[i].Item3, list[i].Item2 + list[i].Item4, list[i].Item3, list[i].Item4);
                }

                var allpoints = list.Count();
                var count = 0;
                for (var i = 0; i < list.Count(); i++)
                {
                    var x = list[i].Item1;
                    var y = list[i].Item2;
                    var select = list.Select(l => new Tuple<int,int>(l.Item1, l.Item2)).ToList();
                    if (select.Contains(new Tuple<int,int>(x-1,y-1)) 
                        || select.Contains(new Tuple<int, int>(x - 1,y))
                        || select.Contains(new Tuple<int,int>(x - 1,y + 1))
                        || select.Contains(new Tuple<int,int>(x ,y - 1))
                        || select.Contains(new Tuple<int,int>(x ,y + 1))
                        || select.Contains(new Tuple<int,int>(x + 1,y - 1))
                        || select.Contains(new Tuple<int,int>(x + 1,y))
                        || select.Contains(new Tuple<int, int>(x + 1,y + 1)))
                    {
                        count++;
                    }
                }

                //var lowestx = list.OrderBy(l => l.Item1).First().Item1;
                //var lowesty = list.OrderBy(l => l.Item2).First().Item2;
                //var highestx = list.OrderByDescending(l => l.Item1).First().Item1;
                //var highesty = list.OrderByDescending(l => l.Item2).First().Item2;

                //for (int x = lowestx; x <= highestx; x++)
                //{
                //    var messagerow = "";
                //    for (int y = lowesty; y <= highesty; y++)
                //    {
                //        var select = list.Select(l => new Tuple<int, int>(l.Item1, l.Item2)).ToList();

                //        if (select.Contains(new Tuple<int,int>(x,y)))
                //        {
                //            messagerow = messagerow + "#";
                //        }
                //        else
                //        {
                //            messagerow = messagerow + ".";

                //        }
                //    }
                //    Console.WriteLine(messagerow);
                //}
                //Console.WriteLine("-------------------------------------------------------------");
                if (count >= allpoints)
                {
                    message = true;
                }
            }
            var lowestx = list.OrderBy(l => l.Item1).First().Item1;
            var lowesty = list.OrderBy(l => l.Item2).First().Item2;
            var highestx = list.OrderByDescending(l => l.Item1).First().Item1;
            var highesty = list.OrderByDescending(l => l.Item2).First().Item2;

            for (int x = lowestx; x <= highestx; x++)
            {
                var messagerow = "";
                for (int y = lowesty; y <= highesty; y++)
                {
                    var select = list.Select(l => new Tuple<int, int>(l.Item1, l.Item2)).ToList();

                    if (select.Contains(new Tuple<int, int>(x, y)))
                    {
                        messagerow = messagerow + "#";
                    }
                    else
                    {
                        messagerow = messagerow + ".";

                    }
                }
                Console.WriteLine(messagerow);
            }
            return 0;
        }



        internal static object SecondPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december10.txt";
            var input = new List<string>();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }
            //position=<-20830, -10364> velocity=< 2,  1>
            var list = new List<Tuple<int, int, int, int>>();
            foreach (var inp in input)
            {
                var split = inp.Split(new char[] { '<', '>', ',' });
                var newitem = new Tuple<int, int, int, int>(int.Parse(split[1]), int.Parse(split[2]), int.Parse(split[4]), int.Parse(split[5]));
                if (!list.Contains(newitem))
                {
                    list.Add(newitem);
                }
                else
                {

                }
            }
            var message = false;
            var seconds = 0;
            while (!message)
            {
                seconds++;
                for (var i = 0; i < list.Count(); i++)
                {
                    list[i] = new Tuple<int, int, int, int>(list[i].Item1 + list[i].Item3, list[i].Item2 + list[i].Item4, list[i].Item3, list[i].Item4);
                }

                var allpoints = list.Count();
                var count = 0;
                for (var i = 0; i < list.Count(); i++)
                {
                    var x = list[i].Item1;
                    var y = list[i].Item2;
                    var select = list.Select(l => new Tuple<int, int>(l.Item1, l.Item2)).ToList();
                    if (select.Contains(new Tuple<int, int>(x - 1, y - 1))
                        || select.Contains(new Tuple<int, int>(x - 1, y))
                        || select.Contains(new Tuple<int, int>(x - 1, y + 1))
                        || select.Contains(new Tuple<int, int>(x, y - 1))
                        || select.Contains(new Tuple<int, int>(x, y + 1))
                        || select.Contains(new Tuple<int, int>(x + 1, y - 1))
                        || select.Contains(new Tuple<int, int>(x + 1, y))
                        || select.Contains(new Tuple<int, int>(x + 1, y + 1)))
                    {
                        count++;
                    }
                }

                
                if (count >= allpoints)
                {
                    message = true;
                }
            }
            
            return seconds;
        }
    }
}