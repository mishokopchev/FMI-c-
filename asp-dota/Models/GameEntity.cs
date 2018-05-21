using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace aspdota.Models
{   
    
    public class GameEntity
    {
        [Key]
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Designer { get; set; }

        public GameEntity()
        {
        }
    }
}
