using System;
namespace aspdota.Exceptions
{
    public class CannotDeserializeException : Exception
    {
        
        public CannotDeserializeException(string message): base(message)
        {
        }
        public CannotDeserializeException(string message, Exception inner) : base(message, inner){}
    }
}
