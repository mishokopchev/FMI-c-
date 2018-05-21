using System;
using System.Collections.Generic;

namespace aspdota.Models
{
    public class DotaEntity
    {
        public GameEntity Game { get; set; }
        public List<BuildingEntity> Buildings { get; set; }
        public List<HeroEntity> Heroes { get; set; }
        public List<ItemEntity> Items { get; set; }


        public DotaEntity()
        {
        }
        public DotaEntity(string name){
            
        }
    }
}
