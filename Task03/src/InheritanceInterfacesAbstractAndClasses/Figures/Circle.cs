using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.UserExceptions;
using System;

namespace InheritanceInterfacesAbstractAndClasses.Figures
{
    public class Circle : Figure
    {
        private double _radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public Circle(double radius, Material material)
        {
            Radius = radius;
            Material = material;
        }

        public Circle(Figure figure, double radius) : this(radius)
        {
            if (figure.GetAreaFigure() < this.GetAreaFigure())
            {
                throw new CutException("The cut figure cannot be larger than the source figure.");
            }
            Material = figure.Material;
        }

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

        public override Material Material { get;}

        public override Color Color => base.Color;

        public override double GetAreaFigure()
        {
            return Math.PI * _radius * _radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * _radius;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Circle r = (Circle)obj;
            return _radius.Equals(r._radius) && Material.Equals(r.Material) && Color.Equals(r.Color);
        }

        public override int GetHashCode()
        {
            return _radius.GetHashCode() + Material.GetHashCode() + Color.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0};{1};{2}", base.ToString(), Material, Radius);
        }
    }
}
