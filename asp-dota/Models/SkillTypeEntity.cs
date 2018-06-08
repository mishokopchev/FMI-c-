using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspdota.Models
{
    public class SkillTypeEntity

    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public String SkillDescription { get; set; }

        public SkillTypeEntity()
        {
        }
    }
}
