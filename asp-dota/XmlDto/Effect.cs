using System;
using System.Xml.Serialization;

namespace aspdota.Models
{   [XmlRoot(ElementName = "effect")]
    [XmlType("effect")]
    public class Effect
    {
        [XmlIgnore]
        public int EffectId { get; set; }
        [XmlElement(ElementName = "main")]
        public string Main { get; set; }
        [XmlElement(ElementName = "secondary")]
        public string Secondary { get; set; }

    }
}
