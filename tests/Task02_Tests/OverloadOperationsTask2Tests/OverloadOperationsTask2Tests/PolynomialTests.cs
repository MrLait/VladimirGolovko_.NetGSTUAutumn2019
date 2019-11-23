using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OverloadOperationsTask2;

namespace OverloadOperationsTask2Tests
{
    [TestClass]
    public class PolynomialTests
    {
        /// <summary>
        /// Method for testing division operator overload.
        /// </summary>
        [TestMethod]
        public void GetDivisionForTwoPolynomialWhenInputPolynomialIsValidThenOutIsValid()
        {
            // Arrange
            Polynomial dividend = new Polynomial(
                //3x^5 + 2x^4 + 0x^3 + x^2 - x^1 + 1
                elements: new double[] { 1, -1, 1, 0, 2, 3 });
            Polynomial divider = new Polynomial(
                //x^3 + 2x^2 + x + 0
                elements: new double[] { 0, 1, 2, 1 });
            
            Polynomial expected = new Polynomial(
                //quotient elements = 3x^2 -4x + 5,
                quotientElements: new double[] { 5, -4, 3 },
                //remainder elements = -5x^2 -6x + 1
                remainderElements: new double[] { 1, -6, -5, 0, 0, 0 });

            //Act
            Polynomial actual = dividend / divider;

            // Assert
            CollectionAssert.AreEqual(expected.QuotientElements, actual.QuotientElements);
            CollectionAssert.AreEqual(expected.RemainderElements, actual.RemainderElements);
        }
        
        /// <summary>
        /// Method for testing division operator overload.
        /// </summary>
        [TestMethod]
        public void GetDivisionForTwoValidPolynomialWhenFirstPolynomialMoreThenSecondThenOutRemainderIsZero()
        {
            // Arrange
            Polynomial dividend = new Polynomial(
                //2x^3 - 3x^2 + 5x^1 + 14
                elements: new double[] { -14, 5, -3, 2 });
            Polynomial divider = new Polynomial(
                //x -2
                elements: new double[] { -2, 1 });

            Polynomial expected = new Polynomial(
                // quotient elements = 0x^2 + 2x - 4,
                quotientElements: new double[] { 7, 1, 2 },
                //remainder elements = 7x^2 -3x + 1
                remainderElements: new double[] { 0, 0, 0, 0 });

            //Act
            Polynomial actual = dividend / divider;

            // Assert
            CollectionAssert.AreEqual(expected.QuotientElements, actual.QuotientElements);
            CollectionAssert.AreEqual(expected.RemainderElements, actual.RemainderElements);
        }

        /// <summary>
        /// Method for testing division operator overload.
        /// </summary>
        [ExpectedException(typeof(ArgumentException),
        "The Last Polynomial parameters can't be is zero")]
        [TestMethod]
        public void GetDivisionForTwoPolynomialWhenInputPolynomialWithFirstNumIsZeroThenOutIsArgumentException()
        {
            // Arrange
            Polynomial dividend = new Polynomial(
                //0x^5 + 2x^4 + 0x^3 + x^2 - x^1 + 1
                elements: new double[] { 1, -1, 1, 0, 2, 0 });
            Polynomial divider = new Polynomial(
                //x^3 + 2x^2 + x + 0
                elements: new double[] { 0, 1, 2, 1 });

            Polynomial expected = new Polynomial(
                // quotient elements = 0x^2 + 2x - 4,
                quotientElements: new double[] { -4, 2, 0 },
                //remainder elements = 7x^2 -3x + 1
                remainderElements: new double[] { 1, 3, 7, 0, 0, 0 });

            //Act
            Polynomial actual = dividend / divider;

            // Assert
            CollectionAssert.AreEqual(expected.QuotientElements, actual.QuotientElements);
            CollectionAssert.AreEqual(expected.RemainderElements, actual.RemainderElements);
        }

