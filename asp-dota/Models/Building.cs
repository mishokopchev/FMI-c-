using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace aspdota.Models
{
    [XmlRoot("building")]
    [XmlType("building")]
    public class Building
    {   
        [Key]
        [XmlIgnore]
        public int BuildingId { get; set; }
        [XmlAttributeAttribute(AttributeName = "side")]
        public Side Side { get; set; } //sentinel|scorge
        [XmlAttributeAttribute(AttributeName = "main")]
        public string Main { get; set; }
        [XmlElement(ElementName = "region")]
        public string Region { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "life")]
        public int Life { get; set; }
        [XmlElement(ElementName = "defence")]
        public int Defence { get; set; }
        [XmlElement(ElementName = "damage")]
        public int Damage { get; set; }



        public Building()
        {
            
        }
        
    }
    public enum Side
    {
        sentinel, scorge
    }
}
