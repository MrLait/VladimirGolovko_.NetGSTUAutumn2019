using InheritanceInterfacesAbstractAndClasses;
using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.Figures;
using InheritanceInterfacesAbstractAndClasses.UserExceptions;
using NUnit.Framework;
using System;

namespace InheritanceInterfacesAbstractAndClassesTests.FigureTests
{
    [TestFixture()]
    public class SquareTest
    {
        [TestCase(100, 100)]
        [TestCase(1000, 1000)]
        [TestCase(1100, 1100)]
        public void GivenSquareWhenFigureIsSquareThenOutIsNewSquare(double actualSideA, double expectedSideA)
        {
            //Arrange
            Square actualSquare = new Square(actualSideA, Material.Film);

            //Assert
            Assert.AreEqual(new Square(expectedSideA, Material.Film), actualSquare);
        }

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

        [TestCase(-100, Material.Film)]
        [TestCase(-1000, Material.Paper)]
        public void GivenSideAWhenConstructorContainFigureThenOutIsArgumentException(double actualSideA, Material actualMaterial)
        {
            //Assert
            Assert.That(() => new Square(actualSideA, actualMaterial), Throws.TypeOf<ArgumentException>());
        }

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

        [TestCase(100, Material.Paper, Color.Blue,
            100, Material.Paper, Color.Blue)]
        [TestCase(100, Material.Paper, Color.Green,
            100, Material.Paper, Color.Green)]
        [TestCase(100, Material.Paper, Color.Orange,
            100, Material.Paper, Color.Orange)]
        [TestCase(100, Material.Paper, Color.Red,
            100, Material.Paper, Color.Red)]
        public void GivenSetColorWhenMaterialFigurePaperThenOutIsFigureWithColor(double actualSideA, Material actualMaterial, Color actualColor,
            double expectedSideA, Material expectedMaterial, Color expectedColor)
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

        [TestCase(100, Material.Paper, Color.Blue,
    100, Material.Paper, Color.Blue)]
        [TestCase(100, Material.Paper, Color.Green,
    100, Material.Paper, Color.Green)]
        [TestCase(100, Material.Paper, Color.Orange,
    100, Material.Paper, Color.Orange)]
        [TestCase(100, Material.Paper, Color.Red,
    100, Material.Paper, Color.Red)]
        public void GivenGetColorWhenMaterialFigurePaperThenOutIsFigureWithColor(double actualSideA, Material actualMaterial, Color actualColor,
    double expectedSideA, Material expectedMaterial, Color expectedColor)
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

        [TestCase(100, Material.Paper, Color.Blue)]
        [TestCase(100, Material.Paper, Color.Green)]
        [TestCase(100, Material.Paper, Color.Orange)]
        [TestCase(100, Material.Paper, Color.Red)]
        public void GivenSetColorWhenMaterialFigurePaperThenOutIsColorException(double actualSideA, Material actualMaterial, Color actualColor)
        {
            //Arrange
            Square square = new Square(actualSideA, actualMaterial);

            //Act
            square.Color = actualColor;
            
            //Assert
            Assert.That(() => square.Color = Color.White, Throws.TypeOf<ColorException>());
        }

        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        public void GivenSetColorWhenMaterialFigureFilmThenOutIsColorException(double actualSideA, Material actualMaterial)
        {
            //Arrange
            Square square = new Square(actualSideA, actualMaterial);

            //Assert
            Assert.That(() => square.Color = Color.White, Throws.TypeOf<ColorException>());
        }

    }
}