        /// <summary>
        /// Method for testing division operator overload.
        /// </summary>
        [ExpectedException(typeof(ArithmeticException),
        "The degree of the divisor must be less than or equal" +
                    " to the degree of the dividend!")]
        [TestMethod]
        public void GetDivisionForTwoPolynomialWhenFirstPolynomialLessThenSecondThenOutIsArithmeticException()
        {
            // Arrange
            Polynomial dividend = new Polynomial(
                //0x^5 + 2x^4 + 0x^3 + x^2 - x^1 + 1
                elements: new double[] { 0, 1, 2, 1 });
            Polynomial divider = new Polynomial(
                //x^3 + 2x^2 + x + 0
                elements: new double[] { 1, -1, 1, 0, 2, 0 });

            Polynomial expected = new Polynomial(
                // quotient elements = 0x^2 + 2x - 4,
                quotientElements: new double[] { -4, 2, 0 },
                //remainder elements = 7x^2 -3x + 1
                remainderElements: new double[] { 1, 3, 7, 0, 0, 0 });

            //Act
            Polynomial actual = dividend / divider;

            // Assert
            CollectionAssert.AreEqual(expected.QuotientElements, actual.QuotientElements);
            CollectionAssert.AreEqual(expected.RemainderElements, actual.RemainderElements);
        }

        /// <summary>
        /// Method for testing division operator overload.
        /// </summary>
        [ExpectedException(typeof(ArgumentException),
        "The Last Polynomial parameters can't be is zero")]
        [TestMethod]
        public void GetDivisionForTwoValidPolynomialWhenFirstPolynomialMoreThenSecondThenOutIsArgumentException()
        {
            // Arrange
            Polynomial dividend = new Polynomial(
                //0x^3 - 1x^2 + 2x^1 + 3
                elements: new double[] { 3, 2, 1, 0 });
            Polynomial divider = new Polynomial(
                //0x^1 + 1
                elements: new double[] { 1, 0 });

            Polynomial expected = new Polynomial(
                // quotient elements = 0x^2 + 2x - 4,
                quotientElements: new double[] { 7, 1, 2 },
                //remainder elements = 7x^2 -3x + 1
                remainderElements: new double[] { 0, 0, 0, 0 });

            //Act
            Polynomial actual = dividend / divider;

            // Assert
            CollectionAssert.AreEqual(expected.QuotientElements, actual.QuotientElements);
            CollectionAssert.AreEqual(expected.RemainderElements, actual.RemainderElements);
        }

        /// <summary>
        /// Method for testing multiplication operator overload.
        /// </summary>
        [TestMethod]
        public void GetMultiplicationForTwoPolynomialWith4ArgWhenArgIsPositiveThenOutIs7PositiveArgument()
        {
            // Arrange
            Polynomial PolynomialOne = new Polynomial(
                //500x^3 + x^2 + x^1 + 2
                elements: new double[] { 2, 1, 1, 500 });
            Polynomial PolynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + 2
                elements: new double[] { 2, 1, 1, 1 });

            Polynomial expected = new Polynomial(
                //500x ^ 6 + 501x ^ 5 + 502x ^ 4 + 1004x ^ 3 + 5x ^ 2 + 4x ^ 1 + 4
                elements: new double[] { 4, 4, 5, 1004, 502, 501, 500 });

            //Act
            Polynomial actual = PolynomialOne * PolynomialTwo;

            // Assert
            CollectionAssert.AreEqual(expected.Elements, actual.Elements);
        }

