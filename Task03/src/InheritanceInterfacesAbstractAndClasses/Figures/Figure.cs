using InheritanceInterfacesAbstractAndClasses.Enum;

namespace InheritanceInterfacesAbstractAndClasses.Figures
{
    /// <summary>
    /// 
    /// </summary>
    abstract public class Figure: IMaterial
    {
        public abstract Material Material { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        abstract public double GetAreaFigure();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        abstract public double GetPerimeterFigure();

    }
}
