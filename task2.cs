using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ConsoleAppTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<float> termsList = new List<float>();

            string tops = args[0].ToString();
            string dots = args[1].ToString();

            string[] readText = System.IO.File.ReadAllLines(tops);
            foreach (string s in readText)
            {
                var v = s.Split(new char[] { ' ', '\t' }, 2, StringSplitOptions.RemoveEmptyEntries);
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(tops, true))
                {
                    termsList.Add((float)Convert.ToDouble(v[0].Trim()));
                    termsList.Add((float)Convert.ToDouble(v[1].Trim()));
                }
            }

            Point[] poly = new Point[] { new Point(termsList[0], termsList[1]), new Point(termsList[2], termsList[3]), new Point(termsList[4], termsList[5]), new Point(termsList[6], termsList[7]) };

            string[] readText2 = System.IO.File.ReadAllLines(dots);
            foreach (string s in readText2)
            {
                var v = s.Split(new char[] { ' ', '\t' }, 2, StringSplitOptions.RemoveEmptyEntries);
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(tops, true))
                {
                    float x = (float)Convert.ToDouble(v[0].Trim()), y = (float)Convert.ToDouble(v[1].Trim());
                    int ans = -1;

                    for (int i = 0; i < 7; i = i + 2)
                    {
                        if (x == termsList[i] && y == termsList[i + 1])
                        {
                            ans = 0;
                            Console.WriteLine(0);
                        }
                    }

                    if (ans != 0)
                    {
                        if (InPoly_reb(poly, new Point(x, y)) == true)
                        {
                            ans = 1;
                            Console.WriteLine(1);
                        }
                    }

                    if (ans != 0 && ans != 1)
                    {
                        if (InPoly_ins(poly, new Point(x, y)) == true)
                        {
                            ans = 2;
                            Console.WriteLine(2);
                        }
                    }

                    if (ans != 0 && ans != 1 && ans != 2)
                    {
                        Console.WriteLine(3);
                    }
                }
            }
            Console.ReadKey();
        }

        private static float Rotate(Point a, Point b, Point c)
        {
            return (b.X - a.X) * (c.Y - b.Y) - (b.Y - a.Y) * (c.X - b.X);
        }

        private static bool Intersect(Point a, Point b, Point c, Point d)
        {
            return Rotate(a, b, c) * Rotate(a, b, d) <= 0 & Rotate(c, d, a) * Rotate(c, d, b) < 0;
        }


        private static bool InPoly_reb(Point[] poly, Point pt)
        {
            int n = poly.Length;
            float x, y;
            if ((((x = Rotate(poly[0], poly[1], pt)) < 0) || (y = Rotate(poly[0], poly[n - 1], pt)) < 0))
                return false;
            int p = 1,
                r = n - 1;
            while (r - p > 1)
            {
                int q = (p + r) / 2;
                if (Rotate(poly[0], poly[q], pt) < 0)
                    r = q;
                else
                    p = q;
            }

            return !Intersect(poly[0], pt, poly[p], poly[r]);
        }

        private static bool InPoly_ins(Point[] poly, Point pt)
        {
            int n = poly.Length;
            float x, y;
            if (((x = Rotate(poly[0], poly[1], pt)) >= 0 || (y = Rotate(poly[0], poly[n - 1], pt)) <= 0))
                return false;
            int p = 1,
                r = n - 1;
            while (r - p > 1)
            {
                int q = (p + r) / 2;
                if (Rotate(poly[0], poly[q], pt) < 0)
                    r = q;
                else
                    p = q;
            }

            return !Intersect(poly[0], pt, poly[p], poly[r]);
        }

    }

    class Point
    {
        public float X, Y;

        public Point()
        {
            X = Y = 0;
        }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
