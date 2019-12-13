using InheritanceInterfacesAbstractAndClasses.Enum;
using System;

namespace InheritanceInterfacesAbstractAndClasses
{
    public class Sheet : IMaterial
    {
        public double Height { get; } = double.PositiveInfinity;
        public double Width { get; } = double.PositiveInfinity;

        public Sheet(Material material)
        {
            Material = material;
        }

        public Material Material { get; set; }
    }
}