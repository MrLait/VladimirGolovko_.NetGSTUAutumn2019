using System;
using System.Resources;

namespace InheritanceInterfacesAbstractAndClasses.Figures
{
    /// <summary>
    /// 
    /// </summary>
    public class Square : Figure
    {
        private double _sideA;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sideA"></param>
        public Square(double sideA)
        {
            SideA = sideA;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override double GetAreaFigure()
        {
            return SideA * SideA;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double SideA
        {
            get => _sideA;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The side-a of the figure cannot be negative or equal to zero.");
                }
                else
                {
                    _sideA = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeterFigure()
        {
            return 4 * SideA;
        }

        public override bool Equals(Object obj)
        {
            // Perform an equality check on two rectangles (Point object pairs).
            if (obj == null || GetType() != obj.GetType())
                return false;
            Square r = (Square)obj;
            return _sideA.Equals(r._sideA);
        }

        public override int GetHashCode()
        {
            return _sideA.GetHashCode();
        }

    }
}
