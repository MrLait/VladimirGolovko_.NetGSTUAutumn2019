using System;

namespace ConsoleApp1
{
    public class EuclideanAlgorithm
    {
        public static int FindGCD(int firstNum, int secondNum)
        {
            return Math.Abs(firstNum == 0 ? secondNum : FindGCD(secondNum % firstNum, firstNum));
        }
        public static Int32 FindGCD(Int32 firstNum, Int32 secondNum, Int32 thirdNum)
        {
            Int32 GCDOfTwoNumbers = FindGCD(firstNum, secondNum);
            return GCDOfTwoNumbers == 0 ? thirdNum : FindGCD(thirdNum % GCDOfTwoNumbers, GCDOfTwoNumbers);
        }
        public static Int32 FindGCD(Int32 firstNum, Int32 secondNum, Int32 thirdNum, Int32 fourthNum)
        {
            Int32 GCDOfThirdNumbers = FindGCD(firstNum, secondNum, thirdNum);
            return GCDOfThirdNumbers == 0 ? fourthNum : FindGCD(fourthNum % GCDOfThirdNumbers, GCDOfThirdNumbers);
        }

        public static int FindBinaryGCD(int a, int b)
        {
            if (a == b)
                return a;
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                    return FindBinaryGCD(a >> 1, b);
                else
                    return FindBinaryGCD(a >> 1, b >> 1) << 1;
            }
            if ((~b & 1) != 0)
                return FindBinaryGCD(a, b >> 1);
            if (a > b)
                return FindBinaryGCD((a - b) >> 1, b);
            return FindBinaryGCD((b - a) >> 1, a);
        }

    }
}