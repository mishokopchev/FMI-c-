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

        public void AddItem(ItemEntity item){
            if(item != null){
                Items.Add(item);
            }
        }

        public void AddHero(HeroEntity entity)
        {
            if (entity != null)
            {
                Heroes.Add(entity);
            }
        }

        public void AddBuilding(BuildingEntity entity)
        {
            if (entity != null)
            {
                Buildings.Add(entity);
            }
        }






        public DotaEntity()
        {
        }
        public DotaEntity(string name){
            
        }
    }
}
