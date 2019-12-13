using System;

namespace InheritanceInterfacesAbstractAndClasses.Figures
{
    /// <summary>
    /// 
    /// </summary>
    public class Rectangle : Square
    {
        private double _sideB;

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double SideB
        {
            get { return _sideB; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The side-b of the figure cannot be negative or equal to zero.");
                }
                else
                {
                    _sideB = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        public Rectangle(double sideA, double sideB) : base(sideA)
        {
            SideB = sideB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override double GetAreaFigure()
        {
            return SideA*SideB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeterFigure()
        {
            return 2*(SideA+SideB);
        }

        public override bool Equals(Object obj)
        {
            // Perform an equality check on two rectangles (Point object pairs).
            if (obj == null || GetType() != obj.GetType())
                return false;
            Rectangle r = (Rectangle)obj;
            return _sideB.Equals(r._sideB) && base.Equals((Square)obj);//base.SideA.Equals(r.SideA)
        }

        public override int GetHashCode()
        {
            return _sideB.GetHashCode() + base.SideA.GetHashCode();
        }
    }
}
