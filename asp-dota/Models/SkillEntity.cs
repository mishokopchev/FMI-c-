using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace aspdota.Models
{
    public class SkillEntity{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillID { get; set; }
        public List<SkillTypeEntity> SkillTypes { get; set; } 

        public void AddSkill(SkillTypeEntity skillTypenEntity){
            _ensureCreated();
            this.SkillTypes.Add(skillTypenEntity);
        }

        private void _ensureCreated(){
            if(SkillTypes == null){
                SkillTypes = new List<SkillTypeEntity>();
            }
        }

        public SkillEntity(){}
    }
}


