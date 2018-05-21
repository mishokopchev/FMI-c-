using System;
using System.ComponentModel.DataAnnotations;

namespace aspdota.Models
{
    public class SkillTypeEntity

    {   
        [Key]
        public String SkillName { get; set; }
        public String SkillDescription { get; set; }

        public SkillTypeEntity()
        {
        }
    }
}
