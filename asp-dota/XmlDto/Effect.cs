using System;
using System.Xml.Serialization;

namespace aspdota.XmlDto
{   [XmlRoot(ElementName = "effect")]
    [XmlType("effect")]
    public class Effect
    {
        [XmlElement(ElementName = "main")]
        public string Main { get; set; }
        [XmlElement(ElementName = "secondary")]
        public string Secondary { get; set; }

    }
}
