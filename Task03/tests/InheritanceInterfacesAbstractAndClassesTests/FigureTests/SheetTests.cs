using InheritanceInterfacesAbstractAndClasses;
using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.Figures;
using InheritanceInterfacesAbstractAndClasses.UserExceptions;
using NUnit.Framework;
using System;

namespace InheritanceInterfacesAbstractAndClassesTests.FigureTests
{
    [TestFixture()]
    public class SheetTests
    {
        [TestCase(Material.Film, double.PositiveInfinity)]
        [TestCase(Material.Paper, double.PositiveInfinity)]
        public void GivenGetAreaFigureThenOutIsAreaPositiveInfinity(Material actualMaterial, double expectedArea)
        {
            //Arrange
            Sheet actuaSheet = new Sheet(actualMaterial);

            //Assert
            Assert.AreEqual(expectedArea, actuaSheet.GetAreaFigure());
        }

        [TestCase(Material.Film, double.PositiveInfinity)]
        [TestCase(Material.Paper, double.PositiveInfinity)]
        public void GivenGetPerimeterThenOutIsAreaPositiveInfinity(Material actualMaterial, double expectedArea)
        {
            //Arrange
            Sheet actuaSheet = new Sheet(actualMaterial);

            //Assert
            Assert.AreEqual(expectedArea, actuaSheet.GetPerimeter());
        }
    }
}
