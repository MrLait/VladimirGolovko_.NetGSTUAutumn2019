using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp1
{
    public class AlgorithmGcd
    {
        private const Int32 minGcdNum = 2;
        private const Int32 maxGcdNum = 4;

        /// <summary>
        /// Euclidean Gcd algorithm for two numbers.
        /// </summary>
        /// <param name="numbOne">The first number.</param>
        /// <param name="numbTwo">The second number.</param>
        /// <param name="totalMs">The output time parameter.</param>
        /// <returns>The greatest common divisor.</returns>
        public static Int32 GetEuclidGcd(int numbOne, int numbTwo, out double totalMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GcdOfTwoNum = GetEuclidGcdOfTwoNum(numbOne, numbTwo);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            totalMs = ts.TotalMilliseconds;
            return GcdOfTwoNum;
        }

        /// <summary>
        /// Euclidean Gcd algorithm for three numbers.
        /// </summary>
        /// <param name="numbOne">The first number.</param>
        /// <param name="numbTwo">The second number.</param>
        /// <param name="numbThree">The third number.</param>
        /// <param name="totalMs">The output time parameter.</param>
        /// <returns>The greatest common divisor.</returns>
        public static Int32 GetEuclidGcd(int numbOne, int numbTwo, int numbThree, out double totalMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GcdOfTwoNum = GetEuclidGcdOfTwoNum(numbOne, numbTwo);
            Int32 GcdOfThirdNum = GetEuclidGcdOfTwoNum(GcdOfTwoNum, numbThree);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            totalMs = ts.TotalMilliseconds;
            return GcdOfThirdNum;
        }

        /// <summary>
        /// Euclidean Gcd algorithm for four numbers.
        /// </summary>
        /// <param name="numbOnea">The first number.</param>
        /// <param name="numbTwo">The second number.</param>
        /// <param name="numbThree">The third number.</param>
        /// <param name="numbFour">The fourth number.</param>
        /// <param name="totalMs">The output time parameter.</param>
        /// <returns>The greatest common divisor.</returns>
        public static Int32 GetEuclidGcd(int numbOnea, int numbTwo, int numbThree, int numbFour, out double totalMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GcdOfTwoNum = GetEuclidGcdOfTwoNum(numbOnea, numbTwo);
            Int32 GcdOfThirdNum = GetEuclidGcdOfTwoNum(GcdOfTwoNum, numbThree);
            Int32 GcdOfFourNum = GetEuclidGcdOfTwoNum(GcdOfThirdNum, numbFour);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            totalMs = ts.TotalMilliseconds;
            return GcdOfFourNum;
        }

        /// <summary>
        /// Binary Gcd algorithm for two numbers.
        /// </summary>
        /// <param name="numbOnea">The first number.</param>
        /// <param name="numbTwo">The second number.</param>
        /// <param name="totalMs">The output time parameter.</param>
        /// <returns>The greatest common divisor.</returns>
        public static Int32 GetBinaryGcd(int numbOnea, int numbTwo, out double totalMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GcdOfTwoNum = GetBinaryGcdOfTwoNum(numbOnea, numbTwo);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            totalMs = ts.TotalMilliseconds;
            return GcdOfTwoNum;
        }

        /// <summary>
        /// Binary Gcd algorithm for three numbers.
        /// </summary>
        /// <param name="numbOne">The first number.</param>
        /// <param name="numbTwo">The second number.</param>
        /// <param name="numbThree">The third number.</param>
        /// <param name="totalMs">The output time parameter.</param>
        /// <returns>The greatest common divisor.</returns>
        public static Int32 GetBinaryGcd(int numbOne, int numbTwo, int numbThree, out double totalMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GcdOfTwoNum = GetBinaryGcdOfTwoNum(numbOne, numbTwo);
            Int32 GcdOfThirdNum = GetBinaryGcdOfTwoNum(GcdOfTwoNum, numbThree);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            totalMs = ts.TotalMilliseconds;
            return GcdOfThirdNum;
        }

        /// <summary>
        /// Binary Gcd algorithm for four numbers.
        /// </summary>
        /// <param name="numbOne">The first number.</param>
        /// <param name="numbTwo">The second number.</param>
        /// <param name="numbThree">The third number.</param>
        /// <param name="numbFour">The fourth number.</param>
        /// <param name="totalMs">The output time parameter.</param>
        /// <returns>The greatest common divisor.</returns>
        public static Int32 GetBinaryGcd(int numbOne, int numbTwo, int numbThree, int numbFour, out double totalMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GcdOfTwoNum = GetBinaryGcdOfTwoNum(numbOne, numbTwo);
            Int32 GcdOfThirdNum = GetBinaryGcdOfTwoNum(GcdOfTwoNum, numbThree);
            Int32 GcdOfFourNum = GetBinaryGcdOfTwoNum(GcdOfThirdNum, numbFour);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            totalMs = ts.TotalMilliseconds;
            return GcdOfFourNum;
        }

        /// <summary>
        /// The method prepares data for building a histogram.
        /// </summary>
        /// <param name="numbers">Takes a number of parameters for calculated GCD
        /// minimum Gcd parameters is 2 and maximum 5.</param>
        /// <returns>Returns a list with the calculated values ​​of the time spent
        /// on the calculation of the GCD</returns>
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

        /// <summary>
        /// Writing data from a list to a text file.
        /// </summary>
        /// <param name="inputData">Incoming list.</param>
        public static void WriteDataFromListToFile(List<DataForTheHistogram> inputData)
        {
            using (StreamWriter file = new StreamWriter(@"../../../txt/out.txt"))
            {
                if (inputData != null)
                {
                    String s = string.Format("{0,35} {1,11}", "Euclid", "Binary");
                    file.WriteLine(s);
                    
                    foreach (DataForTheHistogram line in inputData)
                    {
                        s = string.Format("{0};{1,7:N4} ms {2, 7:N4} ms", line.NumberOfParameters, line.ElapsedMsForEuclidGCD ,line.ElapsedMsForBinaryGCD);
                        file.WriteLine(s);
                    }
                }
            }
        }

        /// <summary>
        /// Calculation of the greatest common divisor using the Euclidean algorithm for two numbers.
        /// </summary>
        /// <param name="numbOne">The first number</param>
        /// <param name="numbTwo">The second number.</param>
        /// <returns>The greatest common divisor.</returns>
        private static Int32 GetEuclidGcdOfTwoNum(int numbOne, int numbTwo)
        {
            while (numbTwo != 0)
                numbTwo = numbOne % (numbOne = numbTwo);
            return Math.Abs(numbOne);
        }

        /// <summary>
        /// Calculation of the greatest common divisor using the Stein's algorithm for two numbers.
        /// </summary>
        /// <param name="numbOne">The first number</param>
        /// <param name="numbTwo">The second number.</param>
        /// <returns>The greatest common divisor.</returns>
        private static Int32 GetBinaryGcdOfTwoNum(int numbOne, int numbTwo)
        {
            numbOne = Math.Abs(numbOne);
            numbTwo = Math.Abs(numbTwo);
            if (numbOne == 0)
                return numbTwo;
            if (numbTwo == 0)
                return numbOne;
            int k;
            for (k = 0; ((numbOne | numbTwo) & 1) == 0; ++k)
            {
                numbOne >>= 1;
                numbTwo >>= 1;
            }
            while ((numbOne & 1) == 0)
                numbOne >>= 1;
            do
            {
                while ((numbTwo & 1) == 0)
                    numbTwo >>= 1;
                if (numbOne > numbTwo)
                {
                    int temp = numbOne;
                    numbOne = numbTwo;
                    numbTwo = temp;
                }
                numbTwo = (numbTwo - numbOne);
            } while (numbTwo != 0);
            return numbOne << k;
        }
    }
}