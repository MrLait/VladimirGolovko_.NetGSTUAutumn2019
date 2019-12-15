using InheritanceInterfacesAbstractAndClasses;
using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.Figures;
using InheritanceInterfacesAbstractAndClasses.UserExceptions;
using NUnit.Framework;
using System;

namespace InheritanceInterfacesAbstractAndClassesTests.FigureTests
{
    /// <summary>
    /// Tests for <see cref="Circle"/>
    /// </summary>
    [TestFixture()]
    public class CircleTest
    {
        /// <summary>
        /// Test cases for type <see cref="Circle"/>
        /// </summary>
        /// <param name="actualRadius">Actual circle radius.</param>
        /// <param name="actualMaterial">Actual circle material.</param>
        /// <param name="expectedRadius">Expected circle material.</param>
        /// <param name="expectedMaterial">Expected circle material.</param>
        [TestCase(100, Material.Film, 100, Material.Film)]
        [TestCase(1000, Material.Paper, 1000, Material.Paper)]
        public void GivenCircleWhenConstructorContainMaterialThenOutIsNewCircle(double actualRadius, Material actualMaterial,
            double expectedRadius, Material expectedMaterial)
        {
            //Arrange
            Circle actualCircle = new Circle(actualRadius, actualMaterial);

            //Assert
            Assert.AreEqual(new Circle(expectedRadius, expectedMaterial), actualCircle);
        }

        /// <summary>
        /// Test cases for type <see cref="Circle"/>.
        /// Cutting out a circle from a square.
        /// </summary>
        /// <param name="actualSideA">Actual square sideA.</param>
        /// <param name="actualRadius">Actual circle radius.</param>
        /// <param name="actualMaterial">Actual circle material.</param>
        /// <param name="expectedRadius">Expected circle material.</param>
        /// <param name="expectedMaterial">Expected circle material.</param>
        [TestCase(100, 30, Material.Film, 30, Material.Film)]
        [TestCase(1000, 300, Material.Paper, 300, Material.Paper)]
        public void GivenCircleWhenConstructorContainSquareThenOutIsNewCircle(double actualSideA, double actualRadius, Material actualMaterial,
            double expectedRadius, Material expectedMaterial)
        {
            //Arrange
            Square sourceSquare = new Square(actualSideA, actualMaterial);

            //Act
            Circle actualCircle = new Circle(sourceSquare, actualRadius);

            //Assert
            Assert.AreEqual(new Circle(expectedRadius, expectedMaterial), actualCircle);
        }

        /// <summary>
        /// Test cases for type <see cref="Circle"/>
        /// Cutting out a circle from a rectangle.
        /// </summary>
        /// <param name="actualSideA">Actual square sideA.</param>
        /// <param name="actualSideB">Actual square sideB.</param>
        /// <param name="actualRadius">Actual circle radius.</param>
        /// <param name="actualMaterial">Actual circle material.</param>
        /// <param name="expectedRadius">Expected circle material.</param>
        /// <param name="expectedMaterial">Expected circle material.</param>
        [TestCase(100, 100, 30, Material.Film, 30, Material.Film)]
        [TestCase(1000, 1000, 300, Material.Paper, 300, Material.Paper)]
        public void GivenCircleWhenConstructorContainRectangleThenOutIsNewCircle(double actualSideA, double actualSideB, double actualRadius,
            Material actualMaterial, double expectedRadius, Material expectedMaterial)
        {
            //Arrange
            Rectangle sourceRectangle = new Rectangle(actualSideA, actualSideB, actualMaterial);

            //Act
            Circle actualCircle = new Circle(sourceRectangle, actualRadius);

            //Assert
            Assert.AreEqual(new Circle(expectedRadius, expectedMaterial), actualCircle);
        }

        /// <summary>
        /// Test cases for type <see cref="Circle"/>
        /// Cutting out a circle from a circle.
        /// </summary>
        /// <param name="actualRadius">Actual circle radius.</param>
        /// <param name="actualMaterial">Actual circle material.</param>
        /// <param name="expectedRadius">Expected circle material.</param>
        /// <param name="expectedMaterial">Expected circle material.</param>
        [TestCase(100, Material.Film, 100, Material.Film)]
        [TestCase(1000, Material.Paper, 1000, Material.Paper)]
        public void GivenCircleWhenConstructorContainCircleThenOutIsNewCircle(double actualRadius,
            Material actualMaterial, double expectedRadius, Material expectedMaterial)
        {
            //Arrange
            Circle sourceCircle = new Circle(actualRadius, actualMaterial);

            //Act
            Circle actualCircle = new Circle(sourceCircle, actualRadius);

            //Assert
            Assert.AreEqual(new Circle(expectedRadius, expectedMaterial), actualCircle);
        }

