using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace aspdota.Models
{
    [XmlRoot(ElementName = "attribute")]
    public class AttributeHero
    {
        [XmlIgnore]
        public int ID { get; set; }
        [XmlAttributeAttribute(AttributeName = "short")]
        public Short Short { get; set; } // AGI|INT|STR
    }
    public enum Short
    {
        AGI, INT, STR
    }
}
