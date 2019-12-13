using System;

namespace InheritanceInterfacesAbstractAndClasses
{
    /// <summary>
    /// 
    /// </summary>
    public class Rectangle : Square
    {
        private const string Message = "The bSide of the figure cannot be negative or equal to zero.";
        private double _bSide;

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double BSide
        {
            get { return _bSide; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException(Message);
                else
                    _bSide = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Rectangle() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="square"></param>
        public Rectangle(Square square)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aSide"></param>
        /// <param name="bSide"></param>
        public Rectangle(double aSide, double bSide) : base(aSide)
        {
            BSide = bSide;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override double GetAreaFigure()
        {
            return ASide*BSide;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeterFigure()
        {
            return 2*(ASide+BSide);
        }
    }
}
