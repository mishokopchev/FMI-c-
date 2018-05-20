using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace aspdota.XmlDto
{
    [XmlRoot(ElementName =  "dota", Namespace = "")]
    public class Dota
    {

        [XmlElement(ElementName = "game")]
        public Game Game { get; set; } = new Game();
        [XmlArray(ElementName = "buildings")]
        public List<Building> Buildings { get; set; } = new List<Building>();
        [XmlArray(ElementName = "heroes")]
        public List<Hero> Heroes { get; set; } = new List<Hero>();
        [XmlArray(ElementName = "items")] 
        public List<Item> Items { get; set; } = new List<Item>();

        public Dota()
        {

        }
    }
}
