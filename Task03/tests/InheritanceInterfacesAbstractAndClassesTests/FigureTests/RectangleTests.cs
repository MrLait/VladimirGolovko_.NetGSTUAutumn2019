using InheritanceInterfacesAbstractAndClasses;
using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.Figures;
using InheritanceInterfacesAbstractAndClasses.UserExceptions;
using NUnit.Framework;
using System;

namespace InheritanceInterfacesAbstractAndClassesTests.FigureTests
{
    /// <summary>
    /// Tests for <see cref="Rectangle"/>
    /// </summary>
    [TestFixture()]
    public class RectangleTest
    {
        /// <summary>
        /// Test cases for type <see cref="Rectangle"/>
        /// </summary>
        /// <param name="actualSideA">Actual rectangle heigh.</param>
        /// <param name="actualSideB">Actual rectangle weigh.</param>
        /// <param name="actualMaterial">Actual rectangle material.</param>
        /// <param name="expectedSideA">Expected rectangle heigh</param>
        /// <param name="expectedSideB">Expected rectangle weigh.</param>
        /// <param name="expectedMaterial">Expected square material.</param>
        [TestCase(100, 100, Material.Film, 100, 100, Material.Film)]
        [TestCase(1000, 1000, Material.Paper, 1000, 1000, Material.Paper)]
        public void GivenRectangleWhenConstructorContainMaterialThenOutIsNewRectangle(double actualSideA, double actualSideB, Material actualMaterial,
            double expectedSideA, double expectedSideB, Material expectedMaterial)
        {
            //Arrange
            Rectangle actuaRectangle = new Rectangle(actualSideA, actualSideB, actualMaterial);

            //Assert
            Assert.AreEqual(new Rectangle(expectedSideA, expectedSideB, expectedMaterial), actuaRectangle);
        }

        /// <summary>
        /// Test cases for type <see cref="Rectangle"/>
        /// Cutting out a rectangle from a square.
        /// </summary>
        /// <param name="actualSideA">Actual rectangle heigh.</param>
        /// <param name="actualSideB">Actual rectangle weigh.</param>
        /// <param name="actualMaterial">Actual rectangle material.</param>
        /// <param name="expectedSideA">Expected rectangle heigh</param>
        /// <param name="expectedSideB">Expected rectangle weigh.</param>
        /// <param name="expectedMaterial">Expected square material.</param>
        [TestCase(100, 100, Material.Film, 100, 100, Material.Film)]
        [TestCase(1000, 1000, Material.Paper, 1000, 1000, Material.Paper)]
        public void GivenRectangleWhenConstructorContainSquareThenOutIsNewRectangle(double actualSideA, double actualSideB, Material actualMaterial,
            double expectedSideA, double expectedSideB, Material expectedMaterial)
        {
            //Arrange
            Square sourceSquare = new Square(actualSideA, actualMaterial);

            //Act
            Rectangle actualRectangle = new Rectangle(sourceSquare, actualSideA, actualSideB);

            //Assert
            Assert.AreEqual(new Rectangle(expectedSideA, expectedSideB, expectedMaterial), actualRectangle);
        }

        /// <summary>
        /// Test cases for type <see cref="Rectangle"/>
        /// Cutting out a rectangle from a rectangle.
        /// </summary>
        /// <param name="actualSideA">Actual rectangle heigh.</param>
        /// <param name="actualSideB">Actual rectangle weigh.</param>
        /// <param name="actualMaterial">Actual rectangle material.</param>
        /// <param name="expectedSideA">Expected rectangle heigh</param>
        /// <param name="expectedSideB">Expected rectangle weigh.</param>
        /// <param name="expectedMaterial">Expected square material.</param>
        [TestCase(100, 100, Material.Film, 100, 100, Material.Film)]
        [TestCase(1000, 1000, Material.Paper, 1000, 1000, Material.Paper)]
        public void GivenRectangleWhenConstructorContainRectangleThenOutIsNewRectangle(double actualSideA, double actualSideB, Material actualMaterial,
            double expectedSideA, double expectedSideB, Material expectedMaterial)
        {
            //Arrange
            Rectangle sourceRectangle = new Rectangle(actualSideA, actualSideB, actualMaterial);

            //Act
            Rectangle actualRectangle = new Rectangle(sourceRectangle, actualSideA, actualSideB);

            //Assert
            Assert.AreEqual(new Rectangle(expectedSideA, expectedSideB, expectedMaterial), actualRectangle);
        }

