using InheritanceInterfacesAbstractAndClasses.Enum;
using InheritanceInterfacesAbstractAndClasses.UserExceptions;

namespace InheritanceInterfacesAbstractAndClasses.Figures
{
    abstract public class Figure : IMaterial
    {
        private bool _painted = false;
        private Color _color;

        public abstract Material Material { get; }

        public virtual Color Color
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

        abstract public double GetAreaFigure();

        abstract public double GetPerimeter();

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

        public override string ToString()
        {
            return string.Format("{0}", GetType().Name);
        }
    }
}
