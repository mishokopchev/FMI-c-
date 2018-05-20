using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace aspdota.Models
{
    [XmlRoot(ElementName =  "dota", Namespace = "")]
    public class Dota
    {
        
        [XmlElement(ElementName = "game")]
        public Game Game { get; set; }
        [XmlArray(ElementName = "buildings")]
        public List<Building> Buildings { get; set; }
        [XmlArray(ElementName = "heroes")]
        public List<Hero> Heroes { get; set; }
        [XmlArray(ElementName = "items")]
        public List<Item> Items { get; set; }

        public Dota()
        {

        }
    }
}
