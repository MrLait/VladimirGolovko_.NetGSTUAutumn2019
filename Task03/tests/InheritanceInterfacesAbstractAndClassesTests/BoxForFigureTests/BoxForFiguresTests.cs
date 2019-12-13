//using System;
//using System.Collections.Generic;
//using NUnit.Framework;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Assert = NUnit.Framework.Assert;
//using InheritanceInterfacesAbstractAndClasses;
//using InheritanceInterfacesAbstractAndClasses.Figures;

//namespace InheritanceInterfacesAbstractAndClassesTests
//{
//    [TestFixture]
//    public class BoxForFiguresTests
//    {
//        private static readonly object[] _sourceSquareFigureList =
//        {
//            new object[]
//            {
//                new List<Figure>{new Square(10)},
//                new List<Figure>{new Square(10)}
//            },
//            new object[]
//            {
//                new List<Figure>{new Square(double.MaxValue), new Square(10)},
//                new List<Figure>{new Square(double.MaxValue), new Square(10)}
//            }
//        };

//        private static readonly object[] _sourceRectangleFigureList = {
//            new object[]
//            {
//                new List<Figure>{new Rectangle(100,100)},
//                new List<Figure>{new Rectangle(100,100)}
//            },
//            new object[]
//            {
//            new List<Figure>{new Rectangle(double.MaxValue,double.MaxValue), new Rectangle(double.MaxValue,100)},
//            new List<Figure>{new Rectangle(double.MaxValue,double.MaxValue), new Rectangle(double.MaxValue,100)}
//            }
//        };

//        private static readonly object[] _sourceFigureObjects =
//        {
//            new object[]
//            {
//                new Figure[] 
//                { 
//                    new Square(10), new Square(100), new Rectangle(11, 11), new Square(double.MaxValue), new Rectangle(double.MaxValue, 20)
//                },
//                new List<Figure> 
//                { 
//                    new Square(10), new Square(100), new Rectangle(11, 11), new Square(double.MaxValue), new Rectangle(double.MaxValue, 20) 
//                }
//            }
//        };

//        [Test, TestCaseSource(nameof(_sourceSquareFigureList))]
//        public void GivenSquareListWhenFigureIsSquareThenOutContainList(List<Figure> actualSquareFigureList, List<Figure> expectedSquareFigureList)
//        {
//            //Assert
//            Assert.AreEqual(expectedSquareFigureList, actualSquareFigureList);
//        }

//        [Test, TestCaseSource(nameof(_sourceRectangleFigureList))]
//        public void GivenRectangleListWhenFigureIsRectangleThenOutContainList(List<Figure> actualRectangleFigureList, List<Figure> expectedRectangleFigureList)
//        {
//            //Assert
//            Assert.AreEqual(expectedRectangleFigureList, actualRectangleFigureList);
//        }

//        [TestCase(double.MinValue, 0)]
//        public void GivenSquareListWhenFigureIsSquareThenOutArgumentException(double arg0SideA, double arg1SideA)
//        {
//            //Assert
//            Assert.Throws<ArgumentException>(
//                () =>
//                {
//                    new List<Figure>()
//                    {
//                            new Square(arg0SideA),
//                            new Square(arg1SideA)
//                    };
//                });
//        }

//        [Test, TestCaseSource(nameof(_sourceFigureObjects))]
//        public void GivenAddFigureToBoxWhenFigureIsDifferentThenOutIsFigureList(Figure[] actualFigure, List<Figure> expectedRectangleFigureList)
//        {
//            //Arrange
//            BoxForFigures boxForFigures = new BoxForFigures();
//            List<Figure> actualBoxList;

//            //Act
//            if (actualFigure != null)
//            {
//                foreach (Figure item in actualFigure)
//                {
//                    boxForFigures.AddFigureToBox(item);
//                }
//            }
//            actualBoxList = boxForFigures.FugureList;

//            //Assert
//            Assert.AreEqual(expectedRectangleFigureList, actualBoxList);
//        }

//        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesFindFigureById")]
//        public Figure GivenFindFigureByIdWhenByIdThenOutIsFigure(Figure[] actualFigure, int figureId)
//        {
//            //Arrange
//            BoxForFigures boxForFigures = new BoxForFigures();

//            //Act
//            if (actualFigure != null)
//            {
//                foreach (Figure item in actualFigure)
//                {
//                    boxForFigures.AddFigureToBox(item);
//                }
//            }
            

//            //Assert
//            return boxForFigures.FindFigureById(figureId);
//        }


//        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesExecuteFigureById")]
//        public Figure GivenExecuteFigureByIdWhenByIdThenOutIsFigure(Figure[] actualFigure, int figureId)
//        {
//            //Arrange
//            BoxForFigures boxForFigures = new BoxForFigures();

//            //Act
//            if (actualFigure != null)
//            {
//                foreach (Figure item in actualFigure)
//                {
//                    boxForFigures.AddFigureToBox(item);
//                }
//            }

//            //Assert
//            return boxForFigures.ExecuteFigureById(figureId);
//        }

//        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesExecuteFigureByIdThennOutputListLessByOne")]
//        public int GivenExecuteFigureByIdWhenByIdThenOutputListLessByOne(List<Figure> actualFigure, int figureId)
//        {
//            //Arrange
//            List<Figure> tmpFigures = new List<Figure>(actualFigure);
//            BoxForFigures boxForFigures = new BoxForFigures
//            {
//                FugureList = tmpFigures
//            };

