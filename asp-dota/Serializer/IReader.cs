using System;
using System.IO;

namespace aspdota.Serializer
{
    public interface IReader<T>
    {
        T Deserialize(string file);

        T Deserialize(TextReader reader);

        bool Validate(String file);
    }
}