        /// <summary>
        /// Test cases for type <see cref="Rectangle"/>
        /// Cutting out a rectangle from a circle.
        /// </summary>
        /// <param name="actualSideA">Actual rectangle heigh.</param>
        /// <param name="actualSideB">Actual rectangle weigh.</param>
        /// <param name="actualRadius">Actual circle radius.</param>
        /// <param name="actualMaterial">Actual rectangle material.</param>
        /// <param name="expectedSideA">Expected rectangle heigh</param>
        /// <param name="expectedSideB">Expected rectangle weigh.</param>
        /// <param name="expectedMaterial">Expected square material.</param>
        [TestCase(100, 100, 100, Material.Film, 100, 100, Material.Film)]
        [TestCase(1000, 1000, 1000, Material.Paper, 1000, 1000, Material.Paper)]
        public void GivenRectangleWhenConstructorContainCircleThenOutIsNewRectangle(double actualSideA, double actualSideB, double actualRadius,
            Material actualMaterial, double expectedSideA, double expectedSideB, Material expectedMaterial)
        {
            //Arrange
            Circle sourceCircle = new Circle(actualRadius, actualMaterial);

            //Act
            Rectangle actualRectangle = new Rectangle(sourceCircle, actualSideA, actualSideB);

            //Assert
            Assert.AreEqual(new Rectangle(expectedSideA, expectedSideB, expectedMaterial), actualRectangle);
        }

        /// <summary>
        /// Test cases for type <see cref="Rectangle"/>
        /// Cutting out a rectangle from a sheet.
        /// </summary>
        /// <param name="actualSideA">Actual rectangle heigh.</param>
        /// <param name="actualSideB">Actual rectangle weigh.</param>
        /// <param name="actualMaterial">Actual rectangle material.</param>
        /// <param name="expectedSideA">Expected rectangle heigh</param>
        /// <param name="expectedSideB">Expected rectangle weigh.</param>
        /// <param name="expectedMaterial">Expected square material.</param>
        [TestCase(100, 100, Material.Film, 100, 100, Material.Film)]
        [TestCase(1000, 1000, Material.Paper, 1000, 1000, Material.Paper)]
        public void GivenRectangleWhenConstructorContainSheetThenOutIsNewRectangle(double actualSideA, double actualSideB,
            Material actualMaterial, double expectedSideA, double expectedSideB, Material expectedMaterial)
        {
            //Arrange
            Sheet sourceSheet = new Sheet(actualMaterial);

            //Act
            Rectangle actualRectangle = new Rectangle(sourceSheet, actualSideA, actualSideB);

            //Assert
            Assert.AreEqual(new Rectangle(expectedSideA, expectedSideB, expectedMaterial), actualRectangle);
        }

        /// <summary>
        /// Test cases for type <see cref="Rectangle"/>
        /// Cutting a rectangle from a smaller workpiece then CutException.
        /// </summary>
        /// <param name="actualSideA">Actual rectangle heigh.</param>
        /// <param name="actualSideB">Actual rectangle weigh.</param>
        /// <param name="actualMaterial">Actual rectangle material.</param>
        /// <param name="expectedSideA">Expected rectangle heigh</param>
        /// <param name="expectedSideB">Expected rectangle weigh.</param>
        [TestCase(100, 100, Material.Film, 110, 100)]
        [TestCase(1000, 1000, Material.Paper, 1100, 1000)]
        public void GivenRectangleWhenConstructorContainFigureThenOutIsCutException(double actualSideA, double actualSideB, Material actualMaterial,
            double expectedSideA, double expectedSideB)
        {
            //Arrange
            Rectangle sourceRectangle = new Rectangle(actualSideA, actualSideB, actualMaterial);

            //Assert
            Assert.That(() => new Rectangle(sourceRectangle, expectedSideA, expectedSideB), Throws.TypeOf<CutException>());
        }

        /// <summary>
        /// Test cases for type <see cref="Rectangle.SideB"/>
        /// with sideA equel 0 of negative then ArgumentException.
        /// </summary>
        /// <param name="actualSideA">Actual rectangle heigh.</param>
        /// <param name="actualSideB">Actual rectangle weigh.</param>
        /// <param name="actualMaterial">Actual rectangle material.</param>
        [TestCase(-100, -100, Material.Film)]
        [TestCase(-1000, -1000, Material.Paper)]
        public void GivenSideAandSideBWhenConstructorContainFigureThenOutIsArgumentException(double actualSideA, double actualSideB, Material actualMaterial)
        {
            //Assert
            Assert.That(() => new Rectangle(actualSideA, actualSideB, actualMaterial), Throws.TypeOf<ArgumentException>());
        }

