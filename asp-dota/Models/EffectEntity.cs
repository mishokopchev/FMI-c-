using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace aspdota.Models
{   
    
    public class EffectEntity
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EffectId { get; set; }
        public string Main { get; set; }
        public string Secondary { get; set; }

    }
}
