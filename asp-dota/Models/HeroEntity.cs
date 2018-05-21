using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using aspdota.Commons;

namespace aspdota.Models
{
    
    public class HeroEntity
    {
        [Key]
        [Column("id")]
        public String Name { get;  set; }
        public Attack Attack { get; set; } // range/melee
        public Affiliation Affiliation { get; set; } // sentinel|scorge
        public String Title { get; set; }
        public string Atribute { get; set; }
        public Short AtributeType { get; set; }
        public String Status { get; set; }
        public int Movespeed { get; set; }
        public List<SkillEntity> Skills { get; set; }
        public String Armor { get; set; }
        public int DPS { get; set; }

        public HeroEntity()
        {
        }
    }


}