        /// <summary>
        /// Test cases for type <see cref="Rectangle.GetPerimeter"/>
        /// </summary>
        /// <param name="actualSideA">Actual rectangle heigh.</param>
        /// <param name="actualSideB">Actual rectangle weigh.</param>
        /// <param name="expectedPerimeter">Expected rectangle perimeter.</param>
        [TestCase(100, 100, 400)]
        [TestCase(1000, 1000, 4000)]
        [TestCase(1100, 1100, 4400)]
        public void GivenGetPerimeterThenOutIsPerimeter(double actualSideA, double actualSideB, double expectedPerimeter)
        {
            //Arrange
            Rectangle actuaRectangle = new Rectangle(actualSideA, actualSideB, Material.Paper);

            //Act
            double actualPerimeter = actuaRectangle.GetPerimeter();

            //Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        /// <summary>
        /// Test cases for type <see cref="Rectangle.GetHashCode"/>
        /// </summary>
        /// <param name="actualSideA">Actual rectangle heigh.</param>
        /// <param name="actualSideB">Actual rectangle weigh.</param>
        /// <param name="expectedHashCode">Expected rectangle HashCode.</param>
        [TestCase(100, 100, -2135818239)]
        [TestCase(1000, 1000, -2128707583)]
        [TestCase(1100, 1100, -2128453631)]
        public void GivenGetHashCodeThenOutIsGetHashCode(double actualSideA, double actualSideB, double expectedHashCode)
        {
            //Arrange
            Rectangle actuaRectangle = new Rectangle(actualSideA, actualSideB, Material.Paper);

            //Act
            double actualHashCode = actuaRectangle.GetHashCode();

            //Assert
            Assert.AreEqual(expectedHashCode, actualHashCode);
        }

        /// <summary>
        /// Test cases for type <see cref="Rectangle.Color"/>
        /// </summary>
        /// <param name="actualSideA">Actual rectangle heigh and weigh.</param>
        /// <param name="actualMaterial">Actual rectangle material.</param>
        /// <param name="actualColor">Actual rectangle color.</param>
        /// <param name="expectedColor">Expected rectangle color.</param>
        /// <param name="expectedMaterial">Expected rectangle material.</param>
        /// <param name="expectedSideA">Expected rectangle heigh and weigh.</param>
        [TestCase(100, Material.Paper, Colors.Blue,
   100, Material.Paper, Colors.Blue)]
        [TestCase(100, Material.Paper, Colors.Green,
   100, Material.Paper, Colors.Green)]
        [TestCase(100, Material.Paper, Colors.Orange,
   100, Material.Paper, Colors.Orange)]
        [TestCase(100, Material.Paper, Colors.Red,
   100, Material.Paper, Colors.Red)]
        public void GivenGetColorWhenMaterialFigurePaperThenOutIsFigureWithColor(double actualSideA, Material actualMaterial, Colors actualColor,
   double expectedSideA, Material expectedMaterial, Colors expectedColor)
        {
            //Arrange
            Rectangle rectangle = new Rectangle(actualSideA, actualSideA, actualMaterial);
            Rectangle expectedSquare = new Rectangle(expectedSideA, expectedSideA, expectedMaterial);

            //Act
            rectangle.Color = actualColor;
            expectedSquare.Color = expectedColor;

            //Assert
            Assert.AreEqual(expectedColor, rectangle.Color);
        }

        /// <summary>
        /// Test cases for type <see cref="Rectangle.Color"/>
        /// </summary>
        /// <param name="actualSideA">Actual rectangle heigh and weigh.</param>
        /// <param name="actualMaterial">Actual rectangle material.</param>
        /// <param name="actualColor">Actual rectangle color.</param>
        [TestCase(100, Material.Paper, Colors.Blue)]
        [TestCase(100, Material.Paper, Colors.Green)]
        [TestCase(100, Material.Paper, Colors.Orange)]
        [TestCase(100, Material.Paper, Colors.Red)]
        public void GivenSetColorWhenMaterialFigurePaperThenOutIsColorException(double actualSideA, Material actualMaterial, Colors actualColor)
        {
            //Arrange
            Rectangle rectangle = new Rectangle(actualSideA, actualSideA, actualMaterial)
            {
                //Act
                Color = actualColor
            };

            //Assert
            Assert.That(() => rectangle.Color = Colors.White, Throws.TypeOf<ColorException>());
        }

        /// <summary>
        /// Test cases for type <see cref="Rectangle.Color"/>
        /// </summary>
        /// <param name="actualSideA">Actual rectangle heigh and weigh.</param>
        /// <param name="actualMaterial">Actual rectangle material.</param>
        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        public void GivenSetColorWhenMaterialFigureFilmThenOutIsColorException(double actualSideA, Material actualMaterial)
        {
            //Arrange
            Rectangle rectangle = new Rectangle(actualSideA, actualSideA, actualMaterial);

            //Assert
            Assert.That(() => rectangle.Color = Colors.White, Throws.TypeOf<ColorException>());
        }
    }
}
