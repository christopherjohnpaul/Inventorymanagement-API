using System;

namespace ModelLayer.CustomExceptions
{
    [Serializable]
    public class CustomExceptions : Exception
    {
        public CustomExceptions()
        { }

        public CustomExceptions(string message)
            : base(message)
        { }

        public CustomExceptions(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
