using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.Figures;
using System;

namespace InheritanceInterfacesAbstractAndClasses
{
    /// <summary>
    /// A sheet class that describes a sheet figure.
    /// </summary>
    public class Sheet : Figure, IMaterial
    {
        /// <summary>
        /// The height of the sheet.
        /// </summary>
        public double Height { get; } = double.PositiveInfinity;

        /// <summary>
        /// The width of the sheet.
        /// </summary>
        public double Width { get; } = double.PositiveInfinity;

        /// <summary>
        /// Constructor for the Type <see cref="Sheet"/>
        /// </summary>
        /// <param name="material">Sheet material.</param>
        public Sheet(Material material)
        {
            Material = material;
        }

        /// <summary>
        /// Sheet material.
        /// </summary>
        public override Material Material { get; }

        /// <summary>
        /// Calculate sheet area.
        /// </summary>
        /// <returns>The total area.</returns>
        public override double GetAreaFigure()
        {
            return Height * Width;
        }

        /// <summary>
        /// Calculate sheet perimeter.
        /// </summary>
        /// <returns>The total perimeter.</returns>
        public override double GetPerimeter()
        {
            return (Height + Width) * 2;
        }
    }
}