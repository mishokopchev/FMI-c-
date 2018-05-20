using System;
using System.ComponentModel.DataAnnotations;

namespace aspdota.Models
{
    public class SkillType

    {   
        [Key]
        public String SkillName { get; set; }
        public String SkillDescription { get; set; }

        public SkillType()
        {
        }
    }
}
