using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;

namespace ConsoleApp1Tests
{
    [TestClass]
    public class AlgorithmGCDTests
    {
        [TestMethod]
        public void TestMethodFindGCD()
        {
            Assert.AreEqual(17,AlgorithmGCD.GetEuclidGCD(34, 17, out long elapsedMs));
            Assert.AreEqual(5, AlgorithmGCD.GetEuclidGCD(5, 0, out elapsedMs));
            Assert.AreEqual(15,AlgorithmGCD.GetEuclidGCD(0, -15, out elapsedMs));
            Assert.AreEqual(5, AlgorithmGCD.GetEuclidGCD(-5, 10, out elapsedMs));
            Assert.AreEqual(6, AlgorithmGCD.GetEuclidGCD(6, 294, 570, out elapsedMs));
            Assert.AreEqual(2, AlgorithmGCD.GetEuclidGCD(62, 294, 570, out elapsedMs));
            Assert.AreEqual(9, AlgorithmGCD.GetEuclidGCD(-585, 81,-189, out elapsedMs));
            Assert.AreEqual(6, AlgorithmGCD.GetEuclidGCD(6, 294, 570, 36, out elapsedMs));
            Assert.AreEqual(6, AlgorithmGCD.GetEuclidGCD(6, 294, -570, -36, out elapsedMs));
            Assert.AreEqual(6, AlgorithmGCD.GetEuclidGCD(0, 294, 570, 36, out elapsedMs));

            Assert.AreEqual(17,AlgorithmGCD.GetBinaryGCD(34, 17, out elapsedMs));
            Assert.AreEqual(5, AlgorithmGCD.GetBinaryGCD(5, 0, out elapsedMs));
            Assert.AreEqual(15,AlgorithmGCD.GetBinaryGCD(0, -15, out elapsedMs));
            Assert.AreEqual(5, AlgorithmGCD.GetBinaryGCD(-5, 10, out elapsedMs));
            Assert.AreEqual(6, AlgorithmGCD.GetBinaryGCD(6, 294, 570, out elapsedMs));
            Assert.AreEqual(2, AlgorithmGCD.GetBinaryGCD(62, 294, 570, out elapsedMs));
            Assert.AreEqual(9, AlgorithmGCD.GetBinaryGCD(-585, 81, -189, out elapsedMs));
            Assert.AreEqual(6, AlgorithmGCD.GetBinaryGCD(6, 294, 570, 36, out elapsedMs));
            Assert.AreEqual(6, AlgorithmGCD.GetBinaryGCD(6, 294, -570, -36, out elapsedMs));
            Assert.AreEqual(6, AlgorithmGCD.GetBinaryGCD(0, 294, 570, 36, out elapsedMs));
        }
    }
}
