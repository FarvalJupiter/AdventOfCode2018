using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    internal class December2
    {
        internal static int FirstPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december2.txt";
            var input = new List<string>();
            int twice = 0;
            int tripple = 0;
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
                var list = new List<char>();
                foreach(var bokstav in val)
                {
                    list.Add(bokstav);
                }

                var hasTwice = false;
                var hasTripple = false;
                foreach (var bokstav in val)
                {
                    if(list.Count(l => l == bokstav) == 2)
                    {
                        hasTwice = true;
                    }
                    if (list.Count(l => l == bokstav) == 3)
                    {
                        hasTripple = true;
                    }
                }
                if (hasTripple)
                {
                    tripple++;
                }
                if (hasTwice)
                {
                    twice++;
                }

            }
            return twice*tripple;
        }

        internal static object SecondPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december2.txt";
            var input = new List<string>();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }

            var allLista = new List<List<char>>();
            foreach (var val in input)
            {
                var list = new List<char>();
                foreach (var bokstav in val)
                {
                    list.Add(bokstav);
                }
                allLista.Add(list);
            }

            foreach(var li in allLista)
            {
                foreach(var innerlist in allLista)
                {
                    var error = 0;
                    for(var i=0;i<li.Count(); i++)
                    {
                        if (innerlist[i] != li[i])
                        {
                            error++;
                        }
                    }
                    if (error == 1)
                    {
                        var samebokstav = string.Empty;
                        for (var i = 0; i < li.Count(); i++)
                        {
                            if (innerlist[i] == li[i])
                            {
                                samebokstav = samebokstav + li[i];
                            }

                        }
                        return samebokstav;
                    }
                }
            }
            return 0;
        }
    }
}