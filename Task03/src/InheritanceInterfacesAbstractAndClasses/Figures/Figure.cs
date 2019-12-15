using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.UserExceptions;

namespace InheritanceInterfacesAbstractAndClasses.Figures
{
    /// <summary>
    /// Abstract Type Figure.
    /// </summary>
    abstract public class Figure : IMaterial
    {
        private bool _painted = false;
        private Colors _color;

        /// <summary>
        /// Figure material.
        /// </summary>
        public abstract Material Material { get; }

        /// <summary>
        /// Figure color.
        /// </summary>
        public virtual Colors Color
        {
            get { return _color; }
            set
            {
                if (PaintCheck())
                {
                    _color = value;
                }
            }
        }

        /// <summary>
        /// Abstract method for calculate the area.
        /// </summary>
        /// <returns>The total area.</returns>
        abstract public double GetAreaFigure();

        /// <summary>
        /// Abstract method for calculate the perimeter.
        /// </summary>
        /// <returns>The total perimeter.</returns>
        abstract public double GetPerimeter();

        /// <summary>
        /// Method for checking the possibility to color figures.
        /// </summary>
        /// <returns>Return bool or ColorException.</returns>
        protected internal bool PaintCheck()
        {
            if (Material == Material.Film)
                throw new ColorException("The film figure can't be painted.");

            if (!_painted && Material == Material.Paper)
            {
                _painted = true;
                return _painted;
            }

            throw new ColorException("The figure can no longer be painted.");
        }

        /// <summary>
        /// Represents class members in string format.
        /// </summary>
        /// <returns>Returns class members in string format.</returns>
        public override string ToString()
        {
            return string.Format("{0}", GetType().Name);
        }
    }
}
