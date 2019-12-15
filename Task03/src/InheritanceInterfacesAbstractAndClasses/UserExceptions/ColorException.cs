using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInterfacesAbstractAndClasses.UserExceptions
{
    /// <summary>
    /// Type with user ColorException.
    /// </summary>
    public class ColorException : Exception
    {
        /// <summary>
        /// ColorException constructor.
        /// </summary>
        /// <param name="message">ColorException message.</param>
        public ColorException(string message) : base(message) { }
    }
}
