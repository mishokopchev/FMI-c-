using System;
using System.IO;

namespace aspdota.Serializer
{
    public interface IReader<T>
    {
        T Deserialize(string file);

        T Deserialize(TextReader reader);

        void Serialize(T obj, string where);    

        void Serialize(T obl, TextWriter writer);

        bool ValidateInput(String file);

    }
}
