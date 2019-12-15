using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.UserExceptions;
using System;

namespace InheritanceInterfacesAbstractAndClasses.Figures
{
    /// <summary>
    /// A square class that describes a square figure.
    /// </summary>
    public class Square : Figure
    {
        private double _sideA;

        private Square(double sideA)
        {
            SideA = sideA;
        }

        /// <summary>
        /// The constructor for type <see cref="Square"/>
        /// </summary>
        /// <param name="sideA">Square width and height.</param>
        /// <param name="material">Square material.</param>
        public Square(double sideA, Material material)
        {
            Material = material;
            SideA = sideA;
        }

        /// <summary>
        /// Type constructor for to cut one figure from another.
        /// The area of ​​the figure should be larger than the area of ​​the figure that is cut out of it.
        /// </summary>
        /// <param name="figure">Source figure.</param>
        /// <param name="sideA">The width and height of the figure you want to get.</param>
        public Square(Figure figure, double sideA) : this(sideA)
        {
            if (figure.GetAreaFigure() < this.GetAreaFigure())
            {
                throw new CutException("The cut figure cannot be larger than the source figure.");
            }
            Material = figure.Material;
        }

        /// <summary>
        /// Width and height of the square.
        /// The Height of the figure cannot be negative or equal to zero.
        /// </summary>
        public double SideA
        {
            get => _sideA;
            set
            {
                if (value <= 0)
                { 
                    throw new ArgumentException("The side-a of the figure cannot be negative or equal to zero.");
                }

                _sideA = value;
            }
        }

        /// <summary>
        /// Square material.
        /// </summary>
        public override Material Material { get; }

        /// <summary>
        /// Square color.
        /// </summary>
        public override Colors Color => base.Color;

        /// <summary>
        /// Calculate square area.
        /// </summary>
        /// <returns>The total area.</returns>
        public override double GetAreaFigure()
        {
            return SideA * SideA;
        }

        /// <summary>
        /// Calculate square perimeter.
        /// </summary>
        /// <returns>The total perimeter.</returns>
        public override double GetPerimeter()
        {
            return 4 * SideA;
        }

        /// <summary>
        /// Comparing one square with another.
        /// </summary>
        /// <param name="obj">The compared square.</param>
        /// <returns>True if equal. False if not eqal.</returns>
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Square r = (Square)obj;
            return _sideA.Equals(r._sideA) && Material.Equals(r.Material) && Color.Equals(r.Color);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hesh code.</returns>
        public override int GetHashCode()
        {
            return _sideA.GetHashCode() + Material.GetHashCode() + Color.GetHashCode();
        }

        /// <summary>
        /// Represents class members in string format.
        /// </summary>
        /// <returns>Returns class members in string format.</returns>
        public override string ToString()
        {
            return string.Format("{0};{1};{2}", base.ToString(), Material, SideA);
        }
    }
}
