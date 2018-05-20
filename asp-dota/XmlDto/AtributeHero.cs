using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace aspdota.XmlDto
{
    [XmlRoot(ElementName = "attribute")]
    public class AttributeHero
    {
        
        [XmlAttributeAttribute(AttributeName = "short")]
        public Short Short { get; set; } // AGI|INT|STR
    }
    public enum Short
    {
        AGI, INT, STR
    }
}
