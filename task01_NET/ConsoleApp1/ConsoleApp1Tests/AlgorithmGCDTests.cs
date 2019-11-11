using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System.Collections.Generic;
using System.Collections;

namespace ConsoleApp1Tests
{

    [TestClass]
    public class AlgorithmGcdTests
    {
        /// <summary>
        /// Test for correct calculation by the method and its overloads.
        /// </summary>
        [TestMethod]
        public void GetEuclidGcdTests()
        {
            Assert.AreEqual(17, AlgorithmGcd.GetEuclidGcd(34, 17, out double elapsedMs));
            Assert.AreEqual(5, AlgorithmGcd.GetEuclidGcd(5, 0, out elapsedMs));
            Assert.AreEqual(15, AlgorithmGcd.GetEuclidGcd(0, -15, out elapsedMs));
            Assert.AreEqual(5, AlgorithmGcd.GetEuclidGcd(-5, 10, out elapsedMs));
            Assert.AreEqual(6, AlgorithmGcd.GetEuclidGcd(6, 294, 570, out elapsedMs));
            Assert.AreEqual(2, AlgorithmGcd.GetEuclidGcd(62, 294, 570, out elapsedMs));
            Assert.AreEqual(9, AlgorithmGcd.GetEuclidGcd(-585, 81, -189, out elapsedMs));
            Assert.AreEqual(6, AlgorithmGcd.GetEuclidGcd(6, 294, 570, 36, out elapsedMs));
            Assert.AreEqual(6, AlgorithmGcd.GetEuclidGcd(6, 294, -570, -36, out elapsedMs));
            Assert.AreEqual(6, AlgorithmGcd.GetEuclidGcd(0, 294, 570, 36, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the method and its overloads.
        /// The values used are the same as for GetEuclidGcdTests.
        /// </summary>
        [TestMethod]
        public void GetBinaryGcdTests()
        {
            Assert.AreEqual(17, AlgorithmGcd.GetBinaryGcd(34, 17, out double elapsedMs));
            Assert.AreEqual(5, AlgorithmGcd.GetBinaryGcd(5, 0, out elapsedMs));
            Assert.AreEqual(15, AlgorithmGcd.GetBinaryGcd(0, -15, out elapsedMs));
            Assert.AreEqual(5, AlgorithmGcd.GetBinaryGcd(-5, 10, out elapsedMs));
            Assert.AreEqual(6, AlgorithmGcd.GetBinaryGcd(6, 294, 570, out elapsedMs));
            Assert.AreEqual(2, AlgorithmGcd.GetBinaryGcd(62, 294, 570, out elapsedMs));
            Assert.AreEqual(9, AlgorithmGcd.GetBinaryGcd(-585, 81, -189, out elapsedMs));
            Assert.AreEqual(6, AlgorithmGcd.GetBinaryGcd(6, 294, 570, 36, out elapsedMs));
            Assert.AreEqual(6, AlgorithmGcd.GetBinaryGcd(6, 294, -570, -36, out elapsedMs));
            Assert.AreEqual(6, AlgorithmGcd.GetBinaryGcd(0, 294, 570, 36, out elapsedMs));
        }

        /// <summary>
        /// A check is performed on the amount of filled data in the list, depending on the number of GCD.
        /// </summary>
        [TestMethod()]
        public void PrepareDataForHistogramTests()
        {
            List<DataForTheHistogram> expected = new List<DataForTheHistogram>();

            List<DataForTheHistogram> actual = AlgorithmGcd.PrepareDataForHistogram(6, 294);
            String numParams = "Number of Gcd parameters: " + 2;
            expected.Add(new DataForTheHistogram(numParams, 0, 0));
            Assert.AreEqual(expected.Count, actual.Count);

            numParams = "Number of Gcd parameters: " + 3;
            actual = AlgorithmGcd.PrepareDataForHistogram(6, 294, 570);
            expected.Add(new DataForTheHistogram(numParams, 0, 0));
            Assert.AreEqual(expected.Count, actual.Count);

            numParams = "Number of Gcd parameters: " + 4;
            actual = AlgorithmGcd.PrepareDataForHistogram(6, 294, 570, 36);
            expected.Add(new DataForTheHistogram(numParams, 0, 0));
            Assert.AreEqual(expected.Count, actual.Count);

            numParams = "Number of Gcd parameters: " + 5;
            actual = AlgorithmGcd.PrepareDataForHistogram(6, 294, 570, 36, 20);
            expected.Add(new DataForTheHistogram(numParams, 0, 0));
            Assert.AreEqual(0, actual.Count);

            numParams = "Number of Gcd parameters: " + 1;
            actual = AlgorithmGcd.PrepareDataForHistogram(6);
            expected.Add(new DataForTheHistogram(numParams, 0, 0));
            Assert.AreEqual(0, actual.Count);
        }
    }
}