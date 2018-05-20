using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace aspdota.Models
{
    public class Skill{

        [Key]
        public int SkillID { get; set; }
        public List<SkillType> SkillTypes { get; set; } 


        public Skill(){}
    }
}


