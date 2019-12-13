//using NUnit.Framework;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using InheritanceInterfacesAbstractAndClasses;
//using InheritanceInterfacesAbstractAndClasses.Figures;

//namespace InheritanceInterfacesAbstractAndClassesTests
//{
//    public static class MyFactoryBoxForFiguresTests
//    {
//        private static readonly Figure[] _sourceFigures = new Figure[]
//        {
//            new Square(10), new Square(100), new Rectangle(11, 11), new Square(double.MaxValue), new Rectangle(double.MaxValue, 20)
//        };

//        private static readonly List<Figure> _sourceFigureList = new List<Figure>
//        {
//            new Square(10), new Square(100), new Rectangle(11, 11), new Square(double.MaxValue), new Rectangle(double.MaxValue, 20)
//        };

//        private static readonly List<Figure> _sourceFigureListWithOutBigValue = new List<Figure>
//        {
//            new Square(10), new Square(100), new Rectangle(11, 11), new Square(1000000000), new Rectangle(200000000000000, 20)
//        };

//        private static readonly List<Figure> _sourceFigureWithCircleList = new List<Figure>
//        {
//            new Square(10), new Square(100), new Circle(1), new Rectangle(11, 11), new Square(double.MaxValue), new Rectangle(double.MaxValue, 20), new Circle(10), new Circle(100)
//        };

//        private static readonly List<Figure> _sourceFigureCircleList = new List<Figure>
//        {
//            new Circle(1), new Circle(10), new Circle(100)
//        };

//        public static IEnumerable TestCasesFindFigureById
//        {
//            get
//            {
//                yield return new TestCaseData(_sourceFigures, 5).Returns(null);
//                yield return new TestCaseData(_sourceFigures, -1).Returns(null);
//                yield return new TestCaseData( _sourceFigures, 0).Returns(_sourceFigures[0]);
//                yield return new TestCaseData( _sourceFigures, 1).Returns(_sourceFigures[1]);
//                yield return new TestCaseData(_sourceFigures, 2).Returns(_sourceFigures[2]);
//                yield return new TestCaseData(_sourceFigures, 3).Returns(_sourceFigures[3]);
//                yield return new TestCaseData(_sourceFigures, 4).Returns(_sourceFigures[4]);
//            }
//        }

//        public static IEnumerable TestCasesExecuteFigureById
//        {
//            get
//            {
//                yield return new TestCaseData(_sourceFigures, 0).Returns(_sourceFigures[0]);
//                yield return new TestCaseData(_sourceFigures, 1).Returns(_sourceFigures[1]);
//                yield return new TestCaseData(_sourceFigures, 2).Returns(_sourceFigures[2]);
//                yield return new TestCaseData(_sourceFigures, 3).Returns(_sourceFigures[3]);
//                yield return new TestCaseData(_sourceFigures, 4).Returns(_sourceFigures[4]);
//                yield return new TestCaseData(_sourceFigures, 5).Returns(null);
//                yield return new TestCaseData(_sourceFigures, -1).Returns(null);
//            }
//        }

//        public static IEnumerable TestCasesExecuteFigureByIdThennOutputListLessByOne
//        {
//            get
//            {
//                yield return new TestCaseData(_sourceFigureList, 5).Returns(_sourceFigureList.Count);
//                yield return new TestCaseData(_sourceFigureList, -1).Returns(_sourceFigureList.Count);
//                yield return new TestCaseData(_sourceFigureList, 4).Returns(_sourceFigureList.Count - 1);
//                yield return new TestCaseData(_sourceFigureList, 3).Returns(_sourceFigureList.Count - 1);
//                yield return new TestCaseData(_sourceFigureList, 2).Returns(_sourceFigureList.Count - 1);
//                yield return new TestCaseData(_sourceFigureList, 1).Returns(_sourceFigureList.Count - 1);
//                yield return new TestCaseData(_sourceFigureList, 0).Returns(_sourceFigureList.Count - 1);
//            }
//        }

//        public static IEnumerable TestCasesReplaceById
//        {
//            get
//            {
//                yield return new TestCaseData(_sourceFigureList, 4, new Square(111)).Returns(new Square(111));
//                yield return new TestCaseData(_sourceFigureList, 3, new Square(111)).Returns(new Square(111));
//                yield return new TestCaseData(_sourceFigureList, 2, new Square(111)).Returns(new Square(111));
//                yield return new TestCaseData(_sourceFigureList, 1, new Rectangle(111,111)).Returns(new Rectangle(111, 111));
//                yield return new TestCaseData(_sourceFigureList, 0, new Square(111)).Returns(new Square(111));
//            }
//        }

//        public static IEnumerable TestCasesFindFigureAccordingToThePattern
//        {
//            get
//            {
//                yield return new TestCaseData(_sourceFigureList, new Square(10)).Returns(0);
//                yield return new TestCaseData(_sourceFigureList, new Square(100)).Returns(1);
//                yield return new TestCaseData(_sourceFigureList, new Square(double.MaxValue)).Returns(3);
//                yield return new TestCaseData(_sourceFigureList, new Rectangle(11,11)).Returns(2);
//                yield return new TestCaseData(_sourceFigureList, null).Returns(-1);
//            }
//        }

//        public static IEnumerable TestCasesGetNumberOfFiguresInTheBox
//        {
//            get
//            {
//                yield return new TestCaseData(_sourceFigureList).Returns(5);
//            }
//        }

//        public static IEnumerable TestCasesGetSumAreaFigures
//        {
//            get
//            {
//                yield return new TestCaseData(_sourceFigureListWithOutBigValue).Returns(1.0040000000000102E+18d);
//            }
//        }

//        public static IEnumerable TestCasesGetSumAreaFiguresOutIsInfinity
//        {
//            get
//            {
//                yield return new TestCaseData(_sourceFigureList).Returns(double.PositiveInfinity);
//            }
//        }

//        public static IEnumerable TestCasesGetSumPerimetersFigures
//        {
//            get
//            {
//                yield return new TestCaseData(_sourceFigureListWithOutBigValue).Returns(400004000000524);
//            }
//        }

//        public static IEnumerable TestCasesGetSumPerimetersFiguresOutIsInfinity
//        {
//            get
//            {
//                yield return new TestCaseData(_sourceFigureList).Returns(double.PositiveInfinity);
//            }
//        }

//        public static IEnumerable TestCasesGetAllCirclesThenOutIsEmpty
//        {
//            get
//            {
//                yield return new TestCaseData(_sourceFigureList).Returns(new List<Circle> { });
//            }
//        }

//        public static IEnumerable TestCasesGetAllCirclesThenOutIsCircleList
//        {
//            get
//            {
//                yield return new TestCaseData(_sourceFigureWithCircleList).Returns(_sourceFigureCircleList);
//            }
//        }



//    }
//}
