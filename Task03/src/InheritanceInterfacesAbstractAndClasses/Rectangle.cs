using System;

namespace InheritanceInterfacesAbstractAndClasses
{
    public class Rectangle : Square
    {
        private const string Message = "The bSide of the figure cannot be negative or equal to zero.";
        private double bSide;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Не передавать литералы в качестве локализованных параметров", Justification = "<Ожидание>")]
        public double BSide
        {
            get { return bSide; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException(Message);
                else
                    bSide = value;
            }
        }

        public static int Add(int firstNum, int secondNum)
        {
            int result = firstNum + secondNum;
            return result; 
        }

        public Rectangle() { }

        public Rectangle(double aSide, double bSide) : base(aSide)
        {
            BSide = bSide;
        }

        public override double GetAreaFigure()
        {
            return ASide*BSide;
        }

        public override double GetPerimeterFigure()
        {
            return 2*(ASide+BSide);
        }
    }
}
