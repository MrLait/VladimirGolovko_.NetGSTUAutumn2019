using InheritanceInterfacesAbstractAndClasses.Figures;
using InheritanceInterfacesAbstractAndClasses.Enum;
using System.Collections.Generic;
using System;
using System.Linq;
using InheritanceInterfacesAbstractAndClasses.IO;

namespace InheritanceInterfacesAbstractAndClasses
{
    /// <summary>
    /// A box in which you can fold and remove any figures.
    /// </summary>
    public class BoxForFigures
    {
        /// <summary>
        /// Box can contain only 20 figures.
        /// </summary>
        public const int MaxBoxSize = 20;

        private List<Figure> _figureList = new List<Figure>();

        /// <summary>
        ///The list for storing figures.
        /// </summary>
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

        /// <summary>
        /// Add a figure, you cannot add the same figure twice.
        /// </summary>
        /// <param name="figure">Geometric figure.</param>
        public void AddFigureToBox(Figure figure)
        {
            if (figure != null)
            {
                if (!FigureList.Contains(figure))
                    FigureList.Add(figure);
            }
        }

        /// <summary>
        /// View by number. The figure remains in the box.
        /// </summary>
        /// <param name="id">The id of the figure in the box.</param>
        /// <returns>Figure that is found by id.</returns>
        public Figure FindFigureById(int id)
        {
            if (id >= 0 && id < FigureList.Count)
                return FigureList.ElementAt(id);
            else
                return null;
        }

        /// <summary>
        /// Extract by number. The figure is removed from the box.
        /// </summary>
        /// <param name="id">The id of the figure in the box.</param>
        /// <returns>Figure that is found by id.</returns>
        public Figure ExecuteFigureById(int id)
        {
            Figure tmpFigure = FindFigureById(id);

            if (id >= 0 && id < FigureList.Count)
                FigureList.RemoveAt(id);

            return tmpFigure;
        }

        /// <summary>
        /// Replce figure in the box by id.
        /// </summary>
        /// <param name="id">The id figure in the box/</param>
        /// <param name="figure">The figure you want to place in the box.</param>
        public void ReplaceById(int id, Figure figure)
        {
            if (id >= 0 && id < FigureList.Count)
                FigureList[id] = figure;
        }

        /// <summary>
        ///Find a figure according to the pattern equivalent in its characteristics.
        /// </summary>
        /// <param name="figurePattern">Figure pattern.</param>
        /// <returns>Found figure according to the pattern.</returns>
        public Figure FindFigureAccordingToThePattern(Figure figurePattern)
        {
            int index = FigureList.IndexOf(figurePattern);
            return FindFigureById(index);
        }

        /// <summary>
        ///Show available number of figures.
        /// </summary>
        /// <returns>Number of figures.</returns>
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

        /// <summary>
        /// Calculate the total area.
        /// </summary>
        /// <returns>The total area.</returns>
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

        /// <summary>
        /// Calculate the total perimeter.
        /// </summary>
        /// <returns>The total perimeter.</returns>
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

        /// <summary>
        /// Get all circles from the box.
        /// </summary>
        /// <returns>List of all circles from the box.</returns>
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

        /// <summary>
        /// Get all film figures from the box.
        /// </summary>
        /// <returns>List of all film gigures from the box.</returns>
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

        /// <summary>
        /// Save all figures in XML format using Stream Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SaveAllFiguresInXmlUsingStreamWriter(string path)
        {
            StreamIO.SaveXmlDocumentUsingStreamWriter(ConverterListToXmlIO.AddFiguresInXml(FigureList), path); 
        }

        /// <summary>
        /// Save of all film figures in XML format using Stream Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SaveFilmFiguresInXmlUsingStreamWriter(string path)
        {
            StreamIO.SaveXmlDocumentUsingStreamWriter(ConverterListToXmlIO.AddFiguresInXml(FigureList, Material.Film), path);
        }

        /// <summary>
        /// Save of all paper figures in XML format using Stream Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SavePaperFiguresInXmlUsingStreamWriter(string path)
        {
            StreamIO.SaveXmlDocumentUsingStreamWriter(ConverterListToXmlIO.AddFiguresInXml(FigureList, Material.Paper), path);
        }

        /// <summary>
        /// Save of all figures in XML format using XML Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SaveAllFiguresInXmlUsingXmlWriter(string path)
        {
            XmlIO.SaveXmlDocumentUsingXmlWriter(ConverterListToXmlIO.AddFiguresInXml(FigureList), path);
        }

        /// <summary>
        /// Save of all film figures in XML format using XML Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SaveFilmFiguresInXmlUsingXmlWriter(string path)
        {
            XmlIO.SaveXmlDocumentUsingXmlWriter(ConverterListToXmlIO.AddFiguresInXml(FigureList, Material.Film), path);
        }
        /// <summary>
        /// Save of all paper figures in XML format using XML Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SavePaperFiguresInXmlUsingXmlWriter(string path)
        {
            XmlIO.SaveXmlDocumentUsingXmlWriter(ConverterListToXmlIO.AddFiguresInXml(FigureList, Material.Paper), path);
        }

        /// <summary>
        /// Load of all figures to the box using Stream Reader.
        /// </summary>
        public void LoadAllFiguresFromXmlUsingStreamReader(string path)
        {
            FigureList = ConverterListToXmlIO.ParsXmlDocToFigureList(StreamIO.LoadXmlDocumentUsingStreamReader(path));
        }

        /// <summary>
        /// Load of all figures to the box using XML Reader.
        /// </summary>
        public void LoadAllFiguresFromXmlUsingXmlReader(string path) 
        {
            FigureList = ConverterListToXmlIO.ParsXmlDocToFigureList(XmlIO.LoadXmlDocumentUsingXmlReader(path));
        }
    }
}

