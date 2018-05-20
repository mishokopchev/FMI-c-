using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace aspdota.Serializer
{
    public class Serializer
    {
        public XmlSerializer XmlSerializer;

        public Serializer()
        {
        }

        public void Serialize(Object obj ,StreamWriter stream ){
            this.XmlSerializer.Serialize(stream,obj);
        }

        public object Deserialize(Stream Stream) => this.XmlSerializer.Deserialize(Stream);

    }
}
