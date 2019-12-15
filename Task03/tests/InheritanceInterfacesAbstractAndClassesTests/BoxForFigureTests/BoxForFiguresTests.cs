using InheritanceInterfacesAbstractAndClasses;
using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.Figures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace InheritanceInterfacesAbstractAndClassesTests
{
    /// <summary>
    /// Tests for <see cref="BoxForFigures"/>
    /// </summary>
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
                    new Circle(7,Material.Paper), new Circle(8,Material.Paper), new Circle(9,Material.Paper), new Circle(10,Material.Paper), 
                    new Circle(11,Material.Paper), new Circle(12,Material.Paper), new Circle(13,Material.Paper), new Circle(14,Material.Paper),
                    new Circle(15,Material.Paper), new Circle(16,Material.Paper), new Circle(17,Material.Paper), new Circle(18,Material.Paper),
                    new Circle(19,Material.Paper), new Circle(20,Material.Paper), new Circle(21,Material.Paper)
                },
                new List<Figure>
                {
                    new Square(10, Material.Film), new Square(100, Material.Film), new Rectangle(11, 11, Material.Film),
                    new Square(double.MaxValue/1000, Material.Film), new Rectangle(double.MaxValue/1000, 20, Material.Film),
                    new Circle(7,Material.Paper), new Circle(8,Material.Paper), new Circle(9,Material.Paper), new Circle(10,Material.Paper),
                    new Circle(11,Material.Paper), new Circle(12,Material.Paper), new Circle(13,Material.Paper), new Circle(14,Material.Paper),
                    new Circle(15,Material.Paper), new Circle(16,Material.Paper), new Circle(17,Material.Paper), new Circle(18,Material.Paper), 
                    new Circle(19,Material.Paper), new Circle(20,Material.Paper), new Circle(21,Material.Paper)
                }
            }
        };

        /// <summary>
        /// Initial box for for figures instance.
        /// </summary>
        /// <param name="actualFigure">List with actual figures.</param>
        /// <returns>Return box for figures instance.</returns>
        public static BoxForFigures InitialBoxForFigures(List<Figure> actualFigure)
        {
            List<Figure> tmpFigures = new List<Figure>(actualFigure);
            BoxForFigures boxForFigures = new BoxForFigures
            {
                FigureList = tmpFigures
            };
            return boxForFigures;
        }

        /// <summary>
        /// Test case for test <see cref="BoxForFigures.FigureList"/>
        /// </summary>
        /// <param name="actualSquareFigureList">Sourece list with Square.</param>
        /// <param name="expectedSquareFigureList">Expected list with square</param>
        [Test, TestCaseSource(nameof(_sourceSquareFigureList))]
        public void GivenSquareListWhenFigureIsSquareThenOutContainList(List<Figure> actualSquareFigureList, List<Figure> expectedSquareFigureList)
        {
            //Assert
            Assert.AreEqual(expectedSquareFigureList, actualSquareFigureList);
        }

        /// <summary>
        /// Test case fir test <see cref="BoxForFigures.FigureList"/>
        /// </summary>
        /// <param name="actualRectangleFigureList">Source list with rectangle.</param>
        /// <param name="expectedRectangleFigureList">Expected list with rectangle.</param>
        [Test, TestCaseSource(nameof(_sourceRectangleFigureList))]
        public void GivenRectangleListWhenFigureIsRectangleThenOutContainList(List<Figure> actualRectangleFigureList, List<Figure> expectedRectangleFigureList)
        {
            //Assert
            Assert.AreEqual(expectedRectangleFigureList, actualRectangleFigureList);
        }

        /// <summary>
        ///Test if the data comes with incorrect value.
        ///Then out is argument exception.
        /// </summary>
        /// <param name="arg0SideA">Arg0 SideA</param>
        /// <param name="arg1SideA">Arg1 SideA</param>
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

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.AddFigureToBox(Figure)"/>
        /// </summary>
        /// <param name="actualFigure">Input data with different figures.</param>
        /// <param name="expectedRectangleFigureList">Expected figures list.</param>
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

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.AddFigureToBox(Figure)"/>
        /// When figures in the box more then 20. Then out is IndexOutOfRangeException.
        /// </summary>
        /// <param name="actualFigure">Input data with different figures.</param>
        /// <param name="expectedRectangleFigureList">Expected figure list.</param>
        [Test, TestCaseSource(nameof(_sourceFigureObjects))]
        public void GivenAddFigureToBoxWhenFiguresMoreThen20ThenOutIsIndexOutOfRangeException(Figure[] actualFigure, List<Figure> expectedRectangleFigureList)
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
            boxForFigures.AddFigureToBox(new Circle(31, Material.Paper));
            //Assert
            Assert.Throws<IndexOutOfRangeException>(() => boxForFigures.AddFigureToBox(new Circle(31, Material.Paper)));

        }

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.FindFigureById(int)"/>
        /// </summary>
        /// <param name="actualFigure">Actual figure list.</param>
        /// <param name="figureId">Figure id.</param>
        /// <returns>Returns figure which was found by id.</returns>
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

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.ExecuteFigureById(int)"/>
        /// </summary>
        /// <param name="actualFigure">Actual figure list.</param>
        /// <param name="figureId">Figure id.</param>
        /// <returns>Returns figure which was found by id.</returns>
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

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.ExecuteFigureById(int)"/>
        /// </summary>
        /// <param name="actualFigure">Actual figure list.</param>
        /// <param name="figureId">Figure id.</param>
        /// <returns>Returns count figures ramaining on the list.</returns>
        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesExecuteFigureByIdThennOutputListLessByOne")]
        public int GivenExecuteFigureByIdWhenExecuteOneFigureThenOutputListLessByOne(List<Figure> actualFigure, int figureId)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);

            //Act
            boxForFigures.ExecuteFigureById(figureId);

            //Assert
            return boxForFigures.FigureList.Count;
        }

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.ReplaceById(int, Figure)"/>
        /// </summary>
        /// <param name="actualFigure">The source of the list of figures.</param>
        /// <param name="figureId">Figure id which you want replace.</param>
        /// <param name="figure">The figure you want to put in the box.</param>
        /// <returns>The figure you want to put in the box.</returns>
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

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.FindFigureAccordingToThePattern(Figure)"/>
        /// </summary>
        /// <param name="actualFigure">The source of the list of figures.</param>
        /// <param name="figurePattern">Figure pattern.</param>
        /// <returns>Found figure by pattern</returns>
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

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.GetNumberOfFiguresInTheBox"/>
        /// </summary>
        /// <param name="actualFigure">The source of the list of figures.</param>
        /// <returns>Returns count of figure in the box.</returns>
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

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.GetSumAreaFigures"/>
        /// </summary>
        /// <param name="actualFigure">The source of the list of figures.</param>
        /// <returns>Return the total area.</returns>
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

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.GetSumAreaFigures"/>
        /// </summary>
        /// <param name="actualFigure">The source of the list of figures.</param>
        /// <returns>Return the total area.</returns>
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

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.GetSumPerimeterFigures"/>
        /// </summary>
        /// <param name="actualFigure">The source of the list of figures.</param>
        /// <returns>Return the total perimeter.</returns>
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

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.GetSumPerimeterFigures"/>
        /// </summary>
        /// <param name="actualFigure">The source of the list of figures.</param>
        /// <returns>Return the total perimeter.</returns>
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

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.GetAllCircles"/>
        /// </summary>
        /// <param name="actualFigure">The source of the list of figures.</param>
        /// <returns>Return list of all circles.</returns>
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

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.GetAllCircles"/>
        /// </summary>
        /// <param name="actualFigure">The source of the list of figures.</param>
        /// <returns>Return list of all circles.</returns>
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

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.GetAllFilmFigures"/>
        /// </summary>
        /// <param name="actualFigure">The source of the list of figures.</param>
        /// <returns>Return list of all film figures.</returns>
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

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.GetAllFilmFigures"/>
        /// </summary>
        /// <param name="actualFigure">The source of the list of figures.</param>
        /// <returns>Return list of all film figures.</returns>
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

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.SaveAllFiguresInXmlUsingStreamWriter(string)"/>
        /// </summary>
        /// <param name="actualFigure">The source of the list of figures.</param>
        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "GetSaveAllFiguresInXmlUsingStreamWriter")]
        public void GiveSaveAllFiguresInXmlUsingStreamWriterWhenThenOut(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);
            string path = @"XmlFile/allFigures.xml";

            //Act
            boxForFigures.SaveAllFiguresInXmlUsingStreamWriter(path);
        }

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.SaveFilmFiguresInXmlUsingStreamWriter(string)"/>
        /// </summary>
        /// <param name="actualFigure">The source of the list of figures.</param>
        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "GetSaveFilmFiguresInXmlUsingStreamWriter")]
        public void GiveSaveFilmFiguresInXmlUsingStreamWriterWhenThenOut(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);
            string path = @"XmlFile/allFilmFigures.xml";

            //Act
            boxForFigures.SaveFilmFiguresInXmlUsingStreamWriter(path);
        }

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.SavePaperFiguresInXmlUsingStreamWriter(string)"/>
        /// </summary>
        /// <param name="actualFigure">The source of the list of figures.</param>
        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "GetSavePaperFiguresInXmlUsingStreamWriter")]
        public void GiveSavePaperFiguresInXmlUsingStreamWriterWhenThenOut(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);
            string path = @"XmlFile/allPaperFigures.xml";

            //Act
            boxForFigures.SavePaperFiguresInXmlUsingStreamWriter(path);
        }

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.SaveAllFiguresInXmlUsingXmlWriter(string)"/>
        /// </summary>
        /// <param name="actualFigure">The source of the list of figures.</param>
        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "GetSaveAllFiguresInXmlUsingXmlWriter")]
        public void GiveSaveAllFiguresInXmlUsingXmlWriterrWhenThenOut(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);
            string path = @"XmlFile/allFiguresXmlWriter.xml";

            //Act
            boxForFigures.SaveAllFiguresInXmlUsingXmlWriter(path);
        }

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.SaveFilmFiguresInXmlUsingXmlWriter(string)"/>
        /// </summary>
        /// <param name="actualFigure">The source of the list of figures.</param>
        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "GetSaveAllFiguresInXmlUsingXmlWriter")]
        public void GiveSaveFilmFiguresInXmlUsingXmlWriter(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);
            string path = @"XmlFile/allFilmFiguresXmlWriter.xml";

            //Act
            boxForFigures.SaveFilmFiguresInXmlUsingXmlWriter(path);
        }

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.SavePaperFiguresInXmlUsingXmlWriter(string)"/>
        /// </summary>
        /// <param name="actualFigure">The source of the list of figures.</param>
        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "GetSaveAllFiguresInXmlUsingXmlWriter")]
        public void GiveSavePaperFiguresInXmlUsingXmlWriter(List<Figure> actualFigure)
        {
            //Arrange
            BoxForFigures boxForFigures = InitialBoxForFigures(actualFigure);
            string path = @"XmlFile/allPaperFiguresXmlWriter.xml";

            //Act
            boxForFigures.SavePaperFiguresInXmlUsingXmlWriter(path);
        }

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.LoadAllFiguresFromXmlUsingStreamReader(string)"/>
        /// </summary>
        [Test]
        public void GiveLoadAllFiguresFromXmlUsingStreamReaderWhenThenOut()
        {
            //Arrange
            BoxForFigures boxForFigures = new BoxForFigures();
            string path = "XmlFile/allFigures.xml";

            //Act
            boxForFigures.LoadAllFiguresFromXmlUsingStreamReader(path);
        }

        /// <summary>
        /// Test case for method <see cref="BoxForFigures.LoadAllFiguresFromXmlUsingXmlReader(string)"/>
        /// </summary>
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