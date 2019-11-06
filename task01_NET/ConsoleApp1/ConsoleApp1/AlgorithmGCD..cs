using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    public class AlgorithmGCD
    {
        public static Int32 GetEuclidGCD(int a, int b, out long elapsedMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GCDOfTwoNumbers = GetEuclidGCDofTwoNum(a, b);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            return GCDOfTwoNumbers;
        }
        public static Int32 GetEuclidGCD(int a, int b, int c, out long elapsedMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GCDOfTwoNumbers = GetEuclidGCDofTwoNum(a,b);
            Int32 GCDOfThirdNumbers = GetEuclidGCDofTwoNum(GCDOfTwoNumbers, c);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            return GCDOfThirdNumbers;
        }
        public static Int32 GetEuclidGCD(int a, int b, int c, int d, out long elapsedMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GCDOfTwoNumbers = GetEuclidGCDofTwoNum(a, b);
            Int32 GCDOfThirdNumbers = GetEuclidGCDofTwoNum(GCDOfTwoNumbers, c);
            Int32 GCDOfFourNumbers = GetEuclidGCDofTwoNum(GCDOfThirdNumbers, d);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            return GCDOfFourNumbers;
        }
        public static Int32 GetBinaryGCD(int a, int b, out long elapsedMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GCDOfTwoNumbers = GetBinaryGCDofTwoNum(a, b);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            return GCDOfTwoNumbers;
        }
        public static Int32 GetBinaryGCD(int a, int b, int c, out long elapsedMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GCDOfTwoNumbers = GetBinaryGCDofTwoNum(a, b);
            Int32 GCDOfThirdNumbers = GetBinaryGCDofTwoNum(GCDOfTwoNumbers, c);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            return GCDOfThirdNumbers;
        }
        public static Int32 GetBinaryGCD(int a, int b, int c, int d, out long elapsedMs)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Int32 GCDOfTwoNumbers = GetBinaryGCDofTwoNum(a, b);
            Int32 GCDOfThirdNumbers = GetBinaryGCDofTwoNum(GCDOfTwoNumbers, c);
            Int32 GCDOfFourNumbers = GetBinaryGCDofTwoNum(GCDOfThirdNumbers, d);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            return GCDOfFourNumbers;
        }
        private static Int32 GetEuclidGCDofTwoNum(int a, int b)
        {
            while (b != 0)
                b = a % (a = b);
            return Math.Abs(a);
        }
        private static Int32 GetBinaryGCDofTwoNum(int a, int b)
        {
            if (a == 0)
                return Math.Abs(b);                           
            if (b == 0)
                return Math.Abs(a);                           
            if (a == b)
                return Math.Abs(a);                            
            if (a == 1 || b == 1)
                return 1;                            
            if ((a & 1) == 0)                        
                return ((b & 1) == 0)
                    ? GetBinaryGCDofTwoNum(a >> 1, b >> 1) << 1
                    : GetBinaryGCDofTwoNum(a >> 1, b);
            else                                     
                return ((b & 1) == 0)
                    ? GetBinaryGCDofTwoNum(a, b >> 1)                
                    : GetBinaryGCDofTwoNum(b, a > b ? a - b : b - a);
        }
    }
}