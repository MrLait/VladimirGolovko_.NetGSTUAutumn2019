using InheritanceInterfacesAbstractAndClasses;
using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.Figures;
using InheritanceInterfacesAbstractAndClasses.UserExceptions;
using NUnit.Framework;
using System;

namespace InheritanceInterfacesAbstractAndClassesTests.FigureTests
{
    /// <summary>
    /// Tests for <see cref="Sheet"/>
    /// </summary>
    [TestFixture()]
    public class SheetTests
    {
        /// <summary>
        /// Test cases for type <see cref="Rectangle.GetAreaFigure"/>
        /// </summary>
        /// <param name="actualMaterial">Actual sheet material.</param>
        /// <param name="expectedArea">Expected sheet area.</param>
        [TestCase(Material.Film, double.PositiveInfinity)]
        [TestCase(Material.Paper, double.PositiveInfinity)]
        public void GivenGetAreaFigureThenOutIsAreaPositiveInfinity(Material actualMaterial, double expectedArea)
        {
            //Arrange
            Sheet actuaSheet = new Sheet(actualMaterial);

            //Assert
            Assert.AreEqual(expectedArea, actuaSheet.GetAreaFigure());
        }

        /// <summary>
        /// Test cases for type <see cref="Rectangle.GetPerimeter"/>
        /// </summary>
        /// <param name="actualMaterial">Actual sheet material.</param>
        /// <param name="expectedPerimeter">Expected sheet perimeter.</param>
        [TestCase(Material.Film, double.PositiveInfinity)]
        [TestCase(Material.Paper, double.PositiveInfinity)]
        public void GivenGetPerimeterThenOutIsAreaPositiveInfinity(Material actualMaterial, double expectedPerimeter)
        {
            //Arrange
            Sheet actuaSheet = new Sheet(actualMaterial);

            //Assert
            Assert.AreEqual(expectedPerimeter, actuaSheet.GetPerimeter());
        }
    }
}
