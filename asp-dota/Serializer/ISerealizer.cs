using System;
using System.IO;

namespace aspdota.Serializer
{
    public interface ISerealizer<T> : IWriter<T>, IReader<T>
    {
       
    }
}
