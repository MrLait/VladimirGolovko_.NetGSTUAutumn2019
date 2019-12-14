using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.Figures;
using System;

namespace InheritanceInterfacesAbstractAndClasses
{
    public class Sheet : Figure, IMaterial
    {
        public double Height { get; } = double.PositiveInfinity;
        public double Width { get; } = double.PositiveInfinity;

        public Sheet(Material material)
        {
            Material = material;
        }

        public override Material Material { get; }

        public override double GetAreaFigure()
        {
            return Height * Width;
        }

        public override double GetPerimeter()
        {
            return (Height + Width) * 2;
        }
    }
}