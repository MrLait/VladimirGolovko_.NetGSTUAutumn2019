using System;

namespace InheritanceInterfacesAbstractAndClasses.UserExceptions
{
    /// <summary>
    /// Type which contain user CutException
    /// </summary>
    public class CutException : Exception
    {
        /// <summary>
        /// <see cref=" CutException"/> constructor.
        /// </summary>
        /// <param name="message">CutException message.</param>
        public CutException(string message) : base(message) {}
    }
}
