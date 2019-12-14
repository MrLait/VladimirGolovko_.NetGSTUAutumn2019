using InheritanceInterfacesAbstractAndClasses;
using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.Figures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace InheritanceInterfacesAbstractAndClassesTests
{
    [TestFixture]
    public class BoxForFiguresTests
    {
        private static readonly object[] _sourceSquareFigureList =
        {
            new object[]
            {
                new List<Figure>{new Square(10, Material.Film)}, //Test case 1 actual
                new List<Figure>{new Square(10, Material.Film)} //Test case 1 expected
            },
            new object[]
            {
                new List<Figure>{new Square(double.MaxValue/1000, Material.Film), new Square(10, Material.Film) }, //Test case 2 actual
                new List<Figure>{new Square(double.MaxValue/1000, Material.Film), new Square(10, Material.Film) } //Test case 2 expected
            }
        };

        private static readonly object[] _sourceRectangleFigureList = {
            new object[]
            {
                new List<Figure>{new Rectangle(100,100, Material.Film) },
                new List<Figure>{new Rectangle(100,100, Material.Film) }
            },
            new object[]
            {
            new List<Figure>{new Rectangle(double.MaxValue/1000,double.MaxValue/1000, Material.Film), new Rectangle(double.MaxValue/1000,100, Material.Film) },
            new List<Figure>{new Rectangle(double.MaxValue/1000,double.MaxValue/1000, Material.Film), new Rectangle(double.MaxValue/1000,100, Material.Film) }
            }
        };

        private static readonly object[] _sourceFigureObjects =
        {
            new object[]
            {
                new Figure[]
                {
                    new Square(10, Material.Film), new Square(10, Material.Film), new Square(100, Material.Film), new Rectangle(11, 11, Material.Film),
                    new Square(double.MaxValue/1000, Material.Film), new Rectangle(double.MaxValue/1000, 20, Material.Film),
                    new Circle(7), new Circle(8), new Circle(9), new Circle(10), new Circle(11), new Circle(12), new Circle(13), new Circle(14),
                    new Circle(15), new Circle(16), new Circle(17), new Circle(18), new Circle(19), new Circle(20), new Circle(21)
                },
                new List<Figure>
                {
                    new Square(10, Material.Film), new Square(100, Material.Film), new Rectangle(11, 11, Material.Film),
                    new Square(double.MaxValue/1000, Material.Film), new Rectangle(double.MaxValue/1000, 20, Material.Film),
                    new Circle(7), new Circle(8), new Circle(9), new Circle(10), new Circle(11), new Circle(12), new Circle(13), new Circle(14),
                    new Circle(15), new Circle(16), new Circle(17), new Circle(18), new Circle(19), new Circle(20), new Circle(21)
                }
            }
        };

        public static BoxForFigures InitialBoxForFigures(List<Figure> actualFigure)
        {
            List<Figure> tmpFigures = new List<Figure>(actualFigure);
            BoxForFigures boxForFigures = new BoxForFigures
            {
                FigureList = tmpFigures
            };
            return boxForFigures;
        }

        [Test, TestCaseSource(nameof(_sourceSquareFigureList))]
        public void GivenSquareListWhenFigureIsSquareThenOutContainList(List<Figure> actualSquareFigureList, List<Figure> expectedSquareFigureList)
        {
            //Assert
            Assert.AreEqual(expectedSquareFigureList, actualSquareFigureList);
        }

        [Test, TestCaseSource(nameof(_sourceRectangleFigureList))]
        public void GivenRectangleListWhenFigureIsRectangleThenOutContainList(List<Figure> actualRectangleFigureList, List<Figure> expectedRectangleFigureList)
        {
            //Assert
            Assert.AreEqual(expectedRectangleFigureList, actualRectangleFigureList);
        }

        [TestCase(double.MinValue, 0)]
        public void GivenSquareListWhenFigureIsSquareThenOutArgumentException(double arg0SideA, double arg1SideA)
        {
            //Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    new List<Figure>()
                    {
                            new Square(arg0SideA, Material.Film),
                            new Square(arg1SideA, Material.Film)
                    };
                });
        }

        [Test, TestCaseSource(nameof(_sourceFigureObjects))]
        public void GivenAddFigureToBoxWhenFigureIsDifferentThenOutIsFigureList(Figure[] actualFigure, List<Figure> expectedRectangleFigureList)
        {
            //Arrange
            BoxForFigures boxForFigures = new BoxForFigures();
            List<Figure> actualBoxList;

            //Act
            if (actualFigure != null)
            {
                foreach (Figure item in actualFigure)
                {
                    boxForFigures.AddFigureToBox(item);
                }
            }
            actualBoxList = boxForFigures.FigureList;

            //Assert
            Assert.AreEqual(expectedRectangleFigureList, actualBoxList);
        }

        [Test, TestCaseSource(nameof(_sourceFigureObjects))]
        public void GivenAddFigureToBoxWhenFiguresMoreThen20ThenOutIsIndexOutOfRangeException(Figure[] actualFigure, List<Figure> expectedRectangleFigureList)
        {
            //Arrange
            BoxForFigures boxForFigures = new BoxForFigures();
            List<Figure> actualBoxList;

            //Act
            if (actualFigure != null)
            {
                foreach (Figure item in actualFigure)
                {
                    boxForFigures.AddFigureToBox(item);
                }
            }
            boxForFigures.AddFigureToBox(new Circle(31));
            //Assert
            Assert.Throws<IndexOutOfRangeException>(() => boxForFigures.AddFigureToBox(new Circle(31)));

        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesFindFigureById")]
        public Figure GivenFindFigureByIdWhenByIdThenOutIsFigure(Figure[] actualFigure, int figureId)
        {
            //Arrange
            BoxForFigures boxForFigures = new BoxForFigures();

            //Act
            if (actualFigure != null)
            {
                foreach (Figure item in actualFigure)
                {
                    boxForFigures.AddFigureToBox(item);
                }
            }

            //Assert
            return boxForFigures.FindFigureById(figureId);
        }


        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesExecuteFigureById")]
        public Figure GivenExecuteFigureByIdWhenByIdThenOutIsFigure(Figure[] actualFigure, int figureId)
        {
            //Arrange
            BoxForFigures boxForFigures = new BoxForFigures();

            //Act
            if (actualFigure != null)
            {
                foreach (Figure item in actualFigure)
                {
                    boxForFigures.AddFigureToBox(item);
                }
            }

            //Assert
            return boxForFigures.ExecuteFigureById(figureId);
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesExecuteFigureByIdThennOutputListLessByOne")]
        public int GivenExecuteFigureByIdWhenByIdThenOutputListLessByOne(List<Figure> actualFigure, int figureId)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);

            //Act
            boxForFigures.ExecuteFigureById(figureId);

            //Assert
            return boxForFigures.FigureList.Count;
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesReplaceById")]
        public Figure GivenReplaceByIdWhenByIdThenOutNewFigureList(List<Figure> actualFigure, int figureId, Figure figure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);

            //Act
            boxForFigures.ReplaceById(figureId, figure);

            //Assert
            return boxForFigures.FigureList[figureId];
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesFindFigureAccordingToThePattern")]
        public Figure GiveFindFigureAccordingToThePatternWhenPatterIsValidThenOutFigureId(List<Figure> actualFigure, Figure figurePattern)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);

            //Act
            Figure figureByPattern = boxForFigures.FindFigureAccordingToThePattern(figurePattern);

            //Assert
            return figureByPattern;
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesGetNumberOfFiguresInTheBox")]
        public int GiveGetNumberOfFiguresInTheBoxWhenInputIsListFiguresThenOutNumberOfFigures(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);

            //Act
            int figureCount = boxForFigures.GetNumberOfFiguresInTheBox();

            //Assert
            return figureCount;
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesGetSumAreaFigures")]
        public double GiveGetSumAreaFiguresWhenInputIsListFiguresThenOutIsValidSumOfArea(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);

            //Act
            double figureAreaCount = boxForFigures.GetSumAreaFigures();

            //Assert
            return figureAreaCount;
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesGetSumAreaFiguresOutIsInfinity")]
        public double GiveGetSumAreaFiguresWhenInputIsListWithBigValuesFiguresThenOutIsInfinity(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);

            //Act
            double figureAreaCount = boxForFigures.GetSumAreaFigures();

            //Assert
            return figureAreaCount;
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesGetSumPerimetersFigures")]
        public double GiveGetSumPerimeterFiguresWhenInputIsListFiguresThenOutIsValidSumOfArea(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);

            //Act
            double figurePerimeterCount = boxForFigures.GetSumPerimeterFigures();

            //Assert
            return figurePerimeterCount;
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesGetSumPerimetersFiguresOutIsBigValue")]
        public double GiveGetSumPerimeterFiguresWhenInputIsListWithBigValuesFiguresThenOutIsInfinity(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);

            //Act
            double figurePerimeterCount = boxForFigures.GetSumPerimeterFigures();

            //Assert
            return figurePerimeterCount;
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesGetAllCirclesThenOutIsEmpty")]
        public List<Circle> GiveGetAllCirclesWhenInputIsListWithoutCircleThenOutIsEmpty(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);

            //Act
            List<Circle> figureCircles = boxForFigures.GetAllCircles();

            //Assert
            return figureCircles;
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesGetAllCirclesThenOutIsCircleList")]
        public List<Circle> GiveGetAllCirclesWhenInputIsListWithCircleThenOutIsCircleList(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);

            //Act
            List<Circle> figureCircles = boxForFigures.GetAllCircles();

            //Assert
            return figureCircles;
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "GetAllFilmFiguresThenOutIsEmpty")]
        public List<Figure> GiveGetAllFilmFiguresWhenInputListFithoutFilmFiguresThenOutIsEmpty(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);

            //Act
            List<Figure> filmFigures = boxForFigures.GetAllFilmFigures();

            //Assert
            return filmFigures;
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "GetAllFilmFiguresThenOutIsFilmFiguresList")]
        public List<Figure> GiveGetAllFilmFiguresWhenInputIsListFiguresThenOutIsListFilmFigures(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);

            //Act
            List<Figure> filmFigures = boxForFigures.GetAllFilmFigures();

            //Assert
            return filmFigures;
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "GetSaveAllFiguresInXmlUsingStreamWriter")]
        public void GiveSaveAllFiguresInXmlUsingStreamWriterWhenThenOut(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);
            string path = @"XmlFile/allFigures.xml";

            //Act
            boxForFigures.SaveAllFiguresInXmlUsingStreamWriter(path);
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "GetSaveFilmFiguresInXmlUsingStreamWriter")]
        public void GiveSaveFilmFiguresInXmlUsingStreamWriterWhenThenOut(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);
            string path = @"XmlFile/allFilmFigures.xml";

            //Act
            boxForFigures.SaveFilmFiguresInXmlUsingStreamWriter(path);
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "GetSavePaperFiguresInXmlUsingStreamWriter")]
        public void GiveSavePaperFiguresInXmlUsingStreamWriterWhenThenOut(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);
            string path = @"XmlFile/allPaperFigures.xml";

            //Act
            boxForFigures.SavePaperFiguresInXmlUsingStreamWriter(path);
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "GetSaveAllFiguresInXmlUsingXmlWriter")]
        public void GiveSaveAllFiguresInXmlUsingXmlWriterrWhenThenOut(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);
            string path = @"XmlFile/allFiguresXmlWriter.xml";

            //Act
            boxForFigures.SaveAllFiguresInXmlUsingXmlWriter(path);
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "GetSaveAllFiguresInXmlUsingXmlWriter")]
        public void GiveSaveFilmFiguresInXmlUsingXmlWriter(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);
            string path = @"XmlFile/allFilmFiguresXmlWriter.xml";

            //Act
            boxForFigures.SaveFilmFiguresInXmlUsingXmlWriter(path);
        }

        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "GetSaveAllFiguresInXmlUsingXmlWriter")]
        public void GiveSavePaperFiguresInXmlUsingXmlWriter(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);
            string path = @"XmlFile/allPaperFiguresXmlWriter.xml";

            //Act
            boxForFigures.SavePaperFiguresInXmlUsingXmlWriter(path);
        }

        [Test]
        public void GiveLoadAllFiguresFromXmlUsingStreamReaderWhenThenOut()
        {
            //Arrange
            BoxForFigures boxForFigures = new BoxForFigures();
            string path = "XmlFile/allFigures.xml";

            //Act
            boxForFigures.LoadAllFiguresFromXmlUsingStreamReader(path);
        }

        [Test]
        public void GiveLoadAllFiguresFromXmlUsingXmlReaderWhenThenOut()
        {
            //Arrange
            BoxForFigures boxForFigures = new BoxForFigures();
            string path = "XmlFile/allFigures.xml";

            //Act
            boxForFigures.LoadAllFiguresFromXmlUsingXmlReader(path);
        }
    }
}