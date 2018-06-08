using System;
using System.IO;

namespace aspdota.Serializer
{
    public interface IWriter<T>
    {
        void Serialize(T obj, string where);

        void Serialize(T obl, TextWriter writer);
    }
}
