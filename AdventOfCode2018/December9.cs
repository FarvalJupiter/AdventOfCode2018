using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    internal class December9
    {
        internal static object FirstPart()
        {
            //var players = 30;
            var players = 441;
            var dict = new Dictionary<int, int>();
            for(var i =1; i <= players; i++)
            {
                dict.Add(i, 0);
            }
            var currentPlayer = 1;
            //var lastmarbel = 5807;
            var lastmarbel = 71032;
            var circle = new List<int>();
            var currentmarbel = 0;
            circle.Add(currentmarbel);
            for(var marbel=1; marbel<=lastmarbel; marbel++)
            {
                if (marbel % 23 == 0)
                {
                    dict[currentPlayer] = dict[currentPlayer] + marbel;
                    var indexremove = circle.IndexOf(currentmarbel) - 7;
                    if (indexremove < 0)
                    {
                        indexremove = circle.Count() + indexremove;
                        dict[currentPlayer] = dict[currentPlayer] + circle[indexremove];
                        circle.RemoveAt(indexremove);
                    }
                    else
                    {
                        dict[currentPlayer] = dict[currentPlayer] + circle[indexremove];
                        circle.RemoveAt(indexremove);
                    }
                    currentmarbel = circle[indexremove];
                }
                else
                {
                    var index = circle.IndexOf(currentmarbel) + 2;
                    if (index == circle.Count())
                    {
                        circle.Add(marbel);
                    }
                    else if (index > circle.Count())
                    {
                        index = 1;
                        circle.Insert(index, marbel);

                    }
                    else
                    {
                        circle.Insert(index, marbel);
                    }

                    currentmarbel = marbel;
                }
                if (currentPlayer == players) {
                    currentPlayer = 1;
                }
                else {

                    currentPlayer++;
                }
            }
            var maxPoints = 0;
            foreach(var di in dict)
            {
                if(di.Value > maxPoints)
                {
                    maxPoints = di.Value;
                }
            }
            return maxPoints;

        }



        internal static object SecondPart()
        {
            //var players = 30;
            var players = 441;
            var dict = new Dictionary<int, Int64>();
            for (var i = 1; i <= players; i++)
            {
                dict.Add(i, 0);
            }
            var currentPlayer = 1;
            //var lastmarbel = 5807;
            var lastmarbel = 7103200;
            var circle = new List<int>();
            var currentmarbel = 0;
            circle.Add(currentmarbel);
            for (var marbel = 1; marbel <= lastmarbel; marbel++)
            {
                if (marbel % 23 == 0)
                {
                    dict[currentPlayer] = Int64.Parse(dict[currentPlayer].ToString() + marbel.ToString());
                    var indexremove = circle.IndexOf(currentmarbel) - 7;
                    if (indexremove < 0)
                    {
                        indexremove = circle.Count() + indexremove;
                        dict[currentPlayer] = Int64.Parse(dict[currentPlayer].ToString() + circle[indexremove].ToString());
                        circle.RemoveAt(indexremove);
                    }
                    else
                    {
                        dict[currentPlayer] = dict[currentPlayer] + circle[indexremove];
                        circle.RemoveAt(indexremove);
                    }
                    currentmarbel = circle[indexremove];
                }
                else
                {
                    var index = circle.IndexOf(currentmarbel) + 2;
                    if (index == circle.Count())
                    {
                        circle.Add(marbel);
                    }
                    else if (index > circle.Count())
                    {
                        index = 1;
                        circle.Insert(index, marbel);

                    }
                    else
                    {
                        circle.Insert(index, marbel);
                    }

                    currentmarbel = marbel;
                }
                if (currentPlayer == players)
                {
                    currentPlayer = 1;
                }
                else
                {

                    currentPlayer++;
                }
            }
            var maxPoints = Int64.MinValue;
            foreach (var di in dict)
            {
                if (di.Value > maxPoints)
                {
                    maxPoints = di.Value;
                }
            }
            return maxPoints;

        }
    }
}