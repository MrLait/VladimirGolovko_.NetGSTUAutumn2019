using System.Collections.Generic;

namespace InheritanceInterfacesAbstractAndClasses
{
    public class BoxForFigures
    {
        private List<Figure> _fugureList = new List<Figure>();

        public List<Figure> FugureList
        {
            get => _fugureList;
            set => _fugureList = value;
        }

        public static void AddFigureToBox(Figure figure)
        {

        }

        public static Figure FindFigureById(int id)
        {
            return null;
        }

        public static Figure ExecuteFigureById(int id)
        {
            return null;
        }

        public static void ReplaceByNumber(int id)
        {

        }

        public static Figure FindFigure(Figure figure)
        {
            return null;
        }

        public static int GetNumberOfFigures()
        {
            return 0;
        }

        public static decimal GetSumAreaFigures()
        {
            return 0;
        }

        public static decimal GetSumPerimeterFigures()
        {
            return 0;
        }

        public static List<Figure> GetAllCircles()
        {
            return null;
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