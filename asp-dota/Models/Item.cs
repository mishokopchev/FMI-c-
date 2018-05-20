using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using aspdota.Models;

namespace aspdota.Models
{
    [XmlRoot("item")]
    [XmlType("item")]
    public class Item
    {
        
        [XmlAttributeAttribute(AttributeName = "id")]
        public int ID { get; set; }
        [XmlAttributeAttribute(AttributeName = "slot")]
        public int Slot { get; set; }
        [XmlIgnore]
        public Hero Hero { get; set; }

        public string HeroName { get { return Hero.ID; } set { _heroName = value; } }
        [XmlAttributeAttribute(AttributeName = "hero")]
        [NotMapped]
        public string _heroName { get; set; }
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
