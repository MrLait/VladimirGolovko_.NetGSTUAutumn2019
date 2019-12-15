using InheritanceInterfacesAbstractAndClasses;
using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.Figures;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace InheritanceInterfacesAbstractAndClassesTests
{
    /// <summary>
    /// Factory test cases for Type <see cref="BoxForFigures"/>
    /// </summary>
    public static class MyFactoryBoxForFiguresTests
    {
        private static readonly Figure[] _sourceFigures = new Figure[]
        {
            new Square(10, Material.Film), new Square(100, Material.Film), new Rectangle(11, 11, Material.Film),
            new Square(double.MaxValue/1113, Material.Film), new Rectangle(double.MaxValue/1113, 20, Material.Film)
        };
        private static readonly Figure[] _sourceFiguresWirhBigValue = new Figure[]
{
            new Square(10, Material.Film), new Square(100, Material.Film), new Rectangle(11, 11, Material.Film),
            new Square(double.MaxValue, Material.Film), new Rectangle(double.MaxValue, 20, Material.Film)
};

        private static readonly List<Figure> _sourceFigureList = new List<Figure>
        {
            new Square(10, Material.Film), new Square(100, Material.Film), new Rectangle(11, 11, Material.Paper),
            new Square(double.MaxValue/1113, Material.Paper), new Rectangle(double.MaxValue/1113, 20, Material.Paper),
            new Rectangle(123,124, Material.Film), new Circle(10, Material.Paper), new Circle(11,Material.Film), new Circle(12, Material.Paper)
        };

        private static readonly List<Figure> _sourceFigureListWithOutCircle = new List<Figure>
        {
            new Square(10, Material.Film), new Square(100, Material.Film), new Rectangle(11, 11, Material.Paper),
            new Square(double.MaxValue/1113, Material.Paper), new Rectangle(double.MaxValue/1113, 20, Material.Paper)
        };

        private static readonly List<Figure> _sourceFigureListWithOutBigValue = new List<Figure>
        {
            new Square(10, Material.Film), new Square(100, Material.Film), new Rectangle(11, 11, Material.Film),
            new Square(1113000000, Material.Film), new Rectangle(200000000000000, 20, Material.Film)
        };

        private static readonly List<Figure> _sourceFigureWithCircleList = new List<Figure>
        {
            new Square(10, Material.Film), new Square(100, Material.Paper), new Circle(1, Material.Film),
            new Rectangle(11, 11, Material.Paper), new Square(double.MaxValue/1113, Material.Paper),
            new Rectangle(double.MaxValue/1113, 20, Material.Film), new Circle(10, Material.Film), new Circle(100, Material.Paper)
        };

        private static readonly List<Figure> _sourceFigureCircleList = new List<Figure>
        {
            new Circle(1, Material.Film), new Circle(10, Material.Film), new Circle(100, Material.Paper)
        };

        private static readonly List<Figure> _sourceFilmFigures = new List<Figure>
        {
            new Square(10, Material.Film), new Square(100, Material.Film), new Rectangle(123,124, Material.Film), new Circle(11,Material.Film)
        };

        private static readonly List<Figure> _sourcePaperFigures = new List<Figure>
        {
            new Square(10, Material.Paper), new Square(100, Material.Paper)
        };

        /// <summary>
        /// Test cases for method <see cref="BoxForFigures.FindFigureById(int)"/>
        /// </summary>
        public static IEnumerable TestCasesFindFigureById
        {
            get
            {
                yield return new TestCaseData(_sourceFigures, 5).Returns(null);
                yield return new TestCaseData(_sourceFigures, -1).Returns(null);
                yield return new TestCaseData(_sourceFigures, 0).Returns(_sourceFigures[0]);
                yield return new TestCaseData(_sourceFigures, 1).Returns(_sourceFigures[1]);
                yield return new TestCaseData(_sourceFigures, 2).Returns(_sourceFigures[2]);
                yield return new TestCaseData(_sourceFigures, 3).Returns(_sourceFigures[3]);
                yield return new TestCaseData(_sourceFigures, 4).Returns(_sourceFigures[4]);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="BoxForFigures.ExecuteFigureById(int)"/>
        /// </summary>
        public static IEnumerable TestCasesExecuteFigureById
        {
            get
            {
                yield return new TestCaseData(_sourceFigures, 0).Returns(_sourceFigures[0]);
                yield return new TestCaseData(_sourceFigures, 1).Returns(_sourceFigures[1]);
                yield return new TestCaseData(_sourceFigures, 2).Returns(_sourceFigures[2]);
                yield return new TestCaseData(_sourceFigures, 3).Returns(_sourceFigures[3]);
                yield return new TestCaseData(_sourceFigures, 4).Returns(_sourceFigures[4]);
                yield return new TestCaseData(_sourceFigures, 5).Returns(null);
                yield return new TestCaseData(_sourceFigures, -1).Returns(null);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="BoxForFigures.ExecuteFigureById(int)"/>
        /// </summary>
        public static IEnumerable TestCasesExecuteFigureByIdThennOutputListLessByOne
        {
            get
            {
                yield return new TestCaseData(_sourceFigureList, 5).Returns(_sourceFigureList.Count - 1);
                yield return new TestCaseData(_sourceFigureList, -1).Returns(_sourceFigureList.Count);
                yield return new TestCaseData(_sourceFigureList, 4).Returns(_sourceFigureList.Count - 1);
                yield return new TestCaseData(_sourceFigureList, 3).Returns(_sourceFigureList.Count - 1);
                yield return new TestCaseData(_sourceFigureList, 2).Returns(_sourceFigureList.Count - 1);
                yield return new TestCaseData(_sourceFigureList, 1).Returns(_sourceFigureList.Count - 1);
                yield return new TestCaseData(_sourceFigureList, 0).Returns(_sourceFigureList.Count - 1);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="BoxForFigures.ReplaceById(int, Figure)"/>
        /// </summary>
        public static IEnumerable TestCasesReplaceById
        {
            get
            {
                yield return new TestCaseData(_sourceFigureList, 4, new Square(111, Material.Film)).Returns(new Square(111, Material.Film));
                yield return new TestCaseData(_sourceFigureList, 3, new Square(111, Material.Film)).Returns(new Square(111, Material.Film));
                yield return new TestCaseData(_sourceFigureList, 2, new Square(111, Material.Film)).Returns(new Square(111, Material.Film));
                yield return new TestCaseData(_sourceFigureList, 1, new Rectangle(111, 111, Material.Paper)).Returns(new Rectangle(111, 111, Material.Paper));
                yield return new TestCaseData(_sourceFigureList, 0, new Square(111, Material.Paper)).Returns(new Square(111, Material.Paper));
            }
        }

        /// <summary>
        /// Test cases for method <see cref="BoxForFigures.FindFigureAccordingToThePattern(Figure)"/>
        /// </summary>
        public static IEnumerable TestCasesFindFigureAccordingToThePattern
        {
            get
            {
                yield return new TestCaseData(_sourceFigureList, new Square(10, Material.Film)).Returns(new Square(10, Material.Film));
                yield return new TestCaseData(_sourceFigureList, new Square(100, Material.Film)).Returns(new Square(100, Material.Film));
                yield return new TestCaseData(_sourceFigureList, new Square(double.MaxValue / 1113, Material.Paper)).Returns(new Square(double.MaxValue / 1113, Material.Paper));
                yield return new TestCaseData(_sourceFigureList, new Rectangle(11, 11, Material.Paper)).Returns(new Rectangle(11, 11, Material.Paper));
                yield return new TestCaseData(_sourceFigureList, null).Returns(null);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="BoxForFigures.GetNumberOfFiguresInTheBox"/>
        /// </summary>
        public static IEnumerable TestCasesGetNumberOfFiguresInTheBox
        {
            get
            {
                yield return new TestCaseData(_sourceFigureList).Returns(9);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="BoxForFigures.GetSumAreaFigures"/>
        /// </summary>
        public static IEnumerable TestCasesGetSumAreaFigures
        {
            get
            {
                yield return new TestCaseData(_sourceFigureListWithOutBigValue).Returns(1.2427690000000102E+18d);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="BoxForFigures.GetSumAreaFigures"/>
        /// </summary>
        public static IEnumerable TestCasesGetSumAreaFiguresOutIsInfinity
        {
            get
            {
                yield return new TestCaseData(_sourceFigureList).Returns(double.PositiveInfinity);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="BoxForFigures.GetSumPerimeterFigures"/>
        /// </summary>
        public static IEnumerable TestCasesGetSumPerimetersFigures
        {
            get
            {
                yield return new TestCaseData(_sourceFigureListWithOutBigValue).Returns(400004452000524.0d);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="BoxForFigures.GetSumPerimeterFigures"/>
        /// </summary>
        public static IEnumerable TestCasesGetSumPerimetersFiguresOutIsBigValue
        {
            get
            {
                yield return new TestCaseData(_sourceFigureList).Returns(9.6910681124653138E+305d);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="BoxForFigures.GetAllCircles"/>
        /// </summary>
        public static IEnumerable TestCasesGetAllCirclesThenOutIsEmpty
        {
            get
            {
                yield return new TestCaseData(_sourceFigureListWithOutCircle).Returns(new List<Circle> { });
            }
        }

        /// <summary>
        /// Test cases for method <see cref="BoxForFigures.GetAllCircles"/>
        /// </summary>
        public static IEnumerable TestCasesGetAllCirclesThenOutIsCircleList
        {
            get
            {
                yield return new TestCaseData(_sourceFigureWithCircleList).Returns(_sourceFigureCircleList);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="BoxForFigures.GetAllFilmFigures"/>
        /// </summary>
        public static IEnumerable GetAllFilmFiguresThenOutIsEmpty
        {
            get
            {
                yield return new TestCaseData(_sourcePaperFigures).Returns(new List<Figure> { });
            }
        }

        /// <summary>
        /// Test cases for method <see cref="BoxForFigures.GetAllFilmFigures"/>
        /// </summary>
        public static IEnumerable GetAllFilmFiguresThenOutIsFilmFiguresList
        {
            get
            {
                yield return new TestCaseData(_sourceFigureList).Returns(_sourceFilmFigures);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="BoxForFigures.SaveAllFiguresInXmlUsingStreamWriter(string)"/>
        /// </summary>
        public static IEnumerable GetSaveAllFiguresInXmlUsingStreamWriter
        {
            get
            {
                yield return new TestCaseData(_sourceFigureList);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="BoxForFigures.SaveFilmFiguresInXmlUsingStreamWriter(string)"/>
        /// </summary>
        public static IEnumerable GetSaveFilmFiguresInXmlUsingStreamWriter
        {
            get
            {
                yield return new TestCaseData(_sourceFigureList);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="BoxForFigures.SavePaperFiguresInXmlUsingStreamWriter(string)"/>
        /// </summary>
        public static IEnumerable GetSavePaperFiguresInXmlUsingStreamWriter
        {
            get
            {
                yield return new TestCaseData(_sourceFigureList);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="BoxForFiguresTests.GiveSaveAllFiguresInXmlUsingXmlWriterrWhenThenOut"/>
        /// and <seealso cref="BoxForFiguresTests.GiveSaveFilmFiguresInXmlUsingXmlWriter"/> and
        /// <seealso cref="BoxForFiguresTests.GiveSavePaperFiguresInXmlUsingXmlWriter"/>
        /// </summary>
        public static IEnumerable GetSaveAllFiguresInXmlUsingXmlWriter
        {
            get
            {
                yield return new TestCaseData(_sourceFigureList);
            }
        }
    }
}
