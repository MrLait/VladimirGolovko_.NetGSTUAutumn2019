using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(EuclideanAlgorithm.FindGCD(78, 294));
            Console.WriteLine(EuclideanAlgorithm.FindGCD(5, 0));
            Console.WriteLine(EuclideanAlgorithm.FindGCD(64, -48));
            Console.WriteLine(EuclideanAlgorithm.FindGCD(-78, 294, 570, 36));
            Console.WriteLine(EuclideanAlgorithm.FindGCD(78, 294, 590, 38));
            Console.WriteLine(EuclideanAlgorithm.FindGCD(-231, -140));
            Console.WriteLine(EuclideanAlgorithm.FindGCD(-585, 81,-189));
            Console.WriteLine();
            Console.WriteLine(EuclideanAlgorithm.FindBinaryGCD(78,294));
            Console.WriteLine(EuclideanAlgorithm.FindBinaryGCD(64, 48));
        }
    }
}
