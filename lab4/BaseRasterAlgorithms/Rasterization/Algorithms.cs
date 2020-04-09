using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BaseRasterAlgorithms
{
    class Algorithms
    {
        public static (HashSet<(int, int)>, long) StepByStep(int x1, int y1, int x2, int y2)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            HashSet<(int, int)> points = new HashSet<(int, int)>();

            int startY, endY;
            if (y1 >= y2)
            {
                startY = y2;
                endY = y1;
            }
            else
            {
                startY = y1;
                endY = y2;
            }

            int startX, endX;
            if (x1 > x2)
            {
                startX = x2;
                endX = x1;
            }
            else
            {
                startX = x1;
                endX = x2;
            }

            if (x1 == x2)
            {
                for (int i = startY; i <= endY; i++)
                {
                    points.Add(new ValueTuple<int, int>(x1, i));
                }
            }
            else
            {
                double k = (y1 - y2) * 1.0 / (x1 - x2);
                double b = y1 - k * x1;
                if (Math.Abs(k) >= 1)
                {
                    for (int i = startY; i <= endY; i++)
                    {
                        points.Add(new ValueTuple<int, int>((int)Math.Round((i - b) / k), i));
                    }
                }
                else
                {
                    for (int i = startX; i <= endX; i++)
                    {
                        points.Add(new ValueTuple<int, int>(i, (int)Math.Round(k * i + b)));
                    }
                }
            }

            stopwatch.Stop();

            return (points, stopwatch.ElapsedTicks);
        }

        public static (HashSet<(int, int)>, long) DDA(int x1, int y1, int x2, int y2)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            HashSet<(int, int)> points = new HashSet<(int, int)>();

            int L = Math.Max(Math.Abs(x2 - x1), Math.Abs(y2 - y1));
            double dX = (x2 - x1) * 1.0 / L;
            double dY = (y2 - y1) * 1.0 / L;
            points.Add(new ValueTuple<int, int>(x1, y1));
            double prevX = x1;
            double prevY = y1;
            int i = 1;
            while (i < L)
            {
                prevX = prevX + dX;
                prevY = prevY + dY;
                points.Add(new ValueTuple<int, int>((int)Math.Round(prevX), (int)Math.Round(prevY)));
                i++;
            }

            points.Add(new ValueTuple<int, int>(x2, y2));

            stopwatch.Stop();

            return (points, stopwatch.ElapsedTicks);
        }

        public static (HashSet<(int, int)>, long) Brezenhem(int x1, int y1, int x2, int y2)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            HashSet<(int, int)> points = new HashSet<(int, int)>();

            var steep = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);
            if (steep)
            {
                Swap(ref x1, ref y1);
                Swap(ref x2, ref y2);
            }

            if (x1 > x2)
            {
                Swap(ref x1, ref x2);
                Swap(ref y1, ref y2);
            }

            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int error = dx / 2;
            int ystep = (y1 < y2) ? 1 : -1;
            int y = y1;
            for (int x = x1; x <= x2; x++)
            {
                points.Add(new ValueTuple<int, int>(steep ? y : x, steep ? x : y));
                error -= dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }

            stopwatch.Stop();

            return (points, stopwatch.ElapsedTicks);
        }

        public static (HashSet<(int, int)>, long) BrezenhemCircle(int x1, int y1, int r)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            HashSet<(int, int)> points = new HashSet<(int, int)>();

            int x = 0;
            int y = r;
            int e = 3 - 2 * r;
            points.Add(new ValueTuple<int, int>(x + x1, y + y1));
            points.Add(new ValueTuple<int, int>(x + x1, -y + y1));
            points.Add(new ValueTuple<int, int>(-x + x1, y + y1));
            points.Add(new ValueTuple<int, int>(-x + x1, -y + y1));

            points.Add(new ValueTuple<int, int>(y + x1, x + y1));
            points.Add(new ValueTuple<int, int>(-y + x1, x + y1));
            points.Add(new ValueTuple<int, int>(y + x1, -x + y1));
            points.Add(new ValueTuple<int, int>(-y + x1, -x + y1));
            while (x < y)
            {
                if (e >= 0)
                {
                    e = e + 4 * (x - y) + 10;
                    x = x + 1;
                    y = y - 1;
                }
                else
                {
                    e = e + 4 * x + 6;
                    x = x + 1;
                }

                points.Add(new ValueTuple<int, int>(x + x1, y + y1));
                points.Add(new ValueTuple<int, int>(x + x1, -y + y1));
                points.Add(new ValueTuple<int, int>(-x + x1, y + y1));
                points.Add(new ValueTuple<int, int>(-x + x1, -y + y1));

                points.Add(new ValueTuple<int, int>(y + x1, x + y1));
                points.Add(new ValueTuple<int, int>(-y + x1, x + y1));
                points.Add(new ValueTuple<int, int>(y + x1, -x + y1));
                points.Add(new ValueTuple<int, int>(-y + x1, -x + y1));

                stopwatch.Stop();
            }

            return (points, stopwatch.ElapsedTicks);
        }

        private static void Swap(ref int x1, ref int x2)
        {
            int t = x2;
            x2 = x1;
            x1 = t;
        }
    }
}
