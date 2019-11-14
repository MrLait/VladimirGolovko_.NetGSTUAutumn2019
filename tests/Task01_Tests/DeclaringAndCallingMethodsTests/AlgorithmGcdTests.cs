using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using ConsoleApp1;

namespace DeclaringAndCallingMethodsTests
{

    [TestClass]
    public class AlgorithmGcdTests
    {
        /// <summary>
        /// Test for correct calculation by the GetEuclidGcd method when numbers is positive.
        /// </summary>
        [TestMethod]
        public void GivenGetEuclidGcd_ForTwoNumWhenNumbersIsPositiveOutIsPositive()
        {
            Assert.AreEqual(17, AlgorithmGcd.GetEuclidGcd(34, 17, out double elapsedMs));
            Assert.AreEqual(170, AlgorithmGcd.GetEuclidGcd(340000, 170, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetEuclidGcd method when numbers is negative.
        /// </summary>
        [TestMethod]
        public void GivenGetEuclidGcd_ForTwoNumWhenNumbersIsNegativeOutIsPositive()
        {
            Assert.AreEqual(17, AlgorithmGcd.GetEuclidGcd(-34, -17, out double elapsedMs));
            Assert.AreEqual(170, AlgorithmGcd.GetEuclidGcd(-340000, -170, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetEuclidGcd method when numbers is negative
        /// and positive.
        /// </summary>
        [TestMethod]
        public void GivenGetEuclidGcd_ForTwoNumWhenNumbersIsNegativeAndPositiveOutIsPositive()
        {
            Assert.AreEqual(17, AlgorithmGcd.GetEuclidGcd(34, -17, out double elapsedMs));
            Assert.AreEqual(170, AlgorithmGcd.GetEuclidGcd(-340000, 170, out elapsedMs));
        }

        /// <summary>
        /// Test for corrct calculation by the GetEuclidGcd method when one of numbers
        /// is zero.
        /// </summary>
        [TestMethod]
        public void GivenGetEuclidGcd_ForTwoNumWhenOneOfNumbersIsZeroOutIsPositive()
        {
            Assert.AreEqual(17, AlgorithmGcd.GetEuclidGcd(0, -17, out double elapsedMs));
            Assert.AreEqual(340000, AlgorithmGcd.GetEuclidGcd(-340000, 0, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetEuclidGcd method when numbers is positive.
        /// </summary>
        [TestMethod]
        public void GivenGetEuclidGcd_ForThreeNumWhenNumbersIsPositiveOutIsPositive()
        {
            Assert.AreEqual(1, AlgorithmGcd.GetEuclidGcd(34, 17, 3700, out double elapsedMs));
            Assert.AreEqual(17, AlgorithmGcd.GetEuclidGcd(340000, 170, 17, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetEuclidGcd method when numbers is negative.
        /// </summary>
        [TestMethod]
        public void GivenGetEuclidGcd_ForThreeNumWhenNumbersIsNegativeOutIsPositive()
        {
            Assert.AreEqual(1, AlgorithmGcd.GetEuclidGcd(-34, -17, -3700, out double elapsedMs));
            Assert.AreEqual(17, AlgorithmGcd.GetEuclidGcd(-340000, -170, -17, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetEuclidGcd method when numbers is negative
        /// and positive.
        /// </summary>
        [TestMethod]
        public void GivenGetEuclidGcd_ForThreeNumWhenNumbersIsNegativeAndPositiveOutIsPositive()
        {
            Assert.AreEqual(17, AlgorithmGcd.GetEuclidGcd(34, -17, 34, out double elapsedMs));
            Assert.AreEqual(34, AlgorithmGcd.GetEuclidGcd(-340000, 170, 34, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetEuclidGcd method when one of numbers
        /// is zero.
        /// </summary>
        [TestMethod]
        public void GivenGetEuclidGcd_ForThreeNumWhenOneOfNumbersIsZeroOutIsPositive()
        {
            Assert.AreEqual(17, AlgorithmGcd.GetEuclidGcd(0, -17, 34, out double elapsedMs));
            Assert.AreEqual(50, AlgorithmGcd.GetEuclidGcd(-340000, 0, 50, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetEuclidGcd method when numbers is positive.
        /// </summary>
        [TestMethod]
        public void GivenGetEuclidGcd_ForFourNumWhenNumbersIsPositiveOutIsPositive()
        {
            Assert.AreEqual(1, AlgorithmGcd.GetEuclidGcd(34, 17, 3700, 170, out double elapsedMs));
            Assert.AreEqual(1, AlgorithmGcd.GetEuclidGcd(340000, 170, 17, 1900, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetEuclidGcd method when numbers is negative.
        /// </summary>
        [TestMethod]
        public void GivenGetEuclidGcd_ForFourNumWhenNumbersIsNegativeOutIsPositive()
        {
            Assert.AreEqual(1, AlgorithmGcd.GetEuclidGcd(-34, -17, -3700, -900, out double elapsedMs));
            Assert.AreEqual(1, AlgorithmGcd.GetEuclidGcd(-340000, -170, -17, -900, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetEuclidGcd method when numbers is negative
        /// and positive.
        /// </summary>
        [TestMethod]
        public void GivenGetEuclidGcd_ForFourNumWhenNumbersIsNegativeAndPositiveOutIsPositive()
        {
            Assert.AreEqual(1, AlgorithmGcd.GetEuclidGcd(34, -17, 34, -50, out double elapsedMs));
            Assert.AreEqual(2, AlgorithmGcd.GetEuclidGcd(-340000, 170, 34, -100, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetEuclidGcd method when one of numbers
        /// is zero.
        /// </summary>
        [TestMethod]
        public void GivenGetEuclidGcd_ForFourNumWhenOneOfNumbersIsZeroOutIsPositive()
        {
            Assert.AreEqual(1, AlgorithmGcd.GetEuclidGcd(0, -17, 34, 30, out double elapsedMs));
            Assert.AreEqual(5, AlgorithmGcd.GetEuclidGcd(-340000, 0, 50, 100005, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetBinaryGcd method when numbers is positive.
        /// </summary>
        [TestMethod]
        public void GivenGetBinaryGcd_ForTwoNumWhenNumbersIsPositiveOutIsPositive()
        {
            Assert.AreEqual(17, AlgorithmGcd.GetBinaryGcd(34, 17, out double elapsedMs));
            Assert.AreEqual(170, AlgorithmGcd.GetBinaryGcd(340000, 170, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetBinaryGcd method when numbers is negative.
        /// </summary>
        [TestMethod]
        public void GivenGetBinaryGcd_ForTwoNumWhenNumbersIsNegativeOutIsPositive()
        {
            Assert.AreEqual(17, AlgorithmGcd.GetBinaryGcd(-34, -17, out double elapsedMs));
            Assert.AreEqual(170, AlgorithmGcd.GetBinaryGcd(-340000, -170, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetBinaryGcd method when numbers is negative
        /// and positive.
        /// </summary>
        [TestMethod]
        public void GivenGetBinaryGcd_ForTwoNumWhenNumbersIsNegativeAndPositiveOutIsPositive()
        {
            Assert.AreEqual(17, AlgorithmGcd.GetBinaryGcd(34, -17, out double elapsedMs));
            Assert.AreEqual(170, AlgorithmGcd.GetBinaryGcd(-340000, 170, out elapsedMs));
        }

        /// <summary>
        /// Test for corrct calculation by the GetBinaryGcd method when one of numbers
        /// is zero.
        /// </summary>
        [TestMethod]
        public void GivenGetBinaryGcd_ForTwoNumWhenOneOfNumbersIsZeroOutIsPositive()
        {
            Assert.AreEqual(17, AlgorithmGcd.GetBinaryGcd(0, -17, out double elapsedMs));
            Assert.AreEqual(340000, AlgorithmGcd.GetBinaryGcd(-340000, 0, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetBinaryGcd method when numbers is positive.
        /// </summary>
        [TestMethod]
        public void GivenGetBinaryGcd_ForThreeNumWhenNumbersIsPositiveOutIsPositive()
        {
            Assert.AreEqual(1, AlgorithmGcd.GetBinaryGcd(34, 17, 3700, out double elapsedMs));
            Assert.AreEqual(17, AlgorithmGcd.GetBinaryGcd(340000, 170, 17, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetBinaryGcd method when numbers is negative.
        /// </summary>
        [TestMethod]
        public void GivenGetBinaryGcd_ForThreeNumWhenNumbersIsNegativeOutIsPositive()
        {
            Assert.AreEqual(1, AlgorithmGcd.GetBinaryGcd(-34, -17, -3700, out double elapsedMs));
            Assert.AreEqual(17, AlgorithmGcd.GetBinaryGcd(-340000, -170, -17, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetBinaryGcd method when numbers is negative
        /// and positive.
        /// </summary>
        [TestMethod]
        public void GivenGetBinaryGcd_ForThreeNumWhenNumbersIsNegativeAndPositiveOutIsPositive()
        {
            Assert.AreEqual(17, AlgorithmGcd.GetBinaryGcd(34, -17, 34, out double elapsedMs));
            Assert.AreEqual(34, AlgorithmGcd.GetBinaryGcd(-340000, 170, 34, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetBinaryGcd method when one of numbers
        /// is zero.
        /// </summary>
        [TestMethod]
        public void GivenGetBinaryGcd_ForThreeNumWhenOneOfNumbersIsZeroOutIsPositive()
        {
            Assert.AreEqual(17, AlgorithmGcd.GetBinaryGcd(0, -17, 34, out double elapsedMs));
            Assert.AreEqual(50, AlgorithmGcd.GetBinaryGcd(-340000, 0, 50, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetBinaryGcd method when numbers is positive.
        /// </summary>
        [TestMethod]
        public void GivenGetBinaryGcd_ForFourNumWhenNumbersIsPositiveOutIsPositive()
        {
            Assert.AreEqual(1, AlgorithmGcd.GetBinaryGcd(34, 17, 3700, 170, out double elapsedMs));
            Assert.AreEqual(1, AlgorithmGcd.GetBinaryGcd(340000, 170, 17, 1900, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetBinaryGcd method when numbers is negative.
        /// </summary>
        [TestMethod]
        public void GivenGetBinaryGcd_ForFourNumWhenNumbersIsNegativeOutIsPositive()
        {
            Assert.AreEqual(1, AlgorithmGcd.GetBinaryGcd(-34, -17, -3700, -900, out double elapsedMs));
            Assert.AreEqual(1, AlgorithmGcd.GetBinaryGcd(-340000, -170, -17, -900, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetBinaryGcd method when numbers is negative
        /// and positive.
        /// </summary>
        [TestMethod]
        public void GivenGetBinaryGcd_ForFourNumWhenNumbersIsNegativeAndPositiveOutIsPositive()
        {
            Assert.AreEqual(1, AlgorithmGcd.GetBinaryGcd(34, -17, 34, -50, out double elapsedMs));
            Assert.AreEqual(2, AlgorithmGcd.GetBinaryGcd(-340000, 170, 34, -100, out elapsedMs));
        }

        /// <summary>
        /// Test for correct calculation by the GetBinaryGcd method when one of numbers
        /// is zero.
        /// </summary>
        [TestMethod]
        public void GivenGetBinaryGcd_ForFourNumWhenOneOfNumbersIsZeroOutIsPositive()
        {
            Assert.AreEqual(1, AlgorithmGcd.GetBinaryGcd(0, -17, 34, 30, out double elapsedMs));
            Assert.AreEqual(5, AlgorithmGcd.GetBinaryGcd(-340000, 0, 50, 100005, out elapsedMs));
        }

        ///// <summary>
        ///// A check is performed on the amount of filled data in the list, depending on the number of GCD.
        ///// </summary>
        [TestMethod]
        public void GivenPrepareDataForHistogram_ForTwoParamsWhenOutIsOne()
        {
            // Arrange
            List<DataForTheHistogram> dataForTheHistograms = new List<DataForTheHistogram>();
            List<DataForTheHistogram> actual = AlgorithmGcd.PrepareDataForHistogram(6, 294);
            String numParams = "Number of Gcd parameters: " + 2;
            
            // Act
            dataForTheHistograms.Add(new DataForTheHistogram(numParams, 0, 0));
            var expectedOne  = dataForTheHistograms.Count;
            
            // Assert
            Assert.AreEqual(expectedOne, actual.Count);
        }

        ///// <summary>
        ///// A check is performed on the amount of filled data in the list, depending on the number of GCD.
        ///// </summary>
        [TestMethod]
        public void GivenPrepareDataForHistogram_ForThreeParamsWhenOutIsTwo()
        {
            // Arrange
            List<DataForTheHistogram> dataForTheHistograms = new List<DataForTheHistogram>();
            List<DataForTheHistogram> actual = AlgorithmGcd.PrepareDataForHistogram(6, 294, 700);
            String numParams = "Number of Gcd parameters: " + 2;

            // Act
            dataForTheHistograms.Add(new DataForTheHistogram(numParams, 0, 0));
            numParams = "Number of Gcd parameters: " + 3;
            dataForTheHistograms.Add(new DataForTheHistogram(numParams, 0, 0));
            var expectedTwo = dataForTheHistograms.Count;

            // Assert
            Assert.AreEqual(expectedTwo, actual.Count);
        }

        ///// <summary>
        ///// A check is performed on the amount of filled data in the list, depending on the number of GCD.
        ///// </summary>
        [TestMethod]
        public void GivenPrepareDataForHistogram_ForFourParamsWhenOutIsThree()
        {
            // Arrange
            List<DataForTheHistogram> dataForTheHistograms = new List<DataForTheHistogram>();
            List<DataForTheHistogram> actual = AlgorithmGcd.PrepareDataForHistogram(6, 294, 700, 500);
            String numParams = "Number of Gcd parameters: " + 2;

            // Act
            dataForTheHistograms.Add(new DataForTheHistogram(numParams, 0, 0));
            numParams = "Number of Gcd parameters: " + 3;
            dataForTheHistograms.Add(new DataForTheHistogram(numParams, 0, 0));
            numParams = "Number of Gcd parameters: " + 4;
            dataForTheHistograms.Add(new DataForTheHistogram(numParams, 0, 0));
            var expectedFour = dataForTheHistograms.Count;

            // Assert
            Assert.AreEqual(expectedFour, actual.Count);
        }

        ///// <summary>
        ///// A check is performed on the amount of filled data in the list, depending on the number of GCD.
        ///// </summary>
        [TestMethod]
        public void GivenPrepareDataForHistogram_ForFiveAndMoreParamsWhenOutIsZero()
        {
            // Arrange
            List<DataForTheHistogram> actual = AlgorithmGcd.PrepareDataForHistogram(6, 294, 700,1000, 50000);

            // Act
            var expectedZero = 0;

            // Assert
            Assert.AreEqual(expectedZero, actual.Count);
        }

        ///// <summary>
        ///// A check is performed on the amount of filled data in the list, depending on the number of GCD.
        ///// </summary>
        [TestMethod]
        public void GivenPrepareDataForHistogram_ForOneParamsWhenOutIsZero()
        {
            // Arrange
            List<DataForTheHistogram> actual = AlgorithmGcd.PrepareDataForHistogram(6);

            // Act
            var expectedZero = 0;

            // Assert
            Assert.AreEqual(expectedZero, actual.Count);
        }

        /// <summary>
        /// Check for file creation.
        /// </summary>
        [TestMethod()]
        public void GivenWriteDataFromListToFile_ForMethodPrepareDataForHistogram_WhenFileIsDelete_OutIsTrue()
        {
            // Arrange
            FileInfo fi = new FileInfo(@"../../../txt/out.txt");
            
            // Act
            fi.Delete();
            AlgorithmGcd.WriteDataFromListToFile(AlgorithmGcd.PrepareDataForHistogram(6, 294, 570, 36));
            
            //Assert
            Assert.IsTrue(fi.Exists);
        }
    }
}