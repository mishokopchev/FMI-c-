using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using aspdota.Models;

namespace aspdota.XmlDto
{
    [XmlRoot("item")]
    [XmlType("item")]
    public class Item
    {
        
        [XmlAttributeAttribute(AttributeName = "slot")]
        public int Slot { get; set; }
        [XmlAttributeAttribute(AttributeName = "hero")]
        public string HeroName { get; set; }
        [XmlElement(ElementName = "merchant")]  
        public string Merchant { get; set; }
        [XmlElement(ElementName = "price")]  
        public int Price { get; set; }
        [XmlArray(ElementName = "effects")]
        public List<Effect> Effects { get; set; }
        [XmlElement(ElementName = "need")]  
        public string Need { get; set; }
        [XmlElement(ElementName = "description")]  
        public string Description { get; set; }

        public Item()
        {
        }
    }
  
}
