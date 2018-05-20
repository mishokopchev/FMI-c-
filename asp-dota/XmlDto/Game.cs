using System;
using System.Xml.Serialization;

namespace aspdota.XmlDto
{   
    [XmlRoot(ElementName = "game")]
    [XmlType("game")]
    public class Game
    {
        [XmlElement(ElementName = "name")]  
        public string Name { get; set; }
        [XmlElement(ElementName = "genre")]  
        public string Genre { get; set; }
        [XmlElement(ElementName = "designer")]  
        public string Designer { get; set; }

        public Game()
        {
        }
    }
}
