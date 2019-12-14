using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.UserExceptions;
using System;

namespace InheritanceInterfacesAbstractAndClasses.Figures
{
    public class Square : Figure
    {
        private double _sideA;

        private Square(double sideA)
        {
            SideA = sideA;
        }

        public Square(double sideA, Material material)
        {
            Material = material;
            SideA = sideA;
        }

        public Square(Figure figure, double sideA) : this(sideA)
        {
            if (figure.GetAreaFigure() < this.GetAreaFigure())
            {
                throw new CutException("The cut figure cannot be larger than the source figure.");
            }
            Material = figure.Material;
        }

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

        public override Material Material { get; }

        public override Color Color => base.Color;

        public override double GetAreaFigure()
        {
            return SideA * SideA;
        }

        public override double GetPerimeter()
        {
            return 4 * SideA;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Square r = (Square)obj;
            return _sideA.Equals(r._sideA) && Material.Equals(r.Material) && Color.Equals(r.Color);
        }

        public override int GetHashCode()
        {
            return _sideA.GetHashCode() + Material.GetHashCode() + Color.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0};{1};{2}", base.ToString(), Material, SideA);
        }
    }
}
