using InheritanceInterfacesAbstractAndClasses;
using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.Figures;
using InheritanceInterfacesAbstractAndClasses.UserExceptions;
using NUnit.Framework;
using System;

namespace InheritanceInterfacesAbstractAndClassesTests.FigureTests
{
    /// <summary>
    /// Tests for <see cref="Square"/>
    /// </summary>
    [TestFixture()]
    public class SquareTest
    {
        /// <summary>
        /// Test cases for type <see cref="Square"/>
        /// </summary>
        /// <param name="actualSideA">Actual square heigh and weigh.</param>
        /// <param name="actualMaterial">Actual square material.</param>
        /// <param name="expectedSideA">Expected square heigh and weigh.</param>
        /// <param name="expectedMaterial">Expected square material.</param>
        [TestCase(100, Material.Film, 100, Material.Film)]
        [TestCase(1000, Material.Paper, 1000, Material.Paper)]
        public void GivenSquareWhenConstructorContainMaterialThenOutIsNewSquare(double actualSideA, Material actualMaterial,
            double expectedSideA, Material expectedMaterial)
        {
            //Arrange
            Square actualSquare = new Square(actualSideA, actualMaterial);

            //Assert
            Assert.AreEqual(new Square(expectedSideA, expectedMaterial), actualSquare);
        }

        /// <summary>
        /// Test cases for type <see cref="Square"/>
        /// Cutting out a square from a square.
        /// </summary>
        /// <param name="actualSideA">Actual square heigh and weigh.</param>
        /// <param name="actualMaterial">Actual square material.</param>
        /// <param name="expectedSideA">Expected square heigh and weigh.</param>
        /// <param name="expectedMaterial">Expected square material.</param>
        [TestCase(100, Material.Film, 100, Material.Film)]
        [TestCase(1000, Material.Paper, 1000, Material.Paper)]
        public void GivenSquareWhenConstructorContainSquareThenOutIsNewSquare(double actualSideA, Material actualMaterial,
            double expectedSideA, Material expectedMaterial)
        {
            //Arrange
            Square sourceSquare = new Square(actualSideA, actualMaterial);

            //Act
            Square actualSquareOne = new Square(sourceSquare, actualSideA);

            //Assert
            Assert.AreEqual(new Square(expectedSideA, expectedMaterial), actualSquareOne);
        }

        /// <summary>
        /// Test cases for type <see cref="Square"/>
        /// Cutting out a square from a rectangle.
        /// </summary>
        /// <param name="actualSideA">Actual square heigh and weigh.</param>
        /// <param name="actualSideB">Actual rectangle weigh.</param>
        /// <param name="actualMaterial">Actual square material.</param>
        /// <param name="expectedSideA">Expected square heigh and weigh.</param>
        /// <param name="expectedMaterial">Expected square material.</param>
        [TestCase(100, 100, Material.Film, 100, Material.Film)]
        [TestCase(1000, 1000, Material.Paper, 1000, Material.Paper)]
        public void GivenSquareWhenConstructorContainRectangleThenOutIsNewSquare(double actualSideA, double actualSideB,
            Material actualMaterial, double expectedSideA, Material expectedMaterial)
        {
            //Arrange
            Rectangle sourceRectangle = new Rectangle(actualSideA, actualSideB, actualMaterial);

            //Act
            Square actualSquareTwo = new Square(sourceRectangle, actualSideA);

            //Assert
            Assert.AreEqual(new Square(expectedSideA, expectedMaterial), actualSquareTwo);
        }

        /// <summary>
        /// Test cases for type <see cref="Square"/>
        /// Cutting out a square from a circle.
        /// </summary>
        /// <param name="actualSideA">Actual square heigh and weigh.</param>
        /// <param name="actualRadius">Actual circle radius.</param>
        /// <param name="actualMaterial">Actual square material.</param>
        /// <param name="expectedSideA">Expected square heigh and weigh.</param>
        /// <param name="expectedMaterial">Expected square material.</param>
        [TestCase(100, 100, Material.Film, 100, Material.Film)]
        [TestCase(1000, 1000, Material.Paper, 1000, Material.Paper)]
        public void GivenSquareWhenConstructorContainCircleThenOutIsNewSquare(double actualSideA, double actualRadius,
            Material actualMaterial, double expectedSideA, Material expectedMaterial)
        {
            //Arrange
            Circle sourceCircle = new Circle(actualRadius, actualMaterial);

            //Act
            Square actualSquareThree = new Square(sourceCircle, actualSideA);

            //Assert
            Assert.AreEqual(new Square(expectedSideA, expectedMaterial), actualSquareThree);
        }

