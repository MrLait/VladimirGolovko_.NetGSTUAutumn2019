using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.UserExceptions;
using System;

namespace InheritanceInterfacesAbstractAndClasses.Figures
{
    /// <summary>
    /// A circle class that describes a circle figure.
    /// </summary>
    public class Circle : Figure
    {
        private double _radius;

        private Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Type constructor for class <see cref="Circle"/>
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="material">Circle material</param>
        public Circle(double radius, Material material)
        {
            Radius = radius;
            Material = material;
        }

        /// <summary>
        /// Type construcr for to cut one figure from another.
        /// The area of ​​the figure should be larger than the area of ​​the figure that is cut out of it.
        /// </summary>
        /// <param name="figure">Source figure.</param>
        /// <param name="radius">The radius of the figure you want to get.</param>
        public Circle(Figure figure, double radius) : this(radius)
        {
            if (figure.GetAreaFigure() < this.GetAreaFigure())
            {
                throw new CutException("The cut figure cannot be larger than the source figure.");
            }
            Material = figure.Material;
        }

        /// <summary>
        /// Radius of the circle.
        /// The radius of the figure cannot be negative or equal to zero.
        /// </summary>
        public double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The radius of the figure cannot be negative or equal to zero.");
                }

                _radius = value;
            }
        }

        /// <summary>
        /// Circle material.
        /// </summary>
        public override Material Material { get;}

        /// <summary>
        /// Circle color.
        /// </summary>
        public override Colors Color => base.Color;

        /// <summary>
        /// Calculate circle area.
        /// </summary>
        /// <returns>The total area.</returns>
        public override double GetAreaFigure()
        {
            return Math.PI * _radius * _radius;
        }

        /// <summary>
        /// Calculate cirle perimeter.
        /// </summary>
        /// <returns>The total perimeter.</returns>
        public override double GetPerimeter()
        {
            return 2 * Math.PI * _radius;
        }

        /// <summary>
        /// Comparing one circle wit another.
        /// </summary>
        /// <param name="obj">The compared circle.</param>
        /// <returns>True if equal. False if not eqal.</returns>
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Circle r = (Circle)obj;
            return _radius.Equals(r._radius) && Material.Equals(r.Material) && Color.Equals(r.Color);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hesh code.</returns>
        public override int GetHashCode()
        {
            return _radius.GetHashCode() + Material.GetHashCode() + Color.GetHashCode();
        }

        /// <summary>
        /// Represents class members in string format.
        /// </summary>
        /// <returns>Returns class members in string format.</returns>
        public override string ToString()
        {
            return string.Format("{0};{1};{2}", base.ToString(), Material, Radius);
        }
    }
}
