using InheritanceInterfacesAbstractAndClasses;
using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.Figures;
using InheritanceInterfacesAbstractAndClasses.UserExceptions;
using NUnit.Framework;
using System;

namespace InheritanceInterfacesAbstractAndClassesTests.FigureTests
{
    [TestFixture()]
    public class CircleTest
    {
        [TestCase(100, 100)]
        [TestCase(1000, 1000)]
        [TestCase(1100, 1100)]
        public void GivenCircleWhenFigureIsCircleThenOutIsNewCircle(double actualRadius, double expectedRadius)
        {
            //Arrange
            Circle actualCircle = new Circle(actualRadius);

            //Assert
            Assert.AreEqual(new Circle(expectedRadius), actualCircle);
        }

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

        [TestCase(100, 30, Material.Film, 30, Material.Film)]
        [TestCase(1000, 300, Material.Paper, 300, Material.Paper)]
        public void GivenCircleWhenConstructorContainSquareThenOutIsNewCircle(double actualSideAdouble, double actualRadius, Material actualMaterial,
            double expectedRadius, Material expectedMaterial)
        {
            //Arrange
            Square sourceSquare = new Square(actualSideAdouble, actualMaterial);

            //Act
            Circle actualCircle = new Circle(sourceSquare, actualRadius);

            //Assert
            Assert.AreEqual(new Circle(expectedRadius, expectedMaterial), actualCircle);
        }


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

        [TestCase(100, 100)]
        [TestCase(1000, 1000)]
        [TestCase(1100, 1100)]
        public void GivenGetRadiusWhenConstructorContainSheetThenOutIsGetRadius(double radius, double expectedRadius)
        {
            //Arrange
            Circle sourceCircle = new Circle(radius);

            //Act
            var actualRadius = sourceCircle.Radius;

            //Assert
            Assert.AreEqual(expectedRadius, actualRadius);
        }

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

        [TestCase(-100, Material.Film)]
        [TestCase(0, Material.Paper)]
        public void GivenRadiusWhenConstructorContainFigureThenOutIsArgumentException(double expectedRadius, Material actualMaterial)
        {
            //Assert
            Assert.That(() => new Circle(expectedRadius, actualMaterial), Throws.TypeOf<ArgumentException>());
        }

        [TestCase(100, 628.31853071795865)]
        [TestCase(1000, 6283.1853071795858)]
        [TestCase(1100, 6911.5038378975451)]
        public void GivenGetPerimeterFigureThenOutIsPerimeter(double actualRadius, double expectedPerimeter)
        {
            //Arrange
            Circle actualCircle = new Circle(actualRadius);

            //Act
            double actualPerimeter = actualCircle.GetPerimeter();

            //Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        [TestCase(100, 1079574528)]
        [TestCase(1000, 1083129856)]
        [TestCase(1100, 1083256832)]
        public void GivenGetHashCodeThenOutIsGetHashCode(double actualRadius, double expectedHashCode)
        {
            //Arrange
            Circle actualCircle = new Circle(actualRadius);

            //Act
            double actualHashCode = actualCircle.GetHashCode();

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
            Circle circle = new Circle(actualSideA, actualMaterial);
            Circle expectedSquare = new Circle(expectedSideA, expectedMaterial);

            //Act
            circle.Color = actualColor;
            expectedSquare.Color = expectedColor;

            //Assert
            Assert.AreEqual(expectedSquare, circle);
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
            Circle circle = new Circle(actualSideA, actualMaterial);
            Circle expectedSquare = new Circle(expectedSideA, expectedMaterial);

            //Act
            circle.Color = actualColor;
            expectedSquare.Color = expectedColor;

            //Assert
            Assert.AreEqual(expectedColor, circle.Color);
        }

        [TestCase(100, Material.Paper, Color.Blue)]
        [TestCase(100, Material.Paper, Color.Green)]
        [TestCase(100, Material.Paper, Color.Orange)]
        [TestCase(100, Material.Paper, Color.Red)]
        public void GivenSetColorWhenMaterialFigurePaperThenOutIsColorException(double actualSideA, Material actualMaterial, Color actualColor)
        {
            //Arrange
            Circle circle = new Circle(actualSideA, actualMaterial);

            //Act
            circle.Color = actualColor;

            //Assert
            Assert.That(() => circle.Color = Color.White, Throws.TypeOf<ColorException>());
        }

        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        public void GivenSetColorWhenMaterialFigureFilmThenOutIsColorException(double actualSideA, Material actualMaterial)
        {
            //Arrange
            Circle square = new Circle(actualSideA, actualMaterial);

            //Assert
            Assert.That(() => square.Color = Color.White, Throws.TypeOf<ColorException>());
        }

    }
}
