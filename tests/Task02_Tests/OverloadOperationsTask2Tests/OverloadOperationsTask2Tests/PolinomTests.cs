using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OverloadOperationsTask2;

namespace OverloadOperationsTask2Tests
{
    [TestClass]
    public class PolinomTests
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetDivisionForTwoPolinomWhenInputPolinomIsValidThenOutIsValid()
        {
            // Arrange
            Polinom dividend = new Polinom(
                //3x^5 + 2x^4 + 0x^3 + x^2 - x^1 + 1
                polinomParams: new double[] { 1, -1, 1, 0, 2, 3 });
            Polinom divider = new Polinom(
                //x^3 + 2x^2 + x + 0
                polinomParams: new double[] { 0, 1, 2, 1 });
            
            Polinom expected = new Polinom(
                // quotient = 3x^2 -4x + 5,
                quotient: new double[] { 5, -4, 3 },
                //remainder = -5x^2 -6x + 1
                remainder: new double[] { 1, -6, -5, 0, 0, 0 });

            //Act
            Polinom actual = dividend / divider;

            // Assert
            CollectionAssert.AreEqual(expected.Quotient, actual.Quotient);
            CollectionAssert.AreEqual(expected.Remainder, actual.Remainder);
        }

        /// <summary>
        /// 
        /// </summary>
        [ExpectedException(typeof(ArgumentException),
        "The Last polinom parameters can't be is zero")]
        [TestMethod]
        public void GetDivisionForTwoPolinomWhenInputPolinomWithFirstNumIsZeroThenOutIsArgumentException()
        {
            // Arrange
            Polinom dividend = new Polinom(
                //0x^5 + 2x^4 + 0x^3 + x^2 - x^1 + 1
                polinomParams: new double[] { 1, -1, 1, 0, 2, 0 });
            Polinom divider = new Polinom(
                //x^3 + 2x^2 + x + 0
                polinomParams: new double[] { 0, 1, 2, 1 });

            Polinom expected = new Polinom(
                // quotient = 0x^2 + 2x - 4,
                quotient: new double[] { -4, 2, 0 },
                //remainder = 7x^2 -3x + 1
                remainder: new double[] { 1, 3, 7, 0, 0, 0 });

            //Act
            Polinom actual = dividend / divider;

            // Assert
            CollectionAssert.AreEqual(expected.Quotient, actual.Quotient);
            CollectionAssert.AreEqual(expected.Remainder, actual.Remainder);
        }

        /// <summary>
        /// 
        /// </summary>
        [ExpectedException(typeof(ArithmeticException),
        "The degree of the divisor must be less than or equal" +
                    " to the degree of the dividend!")]
        [TestMethod]
        public void GetDivisionForTwoPolinomWhenFirstPolinomLessThenSecondThenOutIsArithmeticException()
        {
            // Arrange
            Polinom dividend = new Polinom(
                //0x^5 + 2x^4 + 0x^3 + x^2 - x^1 + 1
                polinomParams: new double[] { 0, 1, 2, 1 });
            Polinom divider = new Polinom(
                //x^3 + 2x^2 + x + 0
                polinomParams: new double[] { 1, -1, 1, 0, 2, 0 });

            Polinom expected = new Polinom(
                // quotient = 0x^2 + 2x - 4,
                quotient: new double[] { -4, 2, 0 },
                //remainder = 7x^2 -3x + 1
                remainder: new double[] { 1, 3, 7, 0, 0, 0 });

            //Act
            Polinom actual = dividend / divider;

            // Assert
            CollectionAssert.AreEqual(expected.Quotient, actual.Quotient);
            CollectionAssert.AreEqual(expected.Remainder, actual.Remainder);
        }

        [TestMethod]
        public void GetDivisionForTwoValidPolinomWhenFirstPolinomMoreThenSecondThenOutRemainderIsZero()
        {
            // Arrange
            Polinom dividend = new Polinom(
                //2x^3 - 3x^2 + 5x^1 + 14
                polinomParams: new double[] { -14, 5, -3, 2 });
            Polinom divider = new Polinom(
                //x -2
                polinomParams: new double[] {-2, 1 });

            Polinom expected = new Polinom(
                // quotient = 0x^2 + 2x - 4,
                quotient: new double[] { 7, 1, 2 },
                //remainder = 7x^2 -3x + 1
                remainder: new double[] { 0, 0, 0, 0 });

            //Act
            Polinom actual = dividend / divider;

            // Assert
            CollectionAssert.AreEqual(expected.Quotient, actual.Quotient);
            CollectionAssert.AreEqual(expected.Remainder, actual.Remainder);
        }

        [ExpectedException(typeof(ArgumentException),
        "The Last polinom parameters can't be is zero")]
        [TestMethod]
        public void GetDivisionForTwoValidPolinomWhenFirstPolinomMoreThenSecondThenOutIsArgumentException()
        {
            // Arrange
            Polinom dividend = new Polinom(
                //0x^3 - 1x^2 + 2x^1 + 3
                polinomParams: new double[] { 3, 2, 1, 0 });
            Polinom divider = new Polinom(
                //0x^1 + 1
                polinomParams: new double[] { 1, 0 });

            Polinom expected = new Polinom(
                // quotient = 0x^2 + 2x - 4,
                quotient: new double[] { 7, 1, 2 },
                //remainder = 7x^2 -3x + 1
                remainder: new double[] { 0, 0, 0, 0 });

            //Act
            Polinom actual = dividend / divider;

            // Assert
            CollectionAssert.AreEqual(expected.Quotient, actual.Quotient);
            CollectionAssert.AreEqual(expected.Remainder, actual.Remainder);
        }

    }
}
