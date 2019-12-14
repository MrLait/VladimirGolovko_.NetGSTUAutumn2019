using InheritanceInterfacesAbstractAndClasses.Figures;
using InheritanceInterfacesAbstractAndClasses.Enum;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml;
using System.Text;
using InheritanceInterfacesAbstractAndClasses.IO;

namespace InheritanceInterfacesAbstractAndClasses
{
    public class BoxForFigures
    {
        public const int MaxBoxSize = 20;

        private List<Figure> _figureList = new List<Figure>();

        public List<Figure> FigureList
        {
            get
            {
                if (_figureList.Count <= MaxBoxSize)
                    return  _figureList;
                else
                    throw new IndexOutOfRangeException("Index out of range in the box");
            }
            set => _figureList = value;
        }

        public void AddFigureToBox(Figure figure)
        {
            if (figure != null)
            {
                if (!FigureList.Contains(figure))
                    FigureList.Add(figure);
            }
        }

        public Figure FindFigureById(int id)
        {
            if (id >= 0 && id < FigureList.Count)
                return FigureList.ElementAt(id);
            else
                return null;
        }

        public Figure ExecuteFigureById(int id)
        {
            Figure tmpFigure = FindFigureById(id);

            if (id >= 0 && id < FigureList.Count)
                FigureList.RemoveAt(id);

            return tmpFigure;
        }

        public void ReplaceById(int id, Figure figure)
        {
            if (id >= 0 && id < FigureList.Count)
                FigureList[id] = figure;
        }

        public Figure FindFigureAccordingToThePattern(Figure figurePattern)
        {
            int index = FigureList.IndexOf(figurePattern);
            return FindFigureById(index);
        }

        public int GetNumberOfFiguresInTheBox()
        {
            int figureCounter = 0;

            if (FigureList != null)
            {
                foreach (var item in FigureList)
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

            if (FigureList != null)
            {
                foreach (var item in FigureList)
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

            if (FigureList != null)
            {
                foreach (var item in FigureList)
                {
                    if (item != null)
                    {
                        tmpSumPerimeterFigures += item.GetPerimeter();
                    }
                }
            }

            return tmpSumPerimeterFigures;
        }

        public List<Circle> GetAllCircles()
        {
            List<Circle> tmpCircleFigures = new List<Circle>();

            if (FigureList != null)
            {
                foreach (var item in FigureList)
                {
                    if (item.GetType() == typeof(Circle))
                    {
                        tmpCircleFigures.Add((Circle)item);
                    }
                }
            }
            return tmpCircleFigures;
        }

        public List<Figure> GetAllFilmFigures()
        {
            List<Figure> tmpFilmFigures = new List<Figure>();

            if (FigureList != null)
            {
                foreach (var item in FigureList)
                {
                    if (item.Material == Material.Film)
                    {
                        tmpFilmFigures.Add(item);
                    }
                }
            }

            return tmpFilmFigures;
        }

        public void SaveAllFiguresInXmlUsingStreamWriter(string path)
        {
            StreamIO.SaveXmlDocumentUsingStreamWriter(ConverterListToXmlIO.AddFiguresInXml(FigureList), path); 
        }

        public void SaveFilmFiguresInXmlUsingStreamWriter(string path)
        {
            StreamIO.SaveXmlDocumentUsingStreamWriter(ConverterListToXmlIO.AddFiguresInXml(FigureList, Material.Film), path);
        }

        public void SavePaperFiguresInXmlUsingStreamWriter(string path)
        {
            StreamIO.SaveXmlDocumentUsingStreamWriter(ConverterListToXmlIO.AddFiguresInXml(FigureList, Material.Paper), path);
        }

        public void SaveAllFiguresInXmlUsingXmlWriter(string path)
        {
            XmlIO.SaveXmlDocumentUsingXmlWriter(ConverterListToXmlIO.AddFiguresInXml(FigureList), path);
        }

        public void SaveFilmFiguresInXmlUsingXmlWriter(string path)
        {
            XmlIO.SaveXmlDocumentUsingXmlWriter(ConverterListToXmlIO.AddFiguresInXml(FigureList, Material.Film), path);
        }

        public void SavePaperFiguresInXmlUsingXmlWriter(string path)
        {
            XmlIO.SaveXmlDocumentUsingXmlWriter(ConverterListToXmlIO.AddFiguresInXml(FigureList, Material.Paper), path);
        }

        public void LoadAllFiguresFromXmlUsingStreamReader(string path)
        {
            FigureList = ConverterListToXmlIO.ParsXmlDocToFigureList(StreamIO.LoadXmlDocumentUsingStreamReader(path));
        }

        public void LoadAllFiguresFromXmlUsingXmlReader(string path) 
        {
            FigureList = ConverterListToXmlIO.ParsXmlDocToFigureList(XmlIO.LoadXmlDocumentUsingXmlReader(path));
        }
    }
}

