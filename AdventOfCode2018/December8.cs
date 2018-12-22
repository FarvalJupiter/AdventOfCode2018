using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    internal class December8
    {
        internal static object FirstPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december8.txt";
            var input = new List<string>();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }
            var inputlist = input.First().Split(' ').ToList();
            var metadata = new List<int>();
            Recursive1(inputlist, metadata);

            var sum = 0;
            foreach(var val in metadata)
            {
                sum = sum + val;
            }
            return sum;

        }


        private static void Recursive1(List<string> intputlist, List<int> metadata)
        {
            var antalbarn = int.Parse(intputlist.First());
            intputlist.RemoveAt(0);
            var antalmetadata = int.Parse(intputlist.First());
            intputlist.RemoveAt(0);
            while (antalbarn > 0)
            {
                Recursive1(intputlist, metadata);
                antalbarn--;
            }
            for (var i = 0; i < antalmetadata; i++)
            {
                metadata.Add(int.Parse(intputlist.First()));
                intputlist.RemoveAt(0);

            }
        }

        private static int Recursive2(List<string> intputlist, List<int> metadata)
        {
            var antalbarn = int.Parse(intputlist.First());
            intputlist.RemoveAt(0);
            bool harbarn = antalbarn > 0;
            var antalmetadata = int.Parse(intputlist.First());
            intputlist.RemoveAt(0);
            var list = new List<int>();
            while (antalbarn > 0)
            {
                list.Add(Recursive2(intputlist, metadata));
                antalbarn--;
            }
            if (!harbarn)
            {
                var summa = 0;
                for (var i = 0; i < antalmetadata; i++)
                {
                    summa=summa+int.Parse(intputlist.First());
                    intputlist.RemoveAt(0);
                }
                return summa;
            }
            else
            {
                var summa = 0;
                for (var i = 0; i < antalmetadata; i++)
                {
                    if ((int.Parse(intputlist.First()) - 1) < list.Count()) {
                        summa = summa + list[int.Parse(intputlist.First()) - 1];
                    }
                    intputlist.RemoveAt(0);

                }
                return summa;
            }
        }

        internal static object SecondPart()
        {
            var fileName = @"C:\Users\KarroJonas\Documents\AdventOfCode2018\december8.txt";
            var input = new List<string>();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }
            var inputlist = input.First().Split(' ').ToList();
            var metadata = new List<int>();
            var sum =Recursive2(inputlist, metadata);

            return sum;

        }
    }
}