        /// <summary>
        /// Test cases for type <see cref="Square"/>
        /// Cutting out a square from a sheet.
        /// </summary>
        /// <param name="actualSideA">Actual square heigh and weigh.</param>
        /// <param name="actualMaterial">Actual square material.</param>
        /// <param name="expectedSideA">Expected square heigh and weigh.</param>
        /// <param name="expectedMaterial">Expected square material.</param>
        [TestCase(100, Material.Film, 100, Material.Film)]
        [TestCase(1000, Material.Paper, 1000, Material.Paper)]
        public void GivenSquareWhenConstructorContainSheetThenOutIsNewSquare(double actualSideA,
            Material actualMaterial, double expectedSideA, Material expectedMaterial)
        {
            //Arrange
            Sheet sourceSheet = new Sheet(actualMaterial);

            //Act
            Square actualSquare = new Square(sourceSheet, actualSideA);

            //Assert
            Assert.AreEqual(new Square(expectedSideA, expectedMaterial), actualSquare);
        }

        /// <summary>
        /// Test cases for type <see cref="Square"/>
        /// Cutting a square from a smaller workpiece then CutException.
        /// </summary>
        /// <param name="actualSideA">Actual square heigh and weigh.</param>
        /// <param name="actualMaterial">Actual square material.</param>
        /// <param name="expectedSideA">Expected square heigh and weigh.</param>
        [TestCase(100, Material.Film, 110)]
        [TestCase(1000, Material.Paper, 1100)]
        public void GivenSquareWhenConstructorContainFigureThenOutIsCutException(double actualSideA, Material actualMaterial,
            double expectedSideA)
        {
            //Arrange
            Square sourceSquare = new Square(actualSideA, actualMaterial);

            //Assert
            Assert.That(() => new Square(sourceSquare, expectedSideA), Throws.TypeOf<CutException>());
        }

        /// <summary>
        /// Test cases for type <see cref="Square.SideA"/>
        /// with sideA equel 0 of negative then ArgumentException.
        /// </summary>
        /// <param name="expectedSideA">Expected square material.</param>
        /// <param name="expectedMaterial">Expected square material.</param>
        [TestCase(-100, Material.Film)]
        [TestCase(-1000, Material.Paper)]
        public void GivenSideAWhenConstructorContainFigureThenOutIsArgumentException(double expectedSideA, Material expectedMaterial)
        {
            //Assert
            Assert.That(() => new Square(expectedSideA, expectedMaterial), Throws.TypeOf<ArgumentException>());
        }

