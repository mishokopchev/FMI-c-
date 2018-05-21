using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using aspdota.Commons;

namespace aspdota.XmlDto
{
    [XmlRoot(ElementName = "attribute")]
    public class AttributeHero
    {
        
        [XmlAttributeAttribute(AttributeName = "short")]
        public Short Short { get; set; } // AGI|INT|STR
        public String Description { get; set; }
    }

}
