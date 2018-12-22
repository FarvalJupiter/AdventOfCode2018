using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    internal class December7
    {
        internal static object FirstPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december7.txt";
            var input = new List<string>();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }

            var xberoendavyz = new Dictionary<string, List<string>>();
            var yzberoendeavx = new Dictionary<string, List<string>>();
            var allletter = new List<string>();
            foreach(var inp in input)
            {
                var listin = inp.Split(' ');
                var first = listin[1];
                var second = listin[7];
                if (!allletter.Contains(first))
                {
                    allletter.Add(first);
                }
                if (xberoendavyz.ContainsKey(second))
                {
                    xberoendavyz[second].Add(first);
                }
                else
                {
                    xberoendavyz.Add(second, new List<string>() { first });
                }
                if (yzberoendeavx.ContainsKey(first))
                {
                    yzberoendeavx[first].Add(second);
                }
                else
                {
                    yzberoendeavx.Add(first, new List<string>() { second });
                }
            }

            var possibleletter = allletter.Where(l => !xberoendavyz.ContainsKey(l)).OrderBy(a => a).ToList();
            var aktuelbokstav = possibleletter.First();
            possibleletter.Remove(aktuelbokstav);
            var way = new List<string>();
            way.Add(aktuelbokstav);
            while (xberoendavyz.Count()>0)
            {
                foreach(var ind in xberoendavyz)
                {
                    if (ind.Value.Contains(aktuelbokstav))
                    {
                        ind.Value.Remove(aktuelbokstav);
                    }
                    if (ind.Value.Count() == 0 && !possibleletter.Contains(ind.Key))
                    {
                        possibleletter.Add(ind.Key);
                    }
                }

                possibleletter = possibleletter.OrderBy(a => a).ToList();
                aktuelbokstav = possibleletter.First();
                xberoendavyz.Remove(aktuelbokstav);
                possibleletter.Remove(aktuelbokstav);
                way.Add(aktuelbokstav);
            }
            return string.Join("",way);

        }

        internal static object SecondPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december7.txt";
            var input = new List<string>();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }

            var xberoendavyz = new Dictionary<string, List<string>>();
            var yzberoendeavx = new Dictionary<string, List<string>>();
            var allletter = new List<string>();
            foreach (var inp in input)
            {
                var listin = inp.Split(' ');
                var first = listin[1];
                var second = listin[7];
                if (!allletter.Contains(first))
                {
                    allletter.Add(first);
                }
                if (xberoendavyz.ContainsKey(second))
                {
                    xberoendavyz[second].Add(first);
                }
                else
                {
                    xberoendavyz.Add(second, new List<string>() { first });
                }
                if (yzberoendeavx.ContainsKey(first))
                {
                    yzberoendeavx[first].Add(second);
                }
                else
                {
                    yzberoendeavx.Add(first, new List<string>() { second });
                }
            }

            var dictTime = new Dictionary<string, int>();
            //var temptime = 1;
            var temptime = 61;
            var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            foreach(var letter in letters)
            {
                dictTime.Add(letter.ToString(), temptime);
                temptime++;
            }
            var possibleletter = allletter.Where(l => !xberoendavyz.ContainsKey(l)).OrderBy(a => a).ToList();
            var aktuelbokstav = possibleletter.First();
            possibleletter.Remove(aktuelbokstav);
            var time = 0;
            var workers = new List<Tuple<string, int>>();
            workers.Add(new Tuple<string, int>(aktuelbokstav, dictTime[aktuelbokstav]));
            workers.Add(new Tuple<string, int>(aktuelbokstav, dictTime[aktuelbokstav]));

            foreach (var ind in xberoendavyz)
            {
                if (ind.Value.Contains(aktuelbokstav))
                {
                    ind.Value.Remove(aktuelbokstav);
                }
            }
            xberoendavyz.Remove(aktuelbokstav);

            aktuelbokstav = possibleletter.First();
            possibleletter.Remove(aktuelbokstav);

            workers.Add(new Tuple<string, int>(aktuelbokstav, dictTime[aktuelbokstav]));
            foreach (var ind in xberoendavyz)
            {
                if (ind.Value.Contains(aktuelbokstav))
                {
                    ind.Value.Remove(aktuelbokstav);
                }
            }
            xberoendavyz.Remove(aktuelbokstav);
            aktuelbokstav = possibleletter.First();
            possibleletter.Remove(aktuelbokstav);
            workers.Add(new Tuple<string, int>(aktuelbokstav, dictTime[aktuelbokstav]));
            foreach (var ind in xberoendavyz)
            {
                if (ind.Value.Contains(aktuelbokstav))
                {
                    ind.Value.Remove(aktuelbokstav);
                }
            }
            xberoendavyz.Remove(aktuelbokstav);
            aktuelbokstav = possibleletter.First();
            possibleletter.Remove(aktuelbokstav);
            workers.Add(new Tuple<string, int>(aktuelbokstav, dictTime[aktuelbokstav]));
            foreach (var ind in xberoendavyz)
            {
                if (ind.Value.Contains(aktuelbokstav))
                {
                    ind.Value.Remove(aktuelbokstav);
                }
            }
            xberoendavyz.Remove(aktuelbokstav);
            bool force = false;

            while (xberoendavyz.Count() > 0)
            {
                while (workers.Where(w=>w.Item2==0).Count() <= 0 || force)
                {
                    force = false;
                    for (var i = 0; i < workers.Count(); i++)
                    {
                        if (workers[i].Item2 != 0)
                        {
                            workers[i] = new Tuple<string, int>(workers[i].Item1, workers[i].Item2 - 1);
                        }
                    }
                    time++;
                }
                var indexs = new List<int>();
                foreach (var work in workers.Where(w => w.Item2 == 0))
                {
                    var index = workers.FindIndex(w => work== w);
                    indexs.Add(index);

                }
                foreach (var index in indexs)
                {
                    var lettertoremove = workers[index].Item1;
                    foreach (var ind in xberoendavyz)
                    {
                        if (ind.Value.Contains(lettertoremove))
                        {
                            ind.Value.Remove(lettertoremove);
                        }
                    }
                    foreach (var ind in xberoendavyz)
                    {
                        if (ind.Value.Count() == 0 && !possibleletter.Contains(ind.Key))
                        {
                            possibleletter.Add(ind.Key);
                        }
                    }
                }
                foreach (var index in indexs)
                {
                    possibleletter = possibleletter.OrderBy(a => a).ToList();
                    if (possibleletter.Count() > 0)
                    {
                        aktuelbokstav = possibleletter.First();
                        xberoendavyz.Remove(aktuelbokstav);
                        possibleletter.Remove(aktuelbokstav);

                        workers[index] = new Tuple<string, int>(aktuelbokstav, dictTime[aktuelbokstav]);
                    }
                    else
                    {
                        force = true;
                    }
                }
            }
            while (workers.Where(w => w.Item2 != 0).Count() >0 )
            {
                for (var i = 0; i < workers.Count(); i++)
                {
                    if (workers[i].Item2 != 0)
                    {
                        workers[i] = new Tuple<string, int>(workers[i].Item1, workers[i].Item2 - 1);
                    }
                }
                time++;
            }

            return time;

        }
    }
}