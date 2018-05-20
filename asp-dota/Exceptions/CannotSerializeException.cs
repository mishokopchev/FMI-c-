using System;
namespace aspdota.Exceptions
{
    public class CannotSerializeException : Exception
    {
        public CannotSerializeException(string message) : base(message)
        {
        }
        public CannotSerializeException(string message,Exception innter) : base(message,innter){}
    }
}
