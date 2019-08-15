using System;

namespace FS3X.Lib
{
    public class PedalException : Exception
    {
        public PedalException()
        {
        }

        public PedalException(string message)
            : base(message)
        {
        }

        public PedalException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
