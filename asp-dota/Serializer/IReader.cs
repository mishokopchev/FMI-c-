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

        void ValidateContent(String input);

        bool ValidateInput(String file);



    }
}
