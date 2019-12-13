using System;

namespace InheritanceInterfacesAbstractAndClasses
{
    public class Square : Figure
    {
        private const string Message = "The bSide of the figure cannot be negative or equal to zero.";
        private double _aSide;
        public double ASide
        {
            get => _aSide;
            set
            {
                string theBsideOfTheFigureCannotBeNegativeOrEqualToZero = Message;
                if (value <= 0)
                {
                    throw new ArgumentException(message: theBsideOfTheFigureCannotBeNegativeOrEqualToZero);
                }

                _aSide = value;
            } 
        }

        public Square() { }

        public Square(double aSide)
        {
            ASide = aSide;
        }
        public override double GetAreaFigure()
        {
            return ASide * ASide;
        }

        public override double GetPerimeterFigure()
        {
            return 4 * ASide;
        }
    }
}
