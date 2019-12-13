using InheritanceInterfacesAbstractAndClasses.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInterfacesAbstractAndClasses
{
    public class Girl
    {
        private Sheet filmSheet = new Sheet(Enum.Material.Film);
        private Sheet paperSheet = new Sheet(Enum.Material.Paper);

        private SetOfPaints setOfPaints = new SetOfPaints();
        private BoxForFigures boxForFigures = new BoxForFigures();

        public Figure PaperCut(Figure figureOne, Figure figureTwo )
        {

            return null;
        }

    }
}