//            //Act
//            boxForFigures.ExecuteFigureById(figureId);

//            //Assert
//            return boxForFigures.FugureList.Count;
//        }

//        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesReplaceById")]
//        public Figure GivenReplaceByIdWhenByIdThenOutNewFigureList(List<Figure> actualFigure, int figureId, Figure figure)
//        {
//            //Arrange
//            List<Figure> tmpFigures = new List<Figure>(actualFigure);
//            BoxForFigures boxForFigures = new BoxForFigures
//            {
//                FugureList = tmpFigures
//            };

//            //Act
//            boxForFigures.ReplaceById(figureId, figure);

//            //Assert
//            return boxForFigures.FugureList[figureId];
//        }

//        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesFindFigureAccordingToThePattern")]
//        public int GiveFindFigureAccordingToThePatternWhenPatterIsValidThenOutFigureId(List<Figure> actualFigure, Figure figurePattern)
//        {
//            //Arrange
//            List<Figure> tmpFigures = new List<Figure>(actualFigure);
//            BoxForFigures boxForFigures = new BoxForFigures
//            {
//                FugureList = tmpFigures
//            };

//            //Act
//            int figureId = boxForFigures.FindFigureAccordingToThePattern(figurePattern);

//            //Assert
//            return figureId;
//        }

//        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesGetNumberOfFiguresInTheBox")]
//        public int GiveGetNumberOfFiguresInTheBoxWhenInputIsListFiguresThenOutNumberOfFigures(List<Figure> actualFigure)
//        {
//            //Arrange
//            List<Figure> tmpFigures = new List<Figure>(actualFigure);
//            BoxForFigures boxForFigures = new BoxForFigures
//            {
//                FugureList = tmpFigures
//            };

//            //Act
//            int figureCount = boxForFigures.GetNumberOfFiguresInTheBox();

//            //Assert
//            return figureCount;
//        }

//        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesGetSumAreaFigures")]
//        public double GiveGetSumAreaFiguresWhenInputIsListFiguresThenOutIsValidSumOfArea(List<Figure> actualFigure)
//        {
//            //Arrange
//            List<Figure> tmpFigures = new List<Figure>(actualFigure);
//            BoxForFigures boxForFigures = new BoxForFigures
//            {
//                FugureList = tmpFigures
//            };

//            //Act
//            double figureAreaCount = boxForFigures.GetSumAreaFigures();

//            //Assert
//            return figureAreaCount;
//        }

//        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesGetSumAreaFiguresOutIsInfinity")]
//        public double GiveGetSumAreaFiguresWhenInputIsListWithBigValuesFiguresThenOutIsInfinity(List<Figure> actualFigure)
//        {
//            //Arrange
//            List<Figure> tmpFigures = new List<Figure>(actualFigure);
//            BoxForFigures boxForFigures = new BoxForFigures
//            {
//                FugureList = tmpFigures
//            };

//            //Act
//            double figureAreaCount = boxForFigures.GetSumAreaFigures();

//            //Assert
//            return figureAreaCount;
//        }

//        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesGetSumPerimetersFigures")]
//        public double GiveGetSumPerimeterFiguresWhenInputIsListFiguresThenOutIsValidSumOfArea(List<Figure> actualFigure)
//        {
//            //Arrange
//            List<Figure> tmpFigures = new List<Figure>(actualFigure);
//            BoxForFigures boxForFigures = new BoxForFigures
//            {
//                FugureList = tmpFigures
//            };

//            //Act
//            double figureAreaCount = boxForFigures.GetSumPerimeterFigures();

//            //Assert
//            return figureAreaCount;
//        }

//        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesGetSumPerimetersFiguresOutIsInfinity")]
//        public double GiveGetSumPerimeterFiguresWhenInputIsListWithBigValuesFiguresThenOutIsInfinity(List<Figure> actualFigure)
//        {
//            //Arrange
//            List<Figure> tmpFigures = new List<Figure>(actualFigure);
//            BoxForFigures boxForFigures = new BoxForFigures
//            {
//                FugureList = tmpFigures
//            };

//            //Act
//            double figureAreaCount = boxForFigures.GetSumPerimeterFigures();

//            //Assert
//            return figureAreaCount;
//        }

//        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesGetAllCirclesThenOutIsEmpty")]
//        public List<Circle> GiveGetAllCirclesWhenInputIsListWithoutCircleThenOutIsEmpty(List<Figure> actualFigure)
//        {
//            //Arrange
//            List<Figure> tmpFigures = new List<Figure>(actualFigure);
//            BoxForFigures boxForFigures = new BoxForFigures
//            {
//                FugureList = tmpFigures
//            };

//            //Act
//            List<Circle> figureAreaCount = boxForFigures.GetAllCircles();

//            //Assert
//            return figureAreaCount;
//        }

//        [Test, TestCaseSource(typeof(MyFactoryBoxForFiguresTests), "TestCasesGetAllCirclesThenOutIsCircleList")]
//        public List<Circle> GiveGetAllCirclesWhenInputIsListWithCircleThenOutIsCircleList(List<Figure> actualFigure)
//        {
//            //Arrange
//            List<Figure> tmpFigures = new List<Figure>(actualFigure);
//            BoxForFigures boxForFigures = new BoxForFigures
//            {
//                FugureList = tmpFigures
//            };

//            //Act
//            List<Circle> figureAreaCount = boxForFigures.GetAllCircles();

//            //Assert
//            return figureAreaCount;
//        }




//    }
//}