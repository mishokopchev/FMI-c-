using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace aspdota.Models
{
    public class BuildingEntity
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuildingId { get; set; }
        public Side Side { get; set; } //sentinel|scorge
        public string Main { get; set; }
        public string Region { get; set; }
        public string Type { get; set; }
        public int Life { get; set; }
        public int Defence { get; set; }
        public int Damage { get; set; }

        public BuildingEntity()
        {
            
        }
        
    }
    public enum Side
    {
        sentinel, scorge
    }
}
