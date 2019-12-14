using InheritanceInterfacesAbstractAndClasses;
using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.Figures;
using InheritanceInterfacesAbstractAndClasses.UserExceptions;
using NUnit.Framework;
using System;

namespace InheritanceInterfacesAbstractAndClassesTests.FigureTests
{
    [TestFixture()]
    public class RectangleTest
    {
        [TestCase(100, 100, 100, 100)]
        [TestCase(1000, 1000, 1000, 1000)]
        [TestCase(1100, 1100, 1100, 1100)]
        public void GivenRectangleWhenFigureIsRectangleThenOutIsNewRectangle(double actualSideA, double actualSideB,
            double expectedSideA, double expectedSideB)
        {
            //Arrange
            Rectangle actuaRectangle = new Rectangle(actualSideA, actualSideB, Material.Paper);

            //Assert
            Assert.AreEqual(new Rectangle(expectedSideA, expectedSideB, Material.Paper), actuaRectangle);
        }

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

        [TestCase(-100, -100, Material.Film)]
        [TestCase(-1000, -1000, Material.Paper)]
        public void GivenSideAWhenConstructorContainFigureThenOutIsArgumentException(double actualSideA, double actualSideB, Material actualMaterial)
        {
            //Assert
            Assert.That(() => new Rectangle(actualSideA, actualSideB, actualMaterial), Throws.TypeOf<ArgumentException>());
        }

        [TestCase(100, -100, Material.Film)]
        [TestCase(1000, -1000, Material.Paper)]
        public void GivenSideBWhenConstructorContainFigureThenOutIsArgumentException(double actualSideA, double actualSideB, Material actualMaterial)
        {
            //Assert
            Assert.That(() => new Rectangle(actualSideA, actualSideB, actualMaterial), Throws.TypeOf<ArgumentException>());
        }

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
            Rectangle rectangle = new Rectangle(actualSideA, actualSideA, actualMaterial);
            Rectangle expectedSquare = new Rectangle(expectedSideA, expectedSideA, expectedMaterial);

            //Act
            rectangle.Color = actualColor;
            expectedSquare.Color = expectedColor;

            //Assert
            Assert.AreEqual(expectedColor, rectangle.Color);
        }

        [TestCase(100, Material.Paper, Color.Blue)]
        [TestCase(100, Material.Paper, Color.Green)]
        [TestCase(100, Material.Paper, Color.Orange)]
        [TestCase(100, Material.Paper, Color.Red)]
        public void GivenSetColorWhenMaterialFigurePaperThenOutIsColorException(double actualSideA, Material actualMaterial, Color actualColor)
        {
            //Arrange
            Rectangle rectangle = new Rectangle(actualSideA, actualSideA, actualMaterial);

            //Act
            rectangle.Color = actualColor;

            //Assert
            Assert.That(() => rectangle.Color = Color.White, Throws.TypeOf<ColorException>());
        }

        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        [TestCase(100, Material.Film)]
        public void GivenSetColorWhenMaterialFigureFilmThenOutIsColorException(double actualSideA, Material actualMaterial)
        {
            //Arrange
            Rectangle rectangle = new Rectangle(actualSideA, actualSideA, actualMaterial);

            //Assert
            Assert.That(() => rectangle.Color = Color.White, Throws.TypeOf<ColorException>());
        }

    }
}
