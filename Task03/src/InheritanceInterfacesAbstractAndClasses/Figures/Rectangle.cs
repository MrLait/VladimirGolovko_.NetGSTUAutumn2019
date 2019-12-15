using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.UserExceptions;
using System;

namespace InheritanceInterfacesAbstractAndClasses.Figures
{
    /// <summary>
    /// A rectangle class that describes a rectangle figure.
    /// </summary>
    public class Rectangle : Square
    {
        private double _sideB;

        /// <summary>
        /// The constructor for type <see cref="Rectangle"/>
        /// </summary>
        /// <param name="sideA">Rectangle width.</param>
        /// <param name="sideB">Rectangle height.</param>
        /// <param name="material">Rectangle material.</param>
        public Rectangle(double sideA, double sideB, Material material) : base(sideA, material)
        {
            SideB = sideB;
        }

        /// <summary>
        /// Type constructor for to cut one figure from another.
        /// The area of ​​the figure should be larger than the area of ​​the figure that is cut out of it.
        /// </summary>
        /// <param name="figure">Source figure.</param>
        /// <param name="sideA">The width of the figure you want to get.</param>
        /// <param name="sideB">The height of the figure you want to get.</param>
        public Rectangle(Figure figure, double sideA, double sideB) : base(figure, sideA)
        {
            SideB = sideB;

            if (figure.GetAreaFigure() < this.GetAreaFigure())
            {
                throw new CutException("The cut figure cannot be larger than the source figure.");
            }
        }

        /// <summary>
        /// Height of the rectangle.
        /// The Height of the figure cannot be negative or equal to zero.
        /// </summary>
        public double SideB
        {
            get { return _sideB; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The side-b of the figure cannot be negative or equal to zero.");
                }

                _sideB = value;
            }
        }

        /// <summary>
        /// Rectangle material.
        /// </summary>
        public override Material Material => base.Material;

        /// <summary>
        /// Rectangle color.
        /// </summary>
        public override Colors Color => base.Color;

        /// <summary>
        /// Calculate rectangle area.
        /// </summary>
        /// <returns>The total area.</returns>
        public override double GetAreaFigure()
        {
            return SideA*SideB;
        }

        /// <summary>
        /// Calculate rectangle perimeter.
        /// </summary>
        /// <returns>The total perimeter.</returns>
        public override double GetPerimeter()
        {
            return 2*(SideA+SideB);
        }

        /// <summary>
        /// Comparing one rectangle with another.
        /// </summary>
        /// <param name="obj">The compared rectangle.</param>
        /// <returns>True if equal. False if not eqal.</returns>
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Rectangle r = (Rectangle)obj;
            return _sideB.Equals(r._sideB) && base.Equals((Square)obj);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hesh code.</returns>
        public override int GetHashCode()
        {
            return _sideB.GetHashCode() + base.GetHashCode();
        }

        /// <summary>
        /// Represents class members in string format.
        /// </summary>
        /// <returns>Returns class members in string format.</returns>
        public override string ToString()
        {
            return string.Format("{0};{1}", base.ToString(), SideB);
        }



    }
}