        /// <summary>
        /// Test cases for type <see cref="Circle"/>
        /// Cutting out a circle from a sheet.
        /// </summary>
        /// <param name="actualRadius">Actual circle radius.</param>
        /// <param name="actualMaterial">Actual circle material.</param>
        /// <param name="expectedRadius">Expected circle material.</param>
        /// <param name="expectedMaterial">Expected circle material.</param>
        [TestCase(100, Material.Film, 100, Material.Film)]
        [TestCase(1000, Material.Paper, 1000, Material.Paper)]
        public void GivenCircleWhenConstructorContainSheetThenOutIsNewCircle(double actualRadius,
            Material actualMaterial, double expectedRadius, Material expectedMaterial)
        {
            //Arrange
            Sheet sourceSheet = new Sheet(actualMaterial);

            //Act
            Circle actualCircle = new Circle(sourceSheet, actualRadius);

            //Assert
            Assert.AreEqual(new Circle(expectedRadius, expectedMaterial), actualCircle);
        }

        /// <summary>
        /// Test cases for type <see cref="Circle.Radius"/>
        /// </summary>
        /// <param name="radius">Actual circle radius.</param>
        /// <param name="expectedRadius">Expected circle material.</param>
        [TestCase(100, 100)]
        [TestCase(1000, 1000)]
        [TestCase(1100, 1100)]
        public void GivenGetRadiusWhenConstructorContainSheetThenOutIsGetRadius(double radius, double expectedRadius)
        {
            //Arrange
            Circle sourceCircle = new Circle(radius, Material.Paper);

            //Act
            var actualRadius = sourceCircle.Radius;

            //Assert
            Assert.AreEqual(expectedRadius, actualRadius);
        }

        /// <summary>
        /// Test cases for type <see cref="Circle"/>
        /// Cutting a circle from a smaller workpiece then CutException.
        /// </summary>
        /// <param name="actualRadius">Actual circle radius.</param>
        /// <param name="actualMaterial">Actual circle material.</param>
        /// <param name="expectedRadius">Expected circle material.</param>
        [TestCase(100, Material.Film, 110)]
        [TestCase(1000, Material.Paper, 1100)]
        public void GivenCircleWhenConstructorContainFigureThenOutIsCutException(double actualRadius, Material actualMaterial,
            double expectedRadius)
        {
            //Arrange
            Circle sourceCircle = new Circle(actualRadius, actualMaterial);

            //Assert
            Assert.That(() => new Circle(sourceCircle, expectedRadius), Throws.TypeOf<CutException>());
        }

        /// <summary>
        /// Test cases for type <see cref="Circle.Radius"/>
        /// with radius equel 0 of negative then ArgumentException.
        /// </summary>
        /// <param name="expectedRadius">Expected circle material.</param>
        /// <param name="expectedMaterial">Expected circle material.</param>
        [TestCase(-100, Material.Film)]
        [TestCase(0, Material.Paper)]
        public void GivenRadiusWhenConstructorContainFigureThenOutIsArgumentException(double expectedRadius, Material expectedMaterial)
        {
            //Assert
            Assert.That(() => new Circle(expectedRadius, expectedMaterial), Throws.TypeOf<ArgumentException>());
        }

