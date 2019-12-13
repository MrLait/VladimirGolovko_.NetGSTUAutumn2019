using System;
using System.Resources;

namespace InheritanceInterfacesAbstractAndClasses
{
    /// <summary>
    /// 
    /// </summary>
    public class Square : Figure
    {
        private const string Message = "The bSide of the figure cannot be negative or equal to zero.";
        private double _aSide;

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double ASide
        {
            get => _aSide;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(message: Message);
                }

                _aSide = value;
            } 
        }

        /// <summary>
        /// 
        /// </summary>
        public Square() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aSide"></param>
        public Square(double aSide)
        {
            ASide = aSide;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override double GetAreaFigure()
        {
            return ASide * ASide;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeterFigure()
        {
            return 4 * ASide;
        }
    }
}