        /// <summary>
        /// Method for testing multiplication operator overload.
        /// </summary>
        [TestMethod]
        public void GetMultiplicationForTwoPolynomialWith4ArgWhenArgIsNegativeThenOutIs7PositiveArgument()
        {
            // Arrange
            Polynomial PolynomialOne = new Polynomial(
                //-x^3 + -x^2 + -x^1 + -1
                elements: new double[] { -1, -1, -1, -1 });
            Polynomial PolynomialTwo = new Polynomial(
                //-x^3 + -x^2 + -x^1 + -1
                elements: new double[] { -1, -1, -1, -1 });

            Polynomial expected = new Polynomial(
                //x ^ 6 + 2x ^ 5 + 3x ^ 4 + 4x ^ 3 + 3x ^ 2 + 2x ^ 1 + 1
                elements: new double[] { 1, 2, 3, 4, 3, 2, 1 });

            //Act
            Polynomial actual = PolynomialOne * PolynomialTwo;

            // Assert
            CollectionAssert.AreEqual(expected.Elements, actual.Elements);
        }

        /// <summary>
        /// Method for testing multiplication operator overload.
        /// </summary>
        [TestMethod]
        public void GetMultiplicationForTwoPolynomialWith4ArgWhenFirstPolynomialHasNegativeArgThenOutIs7NegativeArgument()
        {
            // Arrange
            Polynomial PolynomialOne = new Polynomial(
                //-x^3 + -x^2 + -x^1 + -1
                elements: new double[] { -1, -1, -1, -1 });
            Polynomial PolynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { 1, 1, 1, 1 });

            Polynomial expected = new Polynomial(
                //−x^6 −2x^5 −3x^4 −4x^3 −3x^2 −2x^1 −1
                elements: new double[] { -1, -2, -3, -4, -3, -2, -1 });

            //Act
            Polynomial actual = PolynomialOne * PolynomialTwo;

