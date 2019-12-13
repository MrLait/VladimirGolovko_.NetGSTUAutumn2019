using Microsoft.VisualStudio.TestTools.UnitTesting;
using InheritanceInterfacesAbstractAndClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceInterfacesAbstractAndClassesTests
{
    [TestClass()]
    public class RectangleTests
    {
        [TestMethod()]
        public void GivenAdd1()
        {
            //Assert
            Assert.AreEqual(4, Rectangle.Add(2, 2));
        }
        [TestMethod()]
        public void GivenAdd2()
        {
            //Assert
            Assert.AreEqual(expected: -1, Rectangle.Add(-3, 2));
        }
    }
}