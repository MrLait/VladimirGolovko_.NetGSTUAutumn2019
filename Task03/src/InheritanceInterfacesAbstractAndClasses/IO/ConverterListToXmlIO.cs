using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.Figures;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace InheritanceInterfacesAbstractAndClasses.IO
{
    static class ConverterListToXmlIO
    {
        public static XDocument AddFiguresInXml(List<Figure> _figureList)
        {
            XDocument xdoc = new XDocument();

            if (_figureList != null)
            {
                List<XElement> xElementsFigures = new List<XElement>();
                int index = 0;

                foreach (var item in _figureList)
                {
                    if (item != null)
                    {
                        PrepareFigureToXml(item, xElementsFigures, index);
                        index++;
                    }
                }

                XElement figures = new XElement("Figures");

                foreach (var item in xElementsFigures)
                {
                    figures.Add(item);
                }

                xdoc.Add(figures);
            }
            return xdoc;
        }

        public static XDocument AddFiguresInXml(List<Figure> _figureList, Material material)
        {
            XDocument xdoc = new XDocument();

            if (_figureList != null)
            {
                List<XElement> xElementsFigures = new List<XElement>();
                int index = 0;

                foreach (var item in _figureList)
                {
                    if (item != null)
                    {
                        if (item.Material == material)
                        {
                            PrepareFigureToXml(item, xElementsFigures, index);
                            index++;
                        }
                    }
                }

                XElement figures = new XElement("Figures");

                foreach (var item in xElementsFigures)
                {
                    figures.Add(item);
                }

                xdoc.Add(figures);
            }
            return xdoc;
        }

        public static List<XElement> PrepareFigureToXml(Figure figure, List<XElement> xElementsFigures, int indexXElement)
        {
            string[] figureParams = figure.ToString().Split(';');

            string[] squereNameParams = { "Name", "Material", "Sides" };
            string[] rectangleNameParams = { "Name", "Material", "SideOne", "SideTwo" };
            string[] circleNameParams = { "Name", "Material", "radius" };

            xElementsFigures.Add(new XElement(figureParams[0]));
            XAttribute nameFigure = new XAttribute("Name", figureParams[0]);
            List<XElement> xElements = new List<XElement>();

            if (figure.GetType() == typeof(Square))
            {
                for (int i = 1; i < figureParams.Length; i++)
                    xElements.Add(new XElement(squereNameParams[i], figureParams[i]));
            }
            if (figure.GetType() == typeof(Rectangle))
            {
                for (int i = 1; i < figureParams.Length; i++)
                    xElements.Add(new XElement(rectangleNameParams[i], figureParams[i]));
            }
            if (figure.GetType() == typeof(Circle))
            {
                for (int i = 1; i < figureParams.Length; i++)
                    xElements.Add(new XElement(circleNameParams[i], figureParams[i]));
            }

            xElementsFigures[indexXElement].Add(nameFigure);

            foreach (var item in xElements)
                xElementsFigures[indexXElement].Add(item);

            return xElementsFigures;
        }

        public static List<Figure> ParsXmlDocToFigureList(XmlDocument xmlDocument)
        {
            List<Figure> figures = new List<Figure>();
            XmlElement xRoot = xmlDocument.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("*");

            try
            {
                for (int i = 0; i < childnodes.Count; i++)
                {
                    if (childnodes[i].Name == "Square")
                    {
                        if (childnodes[i].ChildNodes[0].InnerText == "Film")
                        {
                            figures.Add(new Square(double.Parse(childnodes[i].ChildNodes[1].InnerText), Material.Film));
                        }
                        if (childnodes[i].ChildNodes[0].InnerText == "Paper")
                        {
                            figures.Add(new Square(double.Parse(childnodes[i].ChildNodes[1].InnerText), Material.Paper));
                        }
                    }
                    if (childnodes[i].Name == "Rectangle")
                    {
                        if (childnodes[i].ChildNodes[0].InnerText == "Film")
                        {
                            figures.Add(new Rectangle(
                                double.Parse(childnodes[i].ChildNodes[1].InnerText),
                                double.Parse(childnodes[i].ChildNodes[2].InnerText),
                                Material.Film));
                        }
                        if (childnodes[i].ChildNodes[0].InnerText == "Paper")
                        {
                            figures.Add(new Rectangle(
                                double.Parse(childnodes[i].ChildNodes[1].InnerText),
                                double.Parse(childnodes[i].ChildNodes[2].InnerText),
                                Material.Paper));
                        }
                    }
                    if (childnodes[i].Name == "Circle")
                    {
                        if (childnodes[i].ChildNodes[0].InnerText == "Film")
                        {
                            figures.Add(new Circle(
                                double.Parse(childnodes[i].ChildNodes[1].InnerText),
                                Material.Film));
                        }
                        if (childnodes[i].ChildNodes[0].InnerText == "Paper")
                        {
                            figures.Add(new Circle(
                                double.Parse(childnodes[i].ChildNodes[1].InnerText),
                                Material.Paper));
                        }
                    }
                }
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (OverflowException)
            {
                throw new OverflowException();
            }
            return figures;
        }



    }
}
