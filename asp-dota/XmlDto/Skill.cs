using System;
using System.Xml.Serialization;

namespace aspdota.XmlDto
{
    [XmlRoot(ElementName = "skill")]
    [XmlType("skill")]
    public class Skill
    {
        [XmlElement(ElementName = "num1")]
        public string Num1 { get; set; }
        [XmlElement(ElementName = "num2")]
        public string Num2 { get; set; }
        [XmlElement(ElementName = "num3")]
        public string Num3 { get; set; }
        [XmlElement(ElementName = "num4")]
        public string Num4 { get; set; }

        public Skill()
        {
        }
    }
}
