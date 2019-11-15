using Microsoft.VisualStudio.TestTools.UnitTesting;
using OverloadOperationsTask1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadOperationsTask1.Tests
{
    [TestClass()]
    public class VectorTests
    {

        /// <summary>
        /// Test for correct calculation operator -subtracts one vector from another 
        /// when numbers is positive.
        /// </summary>
        [TestMethod]
        public void GivenOperatorSubtracts_ForVectorWhenNumbersIsPositiveOutIsPositive()
        {
            // Arrange
            Vector vectorOne = new Vector(10, 20, 21);
            Vector vectorTwo = new Vector(9, 10, 20);
            Vector expected = new Vector(1, 10, 1);

            // Act
            Vector actual = vectorOne - vectorTwo;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for correct calculation operator -subtracts one vector from another 
        /// when numbers is negative.
        /// </summary>
        [TestMethod]
        public void GivenOperatorSubtracts_ForVectorWhenNumbersIsNegativeOutIsNegative()
        {
            // Arrange
            Vector vectorOne = new Vector(-10, -20, -21);
            Vector vectorTwo = new Vector(-9, -10, -20);
            Vector expected = new Vector(-1, -10, -1);

            // Act
            Vector actual = vectorOne - vectorTwo;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for operator != when vectors is different.
        /// </summary>
        [TestMethod]
        public void GivenOperatorNotEqual_ForVectorWhenVectorIsDifferentOutIsTrue()
        {
            // Arrange
            Vector vectorOne = new Vector(10, 20, 21);
            Vector vectorTwo = new Vector(9, 10, 20);

            // Act
            bool actualBool = vectorOne != vectorTwo;

            // Assert
            Assert.IsTrue(actualBool);
        }

        /// <summary>
        /// Test for operator != when vectors is the same.
        /// </summary>
        [TestMethod]
        public void GivenOperatorNotEqual_ForVectorWhenVectorIsTheSameOutIsFalse()
        {
            // Arrange
            Vector vectorOne = new Vector(10, 20, 21);
            Vector vectorTwo = new Vector(10, 20, 21);

            // Act
            bool actualBool = vectorOne != vectorTwo;

            // Assert
            Assert.IsFalse(actualBool);
        }

        /// <summary>
        /// Test for operator == when vectors is different.
        /// </summary>
        [TestMethod]
        public void GivenOperatorEqual_ForVectorWhenVectorIsDifferentOutIsFalse()
        {
            // Arrange
            Vector vectorOne = new Vector(10, 20, 21);
            Vector vectorTwo = new Vector(9, 10, 20);

            // Act
            bool actualBool = vectorOne == vectorTwo;

            // Assert
            Assert.IsFalse(actualBool);
        }

        /// <summary>
        /// Test for operator == when vectors is the same.
        /// </summary>
        [TestMethod]
        public void GivenOperatorEqual_ForVectorWhenVectorIsTheSameOutIsTrue()
        {
            // Arrange
            Vector vectorOne = new Vector(10, 20, 21);
            Vector vectorTwo = new Vector(10, 20, 21);

            // Act
            bool actualBool = vectorOne == vectorTwo;

            // Assert
            Assert.IsTrue(actualBool);
        }

        /// <summary>
        /// Test for correct calculation operator +Adds one vector to another 
        /// when numbers is positive.
        /// </summary>
        [TestMethod]
        public void GivenOperatorAdds_ForVectorWhenNumbersIsPositiveOutIsPositive()
        {
            // Arrange
            Vector vectorOne = new Vector(10, 20, 21);
            Vector vectorTwo = new Vector(9, 10, 20);
            Vector expected = new Vector(19, 30, 41);

            // Act
            Vector actual = vectorOne + vectorTwo;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for correct calculation operator +Adds one vector to another 
        /// when numbers is negative.
        /// </summary>
        [TestMethod]
        public void GivenOperatorAdds_ForVectorWhenNumbersIsNegativeOutIsNegative()
        {
            // Arrange
            Vector vectorOne = new Vector(-10, -20, -21);
            Vector vectorTwo = new Vector(-9, -10, -20);
            Vector expected = new Vector(-19, -30, -41);

            // Act
            Vector actual = vectorOne + vectorTwo;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for correct calculation operator *Multiplies a vector by a number 
        /// when numbers is positive.
        /// </summary>
        [TestMethod]
        public void GivenOperatorMultiplies_ForVectorWhenNumbersIsPositiveOutIsPositive()
        {
            // Arrange
            Vector vectorOne = new Vector(10, 20, 21);
            var positiveNumFive = 5;
            Vector expected = new Vector(50, 100, 105);

            // Act
            var actualOne = vectorOne * positiveNumFive;
            var actualTwo = positiveNumFive * vectorOne;
            // Assert
            Assert.AreEqual(expected, actualOne);
            Assert.AreEqual(expected, actualTwo);
        }

        /// <summary>
        /// Test for correct calculation operator *Multiplies a vector by a number 
        /// when numbers is negative.
        /// </summary>
        [TestMethod]
        public void GivenOperatorMultiplies_ForPositiveVectorWhenNumbersIsNegativeOutIsNegative()
        {
            // Arrange
            Vector vectorOne = new Vector(10, 20, 21);
            var negativeNumFive = -5;
            Vector expected = new Vector(-50, -100, -105);

            // Act
            var actualOne = vectorOne * negativeNumFive;
            var actualTwo = negativeNumFive * vectorOne;

            // Assert
            Assert.AreEqual(expected, actualOne);
            Assert.AreEqual(expected, actualTwo);
        }

        /// <summary>
        /// Test for correct calculation operator *Multiplies a vector by a number 
        /// when numbers is positive.
        /// </summary>
        [TestMethod]
        public void GivenOperatorMultiplies_ForNegativeVectorWhenNumbersIsPositiveOutIsNegative()
        {
            // Arrange
            Vector vectorOne = new Vector(-10, -20, -21);
            var positiveNumFive = 5;
            Vector expected = new Vector(-50, -100, -105);

            // Act
            var actualOne = vectorOne * positiveNumFive;
            var actualTwo = positiveNumFive * vectorOne;

            // Assert
            Assert.AreEqual(expected, actualOne);
            Assert.AreEqual(expected, actualTwo);
        }

        /// <summary>
        /// Test for correct calculation operator *Multiplies a vector by a number 
        /// when numbers is negative.
        /// </summary>
        [TestMethod]
        public void GivenOperatorMultiplies_ForNegativeVectorWhenNumbersIsNegativeOutIsPositive()
        {
            // Arrange
            Vector vectorOne = new Vector(-10, -20, -21);
            var negativeNumFive = -5;
            Vector expected = new Vector(50, 100, 105);

            // Act
            var actualOne = vectorOne * negativeNumFive;
            var actualTwo = negativeNumFive * vectorOne;

            // Assert
            Assert.AreEqual(expected, actualOne);
            Assert.AreEqual(expected, actualTwo);
        }

        /// <summary>
        /// Test for correct calculation operator / Divides a vector by a number 
        /// when numbers is positive.
        /// </summary>
        [TestMethod]
        public void GivenOperatorDivides_ForVectorWhenNumbersIsPositiveOutIsPositive()
        {
            // Arrange
            Vector vectorOne = new Vector(10, 20, 25);
            var positiveNumFive = 5;
            Vector expectedOne = new Vector(2, 4, 5);
            Vector expectedTwo = new Vector(0.5, 0.25, 0.2);

            // Act
            var actualOne = vectorOne / positiveNumFive;
            var actualTwo = positiveNumFive / vectorOne;

            // Assert
            Assert.AreEqual(expectedOne, actualOne);
            Assert.AreEqual(expectedTwo, actualTwo);
        }

        /// <summary>
        /// Test for correct calculation operator / Divides a vector by a number 
        /// when numbers is negative.
        /// </summary>
        [TestMethod]
        public void GivenOperatorDivides_ForPositiveVectorWhenNumbersIsNegativeOutIsNegative()
        {
            // Arrange
            Vector vectorOne = new Vector(10, 20, 25);
            var negativeNumFive = -5;
            Vector expectedOne = new Vector(-2, -4, -5);
            Vector expectedTwo = new Vector(-0.5, -0.25, -0.2);

            // Act
            var actualOne = vectorOne / negativeNumFive;
            var actualTwo = negativeNumFive / vectorOne;

            // Assert
            Assert.AreEqual(expectedOne, actualOne);
            Assert.AreEqual(expectedTwo, actualTwo);
        }

        /// <summary>
        /// Test for correct calculation operator / Divides a vector by a number 
        /// when numbers is positive.
        /// </summary>
        [TestMethod]
        public void GivenOperatorDivides_ForNegativeVectorWhenNumbersIsPositiveOutIsNegative()
        {
            // Arrange
            Vector vectorOne = new Vector(-10, -20, -25);
            var positiveNumFive = 5;
            Vector expectedOne = new Vector(-2, -4, -5);
            Vector expectedTwo = new Vector(-0.5, -0.25, -0.2);

            // Act
            var actualOne = vectorOne / positiveNumFive;
            var actualTwo = positiveNumFive / vectorOne;

            // Assert
            Assert.AreEqual(expectedOne, actualOne);
            Assert.AreEqual(expectedTwo, actualTwo);
        }

        /// <summary>
        /// Test for correct calculation operator / Divides a vector by a number 
        /// when numbers is negative.
        /// </summary>
        [TestMethod]
        public void GivenOperatorDivides_ForNegativeVectorWhenNumbersIsNegativeOutIsPositive()
        {
            // Arrange
            Vector vectorOne = new Vector(-10, -20, -25);
            var negativeNumFive = -5;
            Vector expectedOne = new Vector(2, 4, 5);
            Vector expectedTwo = new Vector(0.5, 0.25, 0.2);

            // Act
            var actualOne = vectorOne / negativeNumFive;
            var actualTwo = negativeNumFive / vectorOne;

            // Assert
            Assert.AreEqual(expectedOne, actualOne);
            Assert.AreEqual(expectedTwo, actualTwo);
        }

        /// <summary>
        /// Test for correct get property X, Y and Z from vector 
        /// when numbers is positive.
        /// </summary>
        [TestMethod]
        public void GivenX_Y_Z_ForGetDataWhenNumbers_2_4_6_OutIsPositive()
        {
            // Arrange
            Vector vectorOne = new Vector(2, 4, 6);
            var expectedX = 2;
            var expectedY = 4;
            var expectedZ = 6;

            // Assert
            Assert.AreEqual(expectedX, vectorOne.X);
            Assert.AreEqual(expectedY, vectorOne.Y);
            Assert.AreEqual(expectedZ, vectorOne.Z);
        }

        /// <summary>
        /// Test for correct get property Magnitude from vector 
        /// when numbers is positive.
        /// </summary>
        [TestMethod]
        public void GivenMagnitude_ForGetDataWhenNumbers_2_4_6_OutIsSqrt_56()
        {
            // Arrange
            Vector vectorOne = new Vector(2, 4, 6);
            var expected = Math.Sqrt(56);

            // Assert
            Assert.AreEqual(expected, vectorOne.Magnitude);
        }

        /// <summary>
        /// Test for correct get property Normalized from vector 
        /// when numbers is positive.
        /// </summary>
        [TestMethod]
        public void GivenNormalized_ForGetDataWhenNumbers_2_4_6_OutIsOne()
        {
            // Arrange
            Vector vectorOne = new Vector(2, 4, 6);

            // Act
            var actualVector = vectorOne.Normalized;

            // Assert
            Assert.AreEqual(1, actualVector.Magnitude);
        }

        /// <summary>
        /// Test for correct get property SqrMagnitude from vector 
        /// when numbers is positive.
        /// </summary>
        [TestMethod]
        public void GivenSqrMagnitude_ForGetDataWhenNumbers_2_4_6_OutIs56()
        {
            // Arrange
            Vector vectorOne = new Vector(2, 4, 6);

            // Act 
            var actual = vectorOne.SqrMagnitude;
            var expected =
                        (vectorOne.X * vectorOne.X) +
                        (vectorOne.Y * vectorOne.Y) +
                        (vectorOne.Z * vectorOne.Z);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for correct get property this[int i] from vector 
        /// when numbers is positive.
        /// </summary>
        [TestMethod]
        public void GivenThisInt_i_ForGetDataWhenNumbers_2_4_6_OutIs2_4_6()
        {
            // Arrange
            Vector vectorOne = new Vector(2, 4, 6);

            // Assert
            Assert.AreEqual(vectorOne.X, vectorOne[0]);
            Assert.AreEqual(vectorOne.Y, vectorOne[1]);
            Assert.AreEqual(vectorOne.Z, vectorOne[2]);
        }

        /// <summary>
        /// Test for correct get property this[int i] from vector 
        /// when numbers is out of range.
        /// </summary>
        [ExpectedException(typeof(ArgumentOutOfRangeException),
                "A vector can contain only three elements.")]
        [TestMethod]
        public void GivenThisInt_i_ForGetDataWhenNumbers_2_4_6_OutIsArgumentOutOfRangeException()
        {
            // Arrange
            Vector vectorOne = new Vector(2, 4, 6);
            var axpected = new ArgumentOutOfRangeException("A vector can " +
                        "contain only three elements.");
            // Assert
            Assert.AreEqual(axpected, vectorOne[3]);
        }
    }
}