            // Assert
            CollectionAssert.AreEqual(expected.Elements, actual.Elements);
        }

        /// <summary>
        /// Method for testing multiplication operator overload.
        /// </summary>
        [TestMethod]
        public void GetMultiplicationForTwoPolynomialWith4ArgWhenFirstPolynomialHasZerArgThenOutIs7ZeroArgument()
        {
            // Arrange
            Polynomial PolynomialOne = new Polynomial(
                //-x^3 + -x^2 + -x^1 + -1
                elements: new double[] { 0, 0, 0, 0 });
            Polynomial PolynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { 1, 1, 1, 1 });

            Polynomial expected = new Polynomial(
                //x^6 +x^5 +x^4 +x^3 +x^2 +x^1 + 0
                elements: new double[] { 0, 0, 0, 0, 0, 0, 0 });

            //Act
            Polynomial actual = PolynomialOne * PolynomialTwo;

            // Assert
            CollectionAssert.AreEqual(expected.Elements, actual.Elements);
        }

        /// <summary>
        /// Method for testing the overload of the summation operator.
        /// </summary>
        [TestMethod]
        public void GetSumForTwoPolynomialWhenPolynomialHasFoutArgThenOutIsFourArgument()
        {
            // Arrange
            Polynomial PolynomialOne = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { 1, 1, 1, 1});
            Polynomial PolynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { 1, 1, 1, 1 });

            Polynomial expected = new Polynomial(
                //2x^3 + 2x^2 + 2x^1 + 2
                elements: new double[] { 2, 2, 2, 2 });

            //Act
            Polynomial actual = PolynomialOne + PolynomialTwo;

            // Assert
            CollectionAssert.AreEqual(expected.Elements, actual.Elements);
        }

        /// <summary>
        /// Method for testing the overload of the summation operator.
        /// </summary>
        [TestMethod]
        public void GetSumForTwoPolynomialWhenFirstPolynomialLessThenSecondThenOutIsFourArgument()
        {
            // Arrange
            Polynomial PolynomialOne = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { 1, 1, 1 });
            Polynomial PolynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { 1, 1, 1, 1 });

            Polynomial expected = new Polynomial(
                //2x^3 + 2x^2 + 2x^1 + 2
                elements: new double[] { 2, 2, 2, 1 });

            //Act
            Polynomial actual = PolynomialOne + PolynomialTwo;

            // Assert
            CollectionAssert.AreEqual(expected.Elements, actual.Elements);
        }

        /// <summary>
        /// Method for testing the overload of the summation operator.
        /// </summary>
        [TestMethod]
        public void GetSumForTwoPolynomialWhenSecondtPolynomialLessThenFirstThenOutIsFourArgument()
        {
            // Arrange
            Polynomial PolynomialOne = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { 1, 1, 1, 1});
            Polynomial PolynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { 1, 1, 1 });

            Polynomial expected = new Polynomial(
                //2x^3 + 2x^2 + 2x^1 + 2
                elements: new double[] { 2, 2, 2, 1 });

            //Act
            Polynomial actual = PolynomialOne + PolynomialTwo;

            // Assert
            CollectionAssert.AreEqual(expected.Elements, actual.Elements);
        }

        /// <summary>
        /// Method for testing the overload of the summation operator.
        /// </summary>
        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void GetSumForTwoPolynomialWhenFirstPolynomialIsNullThenOutIsNullReferenceException()
        {
            // Arrange
            Polynomial PolynomialOne = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: null);
            Polynomial PolynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { 1, 1, 1 });

            //Act
            Polynomial actual = PolynomialOne + PolynomialTwo;
        }

        /// <summary>
        /// Method for testing the overload of the subtraction operator.
        /// </summary>
        [TestMethod]
        public void GetSubtractionForTwoPolynomialWhenPolynomialHasFoutArgThenOutIsFourArgument()
        {
            // Arrange
            Polynomial PolynomialOne = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { 1, 1, 1, 1 });
            Polynomial PolynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { 1, 1, 1, 1 });

            Polynomial expected = new Polynomial(
                //0x^3 + 0x^2 + 0x^1 + 0
                elements: new double[] { 0, 0, 0, 0 });

            //Act
            Polynomial actual = PolynomialOne - PolynomialTwo;

            // Assert
            CollectionAssert.AreEqual(expected.Elements, actual.Elements);
        }

        /// <summary>
        /// Method for testing the overload of the subtraction operator.
        /// </summary>
        [TestMethod]
        public void GetSubtractionForTwoPolynomialWhenFirstPolynomialLessThenSecondThenOutIsFourArgument()
        {
            // Arrange
            Polynomial PolynomialOne = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { 1, 1, 1 });
            Polynomial PolynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { 1, 1, 1, 1 });

            Polynomial expected = new Polynomial(
                //1x^3 + 0x^2 + 0x^1 + 0
                elements: new double[] { 0, 0, 0, 1 });

            //Act
            Polynomial actual = PolynomialOne - PolynomialTwo;

            // Assert
            CollectionAssert.AreEqual(expected.Elements, actual.Elements);
        }

        /// <summary>
        /// Method for testing the overload of the subtraction operator.
        /// </summary>
        [TestMethod]
        public void GetSubtractionForTwoPolynomialWhenSecondtPolynomialLessThenFirstThenOutIsFourArgument()
        {
            // Arrange
            Polynomial PolynomialOne = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { 1, 1, 1, 1 });
            Polynomial PolynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { 1, 1, 1 });

            Polynomial expected = new Polynomial(
                //1x^3 + 0x^2 + 0x^1 + 0
                elements: new double[] { 0, 0, 0, 1 });

            //Act
            Polynomial actual = PolynomialOne - PolynomialTwo;

            // Assert
            CollectionAssert.AreEqual(expected.Elements, actual.Elements);
        }

        /// <summary>
        /// Method for testing the overload of the subtraction operator.
        /// </summary>
        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void GetSubtractionForTwoPolynomialWhenFirstPolynomialIsNullThenOutIsNullReferenceException()
        {
            // Arrange
            Polynomial PolynomialOne = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: null);
            Polynomial PolynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { 1, 1, 1 });

            //Act
            Polynomial actual = PolynomialOne - PolynomialTwo;
        }
    }
}
