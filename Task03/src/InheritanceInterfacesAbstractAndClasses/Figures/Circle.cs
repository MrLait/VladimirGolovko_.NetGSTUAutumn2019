using InheritanceInterfacesAbstractAndClasses.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInterfacesAbstractAndClasses.Figures
{
    public class Circle : Figure
    {
        private double _radius;

        public Circle(double radius, Material material)
        {
            Radius = radius;
            Material = material;
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
                else
                {
                    _radius = value;
                }
            }
        }

        public override Material Material { get;}

        public override double GetAreaFigure()
        {
            return Math.PI * _radius * _radius;
        }

        public override double GetPerimeterFigure()
        {
            return 2 * Math.PI * _radius;
        }

        public override bool Equals(Object obj)
        {
            // Perform an equality check on two rectangles (Point object pairs).
            if (obj == null || GetType() != obj.GetType())
                return false;
            Circle r = (Circle)obj;
            return _radius.Equals(r._radius);
        }

        public override int GetHashCode()
        {
            return _radius.GetHashCode();
        }

    }
}
