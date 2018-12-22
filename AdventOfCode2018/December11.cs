using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    internal class December11
    {
        internal static object FirstPart()
        {
            var serialNumber = 6548;
            var dict = new Dictionary<Tuple<int,int>,int>();
            for(var x=1; x <= 300; x++){
                for(var y = 1; y <= 300; y++)
                {
                    var rackid = x + 10;
                    var powerlevel = rackid * y;
                    powerlevel = powerlevel + serialNumber;
                    powerlevel = powerlevel * rackid;
                    var hundreddigit =(powerlevel/100)%10;
                    powerlevel = hundreddigit - 5;
                    dict.Add(new Tuple<int, int>(x, y), powerlevel);
                }
            }
            var maxvalue = 0;
            var xcoord = 0;
            var ycoord = 0;
            for (var x = 1; x <= 300-2; x++)
            {
                for (var y = 1; y <= 300-2; y++)
                {
                    var sum = dict[new Tuple<int, int>(x, y)]
                        + dict[new Tuple<int, int>(x+1, y)]
                        + dict[new Tuple<int, int>(x+2, y)]
                        + dict[new Tuple<int, int>(x+1, y+1)] 
                        + dict[new Tuple<int, int>(x+1, y+2)]
                        + dict[new Tuple<int, int>(x+2, y+1)]
                        + dict[new Tuple<int, int>(x+2, y+2)]
                        + dict[new Tuple<int, int>(x, y+1)]
                        + dict[new Tuple<int, int>(x, y+2)];
                    if (sum > maxvalue)
                    {
                        maxvalue = sum;
                        xcoord = x;
                        ycoord = y;
                    }
                }
            }

                    return new Tuple<int,int>(xcoord, ycoord);

        }



        internal static object SecondPart()
        {
            var serialNumber = 6548;
            var dict = new Dictionary<Tuple<int, int>, int>();
            for (var x = 1; x <= 300; x++)
            {
                for (var y = 1; y <= 300; y++)
                {
                    var rackid = x + 10;
                    var powerlevel = rackid * y;
                    powerlevel = powerlevel + serialNumber;
                    powerlevel = powerlevel * rackid;
                    var hundreddigit = (powerlevel / 100) % 10;
                    powerlevel = hundreddigit - 5;
                    dict.Add(new Tuple<int, int>(x, y), powerlevel);
                }
            }
            var maxvalue = 0;
            var xcoord = 0;
            var ycoord = 0;
            var finalsize = 0;
            for (var size = 1; size <= 300; size++)
            {
                for (var x = 1; x <= 300 - (size-1); x++)
                {
                    for (var y = 1; y <= 300 - (size-1); y++)
                    {
                        var sum = 0;
                        for (var xi = 0; xi <= (size - 1); xi++)
                        {
                            for (var yi = 0; yi <= (size - 1); yi++)
                            {
                                sum = sum+dict[new Tuple<int, int>(x+xi, y+yi)];
                            }
                        }
                        if (sum > maxvalue)
                        {
                            maxvalue = sum;
                            xcoord = x;
                            ycoord = y;
                            finalsize = size;
                        }
                    }
                }
            }

            return new Tuple<int, int, int>(xcoord, ycoord, finalsize);

        }
    }
}