using System;

namespace InheritanceInterfacesAbstractAndClasses.UserExceptions
{
    public class CutException : Exception
    {
        public CutException(string message) : base(message) {}
    }
}
