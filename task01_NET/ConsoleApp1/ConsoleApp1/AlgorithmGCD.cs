using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{
    public class AlgorithmGcd
    {
        private const Int32 minGcdNum = 2;
        private const Int32 maxGcdNum = 4;
        /// <summary>
        /// Euclidean Gcd algorithm for two numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="totalMs">The output time parameter.</param>
        /// <returns>The greatest common divisor.</returns>
        public static Int32 GetEuclidGcd(int a, int b, out double totalMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GcdOfTwoNum = GetEuclidGcdOfTwoNum(a, b);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            totalMs = ts.TotalMilliseconds;
            return GcdOfTwoNum;
        }
        /// <summary>
        /// Euclidean Gcd algorithm for three numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <param name="totalMs">The output time parameter.</param>
        /// <returns>The greatest common divisor.</returns>
        public static Int32 GetEuclidGcd(int a, int b, int c, out double totalMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GcdOfTwoNum = GetEuclidGcdOfTwoNum(a, b);
            Int32 GcdOfThirdNum = GetEuclidGcdOfTwoNum(GcdOfTwoNum, c);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            totalMs = ts.TotalMilliseconds;
            return GcdOfThirdNum;
        }
        /// <summary>
        /// Euclidean Gcd algorithm for four numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <param name="d">The fourth number.</param>
        /// <param name="totalMs">The output time parameter.</param>
        /// <returns>The greatest common divisor.</returns>
        public static Int32 GetEuclidGcd(int a, int b, int c, int d, out double totalMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GcdOfTwoNum = GetEuclidGcdOfTwoNum(a, b);
            Int32 GcdOfThirdNum = GetEuclidGcdOfTwoNum(GcdOfTwoNum, c);
            Int32 GcdOfFourNum = GetEuclidGcdOfTwoNum(GcdOfThirdNum, d);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            totalMs = ts.TotalMilliseconds;
            return GcdOfFourNum;
        }
        /// <summary>
        /// Binary Gcd algorithm for two numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="totalMs">The output time parameter.</param>
        /// <returns>The greatest common divisor.</returns>
        public static Int32 GetBinaryGcd(int a, int b, out double totalMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GcdOfTwoNum = GetBinaryGcdOfTwoNum(a, b);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            totalMs = ts.TotalMilliseconds;
            return GcdOfTwoNum;
        }
        /// <summary>
        /// Binary Gcd algorithm for three numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <param name="totalMs">The output time parameter.</param>
        /// <returns>The greatest common divisor.</returns>
        public static Int32 GetBinaryGcd(int a, int b, int c, out double totalMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GcdOfTwoNum = GetBinaryGcdOfTwoNum(a, b);
            Int32 GcdOfThirdNum = GetBinaryGcdOfTwoNum(GcdOfTwoNum, c);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            totalMs = ts.TotalMilliseconds;
            return GcdOfThirdNum;
        }
        /// <summary>
        /// Binary Gcd algorithm for four numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <param name="d">The fourth number.</param>
        /// <param name="totalMs">The output time parameter.</param>
        /// <returns>The greatest common divisor.</returns>
        public static Int32 GetBinaryGcd(int a, int b, int c, int d, out double totalMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GcdOfTwoNum = GetBinaryGcdOfTwoNum(a, b);
            Int32 GcdOfThirdNum = GetBinaryGcdOfTwoNum(GcdOfTwoNum, c);
            Int32 GcdOfFourNum = GetBinaryGcdOfTwoNum(GcdOfThirdNum, d);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            totalMs = ts.TotalMilliseconds;
            return GcdOfFourNum;
        }
        /// <summary>
        /// Calculation of the greatest common divisor using the Euclidean algorithm for two numbers.
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number.</param>
        /// <returns>The greatest common divisor.</returns>
        private static Int32 GetEuclidGcdOfTwoNum(int a, int b)
        {
            while (b != 0)
                b = a % (a = b);
            return Math.Abs(a);
        }
        /// <summary>
        /// Calculation of the greatest common divisor using the Stein's algorithm for two numbers.
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number.</param>
        /// <returns>The greatest common divisor.</returns>
        private static Int32 GetBinaryGcdOfTwoNum(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            int k;
            for (k = 0; ((a | b) & 1) == 0; ++k)
            {
                a >>= 1;
                b >>= 1;
            }
            while ((a & 1) == 0)
                a >>= 1;
            do
            {
                while ((b & 1) == 0)
                    b >>= 1;
                if (a > b)
                {
                    int temp = a;
                    a = b;
                    b = temp;
                }
                b = (b - a);
            } while (b != 0);
            return a << k;
        }
        /// <summary>
        /// The method prepares data for building a histogram.
        /// </summary>
        /// <param name="numbers">Takes a number of parameters from 2 to 5.</param>
        /// <returns>Returns a list of calculated time values ​​spent on the execution of algorithms.</returns>
        public static List<DataForTheHistogram> PrepareDataForHistogram(params Int32[] numbers)
        {
            double totalMsForEuclidGcd;
            double totalMsForBinaryGcd;
            List<DataForTheHistogram> dataForTheHistograms = new List<DataForTheHistogram>();
            if (numbers != null & numbers.Length >= minGcdNum & numbers.Length <= maxGcdNum)
            {
                for (int i = minGcdNum; i <= numbers.Length; i++)
                {
                    String numParams = "Number of Gcd parameters: " + i.ToString();
                    if (i == minGcdNum)
                    {
                        GetEuclidGcd(numbers[0], numbers[1], out totalMsForEuclidGcd);
                        GetBinaryGcd(numbers[0], numbers[1], out totalMsForBinaryGcd);
                        dataForTheHistograms.Add(new DataForTheHistogram(numParams, totalMsForEuclidGcd, totalMsForBinaryGcd));
                    }
                    else if (i == 3)
                    {
                        GetEuclidGcd(numbers[0], numbers[1], numbers[2], out totalMsForEuclidGcd);
                        GetBinaryGcd(numbers[0], numbers[1], numbers[2], out totalMsForBinaryGcd);
                        dataForTheHistograms.Add(new DataForTheHistogram(numParams, totalMsForEuclidGcd, totalMsForBinaryGcd));
                    }
                    else if (i == maxGcdNum)
                    {
                        GetEuclidGcd(numbers[0], numbers[1], numbers[2], numbers[3], out totalMsForEuclidGcd);
                        GetBinaryGcd(numbers[0], numbers[1], numbers[2], numbers[3], out totalMsForBinaryGcd);
                        dataForTheHistograms.Add(new DataForTheHistogram(numParams, totalMsForEuclidGcd, totalMsForBinaryGcd));
                    }
                }
            }
            return dataForTheHistograms;
        }

    }
}