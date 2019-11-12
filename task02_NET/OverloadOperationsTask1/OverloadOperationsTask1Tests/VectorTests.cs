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
        [TestMethod()]
        public void VectorOperatorsTest()
        {
            Vector vector1 = new Vector(1, -1, 2);
            Vector vector2 = new Vector(1, 1, 1);

            //operator -Subtracts one vector from another.
            Vector actual = vector1 - vector2;
            Vector expected = new Vector(0, -2, 1);
            Assert.AreEqual(expected, actual);

            //operator != Returns true if vectors different.
            bool actualBool = vector1 != vector2;
            Assert.IsTrue(actualBool);

            //operator == Returns true if two vectors are approximately equal.
            actualBool = vector1 == new Vector(1, -1, 2);
            Assert.IsTrue(actualBool);

            //operator +Adds two vectors.
            actual = vector1 + vector2;
            expected = new Vector(2, 0, 3);
            Assert.AreEqual(expected, actual);

            //operator *Multiplies a vector by a number.
            actual = vector1 * 5;
            expected = new Vector(5, -5, 10);
            Assert.AreEqual(expected, actual);

            actual = 5 * vector1;
            Assert.AreEqual(expected, actual);

            //operator / Divides a vector by a number.
            actual = vector1 / 5;
            expected = new Vector(0.2, -0.2, 0.4);
            Assert.AreEqual(expected, actual);
            actual = 5 / vector1;
            Assert.AreEqual(expected, actual);
        }
    }
}