using InheritanceInterfacesAbstractAndClasses.Figures;
using System.Collections.Generic;
using System.Linq;

namespace InheritanceInterfacesAbstractAndClasses
{
    public class BoxForFigures
    {
        private List<Figure> _figureList = new List<Figure>();

        public List<Figure> FugureList
        {
            get => _figureList;
            set => _figureList = value;
        }

        public void AddFigureToBox(Figure figure)
        {
            if (figure != null)
            {
                _figureList.Add(figure);
            }
        }

        public Figure FindFigureById(int id)
        {
            if (id >= 0 && id < _figureList.Count)
                return _figureList.ElementAt(id);
            else
                return null;
        }

        public Figure ExecuteFigureById(int id)
        {
            Figure tmpFigure = FindFigureById(id);

            if (id >= 0 && id < _figureList.Count)
                _figureList.RemoveAt(id);

            return tmpFigure;
        }

        public void ReplaceById(int id, Figure figure)
        {
            if (id >= 0 && id < _figureList.Count)
                _figureList[id] = figure;
        }

        public int FindFigureAccordingToThePattern(Figure figurePattern)
        {

            return _figureList.IndexOf(figurePattern);
        }

        public int GetNumberOfFiguresInTheBox()
        {
            int figureCounter = 0;

            if (_figureList != null)
            {
                foreach (var item in _figureList)
                {
                    if (item != null)
                    {
                        figureCounter++;
                    }
                }
            }

            return figureCounter;
        }

        public double GetSumAreaFigures()
        {
            double tmpSumAreaFigures = 0;

            if (_figureList != null)
            {
                foreach (var item in _figureList)
                {
                    if (item != null)
                    {
                        tmpSumAreaFigures += item.GetAreaFigure();
                    }
                }
            }

            return tmpSumAreaFigures;
        }

        public double GetSumPerimeterFigures()
        {
            double tmpSumPerimeterFigures = 0;

            if (_figureList != null)
            {
                foreach (var item in _figureList)
                {
                    if (item != null)
                    {
                        tmpSumPerimeterFigures += item.GetPerimeterFigure();
                    }
                }
            }

            return tmpSumPerimeterFigures;
        }

        public List<Circle> GetAllCircles()
        {
            List<Circle> tmpCircles = new List<Circle>();

            if (_figureList != null)
            {
                foreach (var item in _figureList)
                {
                    if (item.GetType() == typeof(Circle))
                    {
                        tmpCircles.Add((Circle)item);
                    }
                }
            }
            return tmpCircles;
        }

        public static List<Figure> GetAllFilmFigures(){ return null; }

        public static void SaveAllFiguresInXmlUsingStreamWriter() { }
        public static void SaveFilmFiguresInXmlUsingStreamWriter() { }
        public static void SavePaperFiguresInXmlUsingStreamWriter() { }
        public static void SaveAllFiguresInXmlUsingXmlWriter() { }
        public static void SaveFilmFiguresInXmlUsingXmlWriter() { }
        public static void SavePaperFiguresInXmlUsingXmlWriter() { }
        public static void LoadAllFiguresFromXmlUsingStreamWriter() { }
        public static void LoadAllFiguresFromXmlUsingXmlWriter() { }




    }
}