        /// <summary>
        /// Test cases for type <see cref="Square.GetPerimeter"/>
        /// </summary>
        /// <param name="actualSideA">Actual square heigh and weigh.</param>
        /// <param name="expectedPerimeter">Expected square perimeter</param>
        [TestCase(100, 400)]
        [TestCase(1000, 4000)]
        [TestCase(1100, 4400)]
        public void GivenGetPerimeterThenOutIsPerimeter(double actualSideA, double expectedPerimeter)
        {
            //Arrange
            Square actualSquare = new Square(actualSideA, Material.Paper);

            //Act
            double actualPerimeter = actualSquare.GetPerimeter();

            //Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        /// <summary>
        /// Test cases for type <see cref="Square.GetHashCode"/>
        /// </summary>
        /// <param name="actualSideA">Actual square heigh and weigh.</param>
        /// <param name="expectedHashCode">Expected square HashCode</param>
        [TestCase(100, 1079574528)]
        [TestCase(1000, 1083129856)]
        [TestCase(1100, 1083256832)]
        public void GivenGetHashCodeThenOutIsGetHashCode(double actualSideA, double expectedHashCode)
        {
            //Arrange
            Square actualSquare = new Square(actualSideA, Material.Film);

            //Act
            double actualHashCode = actualSquare.GetHashCode();

            //Assert
            Assert.AreEqual(expectedHashCode, actualHashCode);
        }

        /// <summary>
        /// Test cases for type <see cref="Square.Color"/>
        /// </summary>
        /// <param name="actualSideA">Actual square heigh and weigh.</param>
        /// <param name="actualMaterial">Actual square material.</param>
        /// <param name="actualColor">Actual square color.</param>
        /// <param name="expectedColor">Expected square color.</param>
        /// <param name="expectedMaterial">Expected square material.</param>
        /// <param name="expectedSideA">Expected square heigh and weigh.</param>
        [TestCase(100, Material.Paper, Colors.Blue,
            100, Material.Paper, Colors.Blue)]
        [TestCase(100, Material.Paper, Colors.Green,
            100, Material.Paper, Colors.Green)]
        [TestCase(100, Material.Paper, Colors.Orange,
            100, Material.Paper, Colors.Orange)]
        [TestCase(100, Material.Paper, Colors.Red,
            100, Material.Paper, Colors.Red)]
        public void GivenSetColorWhenMaterialFigurePaperThenOutIsFigureWithColor(double actualSideA, Material actualMaterial, Colors actualColor,
            double expectedSideA, Material expectedMaterial, Colors expectedColor)
        {
            //Arrange
            Square square = new Square(actualSideA, actualMaterial);
            Square expectedSquare = new Square(expectedSideA, expectedMaterial);

            //Act
            square.Color = actualColor;
            expectedSquare.Color = expectedColor;

            //Assert
            Assert.AreEqual(expectedSquare, square);
        }

        /// <summary>
        /// Test cases for type <see cref="Square.Color"/>
        /// </summary>
        /// <param name="actualSideA">Actual square heigh and weigh.</param>
        /// <param name="actualMaterial">Actual square material.</param>
        /// <param name="actualColor">Actual square color.</param>
        /// <param name="expectedColor">Expected square color.</param>
        /// <param name="expectedMaterial">Expected square material.</param>
        /// <param name="expectedSideA">Expected square heigh and weigh.</param>
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
            Square square = new Square(actualSideA, actualMaterial);
            Square expectedSquare = new Square(expectedSideA, expectedMaterial);

            //Act
            square.Color = actualColor;
            expectedSquare.Color = expectedColor;

            //Assert
            Assert.AreEqual(expectedColor, square.Color);
        }

        /// <summary>
        /// Test cases for type <see cref="Square.Color"/>
        /// </summary>
        /// <param name="actualSideA">Actual square heigh and weigh.</param>
        /// <param name="actualMaterial">Actual square material.</param>
        /// <param name="actualColor">Actual square color.</param>
        [TestCase(100, Material.Paper, Colors.Blue)]
        [TestCase(100, Material.Paper, Colors.Green)]
        [TestCase(100, Material.Paper, Colors.Orange)]
        [TestCase(100, Material.Paper, Colors.Red)]
        public void GivenSetColorWhenMaterialFigurePaperThenOutIsColorException(double actualSideA, Material actualMaterial, Colors actualColor)
        {
            //Arrange
            Square square = new Square(actualSideA, actualMaterial);

            //Act
            square.Color = actualColor;
            
            //Assert
            Assert.That(() => square.Color = Colors.White, Throws.TypeOf<ColorException>());
        }

        /// <summary>
        /// Test cases for type <see cref="Square.Color"/>
        /// </summary>
        /// <param name="actualSideA">Actual square heigh and weigh.</param>
        /// <param name="actualMaterial">Actual square material.</param>
        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        public void GivenSetColorWhenMaterialFigureFilmThenOutIsColorException(double actualSideA, Material actualMaterial)
        {
            //Arrange
            Square square = new Square(actualSideA, actualMaterial);

            //Assert
            Assert.That(() => square.Color = Colors.White, Throws.TypeOf<ColorException>());
        }

    }
}