        /// <summary>
        /// Test cases for type <see cref="Circle.GetPerimeter"/>
        /// </summary>
        /// <param name="actualRadius">Expected circle radius.</param>
        /// <param name="expectedPerimeter">Expected circle perimeter.</param>
        [TestCase(100, 628.31853071795865)]
        [TestCase(1000, 6283.1853071795858)]
        [TestCase(1100, 6911.5038378975451)]
        public void GivenGetPerimeterFigureThenOutIsPerimeter(double actualRadius, double expectedPerimeter)
        {
            //Arrange
            Circle actualCircle = new Circle(actualRadius, Material.Paper);

            //Act
            double actualPerimeter = actualCircle.GetPerimeter();

            //Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        /// <summary>
        /// Test cases for type <see cref="Circle.GetHashCode"/>
        /// </summary>
        /// <param name="actualRadius">Expected circle radius.</param>
        /// <param name="expectedHashCode">Expected circle hash code.</param>
        [TestCase(100, 1079574529)]
        [TestCase(1000, 1083129857)]
        [TestCase(1100, 1083256833)]
        public void GivenGetHashCodeThenOutIsGetHashCode(double actualRadius, double expectedHashCode)
        {
            //Arrange
            Circle actualCircle = new Circle(actualRadius, Material.Paper);

            //Act
            double actualHashCode = actualCircle.GetHashCode();

            //Assert
            Assert.AreEqual(expectedHashCode, actualHashCode);
        }


        /// <summary>
        /// Test cases for type <see cref="Circle.Color"/>
        /// </summary>
        /// <param name="actualRadius">Actual circle radius.</param>
        /// <param name="actualMaterial">Actual circle material.</param>
        /// <param name="actualColor">Actual circle color.</param>
        /// <param name="expectedColor">Expected circle color.</param>
        /// <param name="expectedMaterial">Expected circle material.</param>
        /// <param name="expectedRadius">Expected circle radius.</param>
        [TestCase(100, Material.Paper, Colors.Blue,
            100, Material.Paper, Colors.Blue)]
        [TestCase(100, Material.Paper, Colors.Green,
            100, Material.Paper, Colors.Green)]
        [TestCase(100, Material.Paper, Colors.Orange,
            100, Material.Paper, Colors.Orange)]
        [TestCase(100, Material.Paper, Colors.Red,
            100, Material.Paper, Colors.Red)]
        public void GivenSetColorWhenMaterialFigurePaperThenOutIsFigureWithColor(double actualRadius, Material actualMaterial, Colors actualColor,
            double expectedRadius, Material expectedMaterial, Colors expectedColor)
        {
            //Arrange
            Circle circle = new Circle(actualRadius, actualMaterial);
            Circle expectedCircle = new Circle(expectedRadius, expectedMaterial);

            //Act
            circle.Color = actualColor;
            expectedCircle.Color = expectedColor;

            //Assert
            Assert.AreEqual(expectedCircle, circle);
        }

        /// <summary>
        /// Test cases for type <see cref="Circle.Color"/>
        /// </summary>
        /// <param name="actualRadius">Actual circle radius.</param>
        /// <param name="actualMaterial">Actual circle material.</param>
        /// <param name="actualColor">Actual circle color.</param>
        /// <param name="expectedColor">Expected circle color.</param>
        /// <param name="expectedMaterial">Expected circle material.</param>
        /// <param name="expectedRadius">Expected circle radius.</param>
        [TestCase(100, Material.Paper, Colors.Blue,
    100, Material.Paper, Colors.Blue)]
        [TestCase(100, Material.Paper, Colors.Green,
    100, Material.Paper, Colors.Green)]
        [TestCase(100, Material.Paper, Colors.Orange,
    100, Material.Paper, Colors.Orange)]
        [TestCase(100, Material.Paper, Colors.Red,
    100, Material.Paper, Colors.Red)]
        public void GivenGetColorWhenMaterialFigurePaperThenOutIsFigureWithColor(double actualRadius, Material actualMaterial, Colors actualColor,
    double expectedRadius, Material expectedMaterial, Colors expectedColor)
        {
            //Arrange
            Circle circle = new Circle(actualRadius, actualMaterial);
            Circle expectedCircle = new Circle(expectedRadius, expectedMaterial);

            //Act
            circle.Color = actualColor;
            expectedCircle.Color = expectedColor;

            //Assert
            Assert.AreEqual(expectedColor, circle.Color);
        }

        /// <summary>
        /// Test cases for type <see cref="Circle.Color"/>
        /// </summary>
        /// <param name="actualRadius">Actual circle radius.</param>
        /// <param name="actualMaterial">Actual circle material.</param>
        /// <param name="actualColor">Actual circle color.</param>
        [TestCase(100, Material.Paper, Colors.Blue)]
        [TestCase(100, Material.Paper, Colors.Green)]
        [TestCase(100, Material.Paper, Colors.Orange)]
        [TestCase(100, Material.Paper, Colors.Red)]
        public void GivenSetColorWhenMaterialFigurePaperThenOutIsColorException(double actualRadius, Material actualMaterial, Colors actualColor)
        {
            //Arrange
            Circle circle = new Circle(actualRadius, actualMaterial);

            //Act
            circle.Color = actualColor;

            //Assert
            Assert.That(() => circle.Color = Colors.White, Throws.TypeOf<ColorException>());
        }

        /// <summary>
        /// Test cases for type <see cref="Circle.Color"/>
        /// </summary>
        /// <param name="actualRadius">Actual circle radius.</param>
        /// <param name="actualMaterial">Actual circle material.</param>
        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        public void GivenSetColorWhenMaterialFigureFilmThenOutIsColorException(double actualRadius, Material actualMaterial)
        {
            //Arrange
            Circle square = new Circle(actualRadius, actualMaterial);

            //Assert
            Assert.That(() => square.Color = Colors.White, Throws.TypeOf<ColorException>());
        }

    }
}
