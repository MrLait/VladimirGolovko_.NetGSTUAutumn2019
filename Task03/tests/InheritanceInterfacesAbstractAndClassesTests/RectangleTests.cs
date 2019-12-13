using NUnit.Framework;
using InheritanceInterfacesAbstractAndClasses;

namespace InheritanceInterfacesAbstractAndClassesTests
{
    /// <summary>
    /// asdad
    /// </summary>
    [TestFixture]
    public class RectangleTests
    {

        [Test]
        public void GivenRectangleCtr_ForCutSquereFromReqcangle_OutIsNewSquere()
        {
            //Arrange
            var rectangle = new Rectangle(10,10);
            var squere = new Square(10);

            var test = new Rectangle((squere));
            //Assert
            Assert.AreEqual(null, new Rectangle(squere));
        }


        ///// <summary>
        ///// Test to verify the correct ASide and BSide property
        ///// </summary>
        //[TestCase(2,2,2)]
        //public void GivenASideAndBSide_ForRectangleWhen_aSideAnd_bSide_2ThenOutIs2(double aSide, double bSide, double exepted)
        //{
        //    //Arrange 
        //    Rectangle rectangle = new Rectangle(aSide, bSide);

        //    double acualASide;
        //    double acualBSide;

        //    //Act
        //    acualASide = rectangle.ASide;
        //    acualBSide = rectangle.BSide;

        //    //Assert
        //    Assert.AreEqual(exepted, acualASide);
        //    Assert.AreEqual(exepted, acualBSide);
        }

        ///// <summary>
        ///// Test to verify the correct ASide property with nagative number
        ///// </summary>
        //[ExpectedException(typeof(ArgumentException))]
        //[TestMethod()]
        //public void GivenASide_ForRectangleWhen_aSide_minus2ThenOutIsArgumentException()
        //{
        //    //Arrange 
        //    Rectangle rectangle = new Rectangle
        //    {
        //        ASide = -2
        //    };
        //}

        ///// <summary>
        ///// Test to verify the correct BSide property with nagative number
        ///// </summary>
        //[ExpectedException(typeof(ArgumentException))]
        //[TestMethod()]
        //public void GivenBSide_ForRectangleWhen_bSide_minus2ThenOutIsArgumentException()
        //{
        //    //Arrange 
        //    Rectangle rectangle = new Rectangle
        //    {
        //        BSide = -2
        //    };
        //}

        ///// <summary>
        ///// Test to verify the correct ASide property with zero
        ///// </summary>
        //[ExpectedException(typeof(ArgumentException))]
        //[TestMethod()]
        //public void GivenASide_ForRectangleWhen_aSide_ZeroThenOutIsArgumentException()
        //{
        //    //Arrange 
        //    Rectangle rectangle = new Rectangle()
        //    {
        //        ASide = 0
        //    };
        //}

        ///// <summary>
        ///// Test to verify the correct BSide property with zero
        ///// </summary>
        //[ExpectedException(typeof(ArgumentException))]
        //[TestMethod()]
        //public void GivenBSide_ForRectangleWhen_bSide_ZeroThenOutIsArgumentException()
        //{
        //    //Arrange 
        //    Rectangle rectangle = new Rectangle()
        //    {
        //        BSide = 0
        //    };
        //}

        ///// <summary>
        ///// Test for correct calculation the area of the rectangle 
        ///// </summary>
        //[TestMethod()]
        //public void GivenGetAreaFigure_ForRectangleWhen_aSideAndbSide_2ThenOutIs4()
        //{
        //    //Arrange 
        //    Rectangle rectangle = new Rectangle(2, 2);
        //    double expectedArea = 4;
        //    double acualArea;

        //    //Act
        //    acualArea = rectangle.GetAreaFigure();

        //    //Assert
        //    Assert.AreEqual(expectedArea, acualArea);
        //}

        ///// <summary>
        ///// Test to verify the correct GetAreaFigure method with nagative number
        ///// </summary>
        //[ExpectedException(typeof(ArgumentException))]
        //[TestMethod()]
        //public void GivenGetAreaFigure_ForRectangleWhen_aSideAndbSide_minus2ThenOutIsArgumentException()
        //{
        //    //Arrange 
        //    Rectangle rectangle = new Rectangle(-2, -2);
        //}

        ///// <summary>
        ///// Test to verify the correct GetAreaFigure method with zero
        ///// </summary>
        //[ExpectedException(typeof(ArgumentException))]
        //[TestMethod()]
        //public void GivenGetAreaFigure_ForRectangleWhen_sidesIsZeroThenOutIsArgumentException()
        //{
        //    //Arrange 
        //    Rectangle rectangle = new Rectangle(0, 0);
        //}

        ///// <summary>
        ///// Test for correct calculation the perimeter of the rectangle 
        ///// </summary>
        //[TestMethod()]
        //public void GivenGetPerimeterFigure_ForRectangleWhen_sideIs2ThenOutIs4()
        //{
        //    //Arrange 
        //    Rectangle rectangle = new Rectangle(2, 2);
        //    double expectedArea = 8;
        //    double acualArea;

        //    //Act
        //    acualArea = rectangle.GetPerimeterFigure();

        //    //Assert
        //    Assert.AreEqual(expectedArea, acualArea);
        //}

        ///// <summary>
        ///// Test to verify the correct GetPerimeterFigure method with nagative number
        ///// </summary>
        //[ExpectedException(typeof(ArgumentException))]
        //[TestMethod()]
        //public void GivenGetPerimeterFigure_ForRectangleWhen_sidesIsMinus2ThenOutIsArgumentException()
        //{
        //    //Arrange 
        //    Rectangle rectangle = new Rectangle(-2, -2);
        //}

        ///// <summary>
        ///// Test to verify the correct GetPerimeterFigure method with zero
        ///// </summary>
        //[ExpectedException(typeof(ArgumentException))]
        //[TestMethod()]
        //public void GivenGetPerimeterFigure_ForRectangleWhen_sidesIsZeroThenOutIsArgumentException()
        //{
        //    //Arrange 
        //    Rectangle rectangle = new Rectangle(0, 0);
        //}
}

