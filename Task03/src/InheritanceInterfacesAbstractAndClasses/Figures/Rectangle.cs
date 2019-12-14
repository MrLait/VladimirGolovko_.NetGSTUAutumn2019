using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.UserExceptions;
using System;

namespace InheritanceInterfacesAbstractAndClasses.Figures
{
    public class Rectangle : Square
    {
        private double _sideB;

        public Rectangle(double sideA, double sideB, Material material) : base(sideA, material)
        {
            SideB = sideB;
        }

        public Rectangle(Figure figure, double sideA, double sideB) : base(figure, sideA)
        {
            SideB = sideB;

            if (figure.GetAreaFigure() < this.GetAreaFigure())
            {
                throw new CutException("The cut figure cannot be larger than the source figure.");
            }
        }

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

        public override Material Material => base.Material;
        public override Color Color => base.Color;

        public override double GetAreaFigure()
        {
            return SideA*SideB;
        }

        public override double GetPerimeter()
        {
            return 2*(SideA+SideB);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Rectangle r = (Rectangle)obj;
            return _sideB.Equals(r._sideB) && base.Equals((Square)obj);
        }

        public override int GetHashCode()
        {
            return _sideB.GetHashCode() + base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0};{1}", base.ToString(), SideB);
        }



    }
}
