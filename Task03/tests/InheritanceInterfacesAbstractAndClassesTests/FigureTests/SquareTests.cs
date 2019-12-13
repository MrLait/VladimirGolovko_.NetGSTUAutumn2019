using System;
using NUnit.Framework;
using InheritanceInterfacesAbstractAndClasses;
using InheritanceInterfacesAbstractAndClasses.Figures;
using InheritanceInterfacesAbstractAndClasses.Enum;

namespace InheritanceInterfacesAbstractAndClassesTests
{
    /// <summary>
    /// Unit tests for the Squere class.
    /// </summary>
    [TestFixture()]
    public class SquareTests
    {

        [TestCase(1,2)]
        public void Test(int a, int a2)
        {
            Square square = new Square(10, Material.Film);
            Assert.AreEqual(1, 2);

        }

        //[TestCase(10, 10)]
        //[TestCase(25, 25)]
        //[TestCase(double.MaxValue, double.MaxValue)]
        //public void GivenSquarePropertyWhenSideAIsDifferentThenOutIsValidData(double numbers, double expected)
        //{
        //    //Arrange
        //    Square actual = new Square(numbers);

        //    //Assert
        //    NUnit.Framework.Assert.AreEqual(expected, actual.SideA);
        //}

        //[TestCase(0)]
        //[TestCase(double.MinValue)]
        //public void GivenSquarePropertyWhenSideAIsNegativeOrZeroThenOutIsArgumentException(double numbers)
        //{
        //    //Assert
        //    NUnit.Framework.Assert.Throws<ArgumentException>(
        //        () => { new Square(numbers); });
        //}

        ///// <summary>
        ///// Test to verify the correct ASide property
        ///// </summary>
        //[TestMethod()]
        //public void GivenASide_ForSquereWhen_aSide_2ThenOutIs2()
        //{
        //    //Arrange 
        //    Square square = new Square(2);
        //    double expectedASide = 2;
        //    double acual;

        //    //Act
        //    acual = square.ASide;

        //    //Assert
        //    Assert.AreEqual(expectedASide, acual);
        //}

        ///// <summary>
        ///// Test to verify the correct ASide property with nagative number
        ///// </summary>
        //[ExpectedException(typeof(ArgumentException))]
        //[TestMethod()]
        //public void GivenASide_ForSquereWhen_aSide_minus2ThenOutIsArgumentException()
        //{
        //    //Arrange 
        //    Square square = new Square
        //    {
        //        ASide = -2
        //    };
        //}

        ///// <summary>
        ///// Test to verify the correct ASide property with zero
        ///// </summary>
        //[ExpectedException(typeof(ArgumentException))]
        //[TestMethod()]
        //public void GivenASide_ForSquereWhen_aSide_ZeroThenOutIsArgumentException()
        //{
        //    //Arrange 
        //    Square square = new Square
        //    {
        //        ASide = 0
        //    };
        //}

        ///// <summary>
        ///// Test for correct calculation the area of the squere 
        ///// </summary>
        //[TestMethod()]
        //public void GivenGetAreaFigure_ForSquereWhen_aSide_2ThenOutIs4()
        //{
        //    //Arrange 
        //    Square square = new Square(2);
        //    double expectedArea = 4;
        //    double acualArea;

        //    //Act
        //    acualArea = square.GetAreaFigure();

        //    //Assert
        //    Assert.AreEqual(expectedArea, acualArea);
        //}

        ///// <summary>
        ///// Test to verify the correct GetAreaFigure method with nagative number
        ///// </summary>
        //[ExpectedException(typeof(ArgumentException))]
        //[TestMethod()]
        //public void GivenGetAreaFigure_ForSquereWhen_aSide_minus2ThenOutIsArgumentException()
        //{
        //    //Arrange 
        //    Square square = new Square
        //    {
        //        ASide = -2
        //    };
        //}

        ///// <summary>
        ///// Test to verify the correct GetAreaFigure method with zero
        ///// </summary>
        //[ExpectedException(typeof(ArgumentException))]
        //[TestMethod()]
        //public void GivenGetAreaFigure_ForSquereWhen_aSide_ZeroThenOutIsArgumentException()
        //{
        //    //Arrange 
        //    Square square = new Square
        //    {
        //        ASide = 0
        //    };
        //}

        ///// <summary>
        ///// Test for correct calculation the perimeter of the squere 
        ///// </summary>
        //[TestMethod()]
        //public void GivenGetPerimeterFigure_ForSquereWhen_aSide_2ThenOutIs4()
        //{
        //    //Arrange 
        //    Square square = new Square(2);
        //    double expectedArea = 8;
        //    double acualArea;

        //    //Act
        //    acualArea = square.GetPerimeterFigure();

        //    //Assert
        //    Assert.AreEqual(expectedArea, acualArea);
        //}

        ///// <summary>
        ///// Test to verify the correct GetPerimeterFigure method with nagative number
        ///// </summary>
        //[ExpectedException(typeof(ArgumentException))]
        //[TestMethod()]
        //public void GivenGetPerimeterFigure_ForSquereWhen_aSide_minus2ThenOutIsArgumentException()
        //{
        //    //Arrange 
        //    Square square = new Square
        //    {
        //        ASide = -2
        //    };
        //}

        ///// <summary>
        ///// Test to verify the correct GetPerimeterFigure method with zero
        ///// </summary>
        //[ExpectedException(typeof(ArgumentException))]
        //[TestMethod()]
        //public void GivenGetPerimeterFigure_ForSquereWhen_aSide_ZeroThenOutIsArgumentException()
        //{
        //    //Arrange 
        //    Square square = new Square
        //    {
        //        ASide = 0
        //    };
        //}

    }
}