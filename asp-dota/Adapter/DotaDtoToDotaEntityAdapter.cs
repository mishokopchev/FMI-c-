using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using aspdota.Models;
using aspdota.XmlDto;

namespace aspdota.Adapter
{
    public class DotaDtoToDotaEntityAdapter : Adapter<DotaEntity, Dota>
    {
        public DotaEntity Adapt(Dota obj)
        {
            var dotaEntity = new DotaEntity();

            if(obj.Game != null){
                
                aspdota.Models.GameEntity game = new GameEntity
                {
                    Designer = obj.Game.Designer,
                    Name = obj.Game.Name,
                    Genre = obj.Game.Genre          
                };

                dotaEntity.Game = game;
            }

            dotaEntity.Buildings = new List<BuildingEntity>();
            if(obj.Buildings != null && obj.Buildings.Capacity > 0 ){

                foreach( Building building in obj.Buildings){
                    BuildingEntity buildingEntity = new BuildingEntity();

                    buildingEntity.Damage = building.Damage;
                    buildingEntity.Defence = building.Defence;
                    buildingEntity.Life = building.Life;
                    buildingEntity.Main = building.Main;
                    buildingEntity.Region = building.Region;
                    buildingEntity.Side = buildingEntity.Side;
                    buildingEntity.Type = building.Type;

                    dotaEntity.AddBuilding(buildingEntity);

                }

            }

            dotaEntity.Heroes = new List<HeroEntity> ();

            if(obj.Heroes != null && obj.Heroes.Capacity > 0){
                obj.Heroes.ForEach((Hero heroDTO)=> {
                    HeroEntity heroEntity = ConvertHero(heroDTO);
                    dotaEntity.AddHero(heroEntity);
                });
            }

            dotaEntity.Items = new List<ItemEntity>();
            if(obj.Items != null && obj.Items.Capacity > 0){
                obj.Items.ForEach((itemDTO) => {
                    ItemEntity itemEntity = new ItemEntity
                    {
                        Merchant = itemDTO.Merchant,
                        Price = itemDTO.Price,
                        Need = itemDTO.Need,
                        Description = itemDTO.Description,
                    };

                    string heroId = itemDTO.HeroName;
                    Hero heroDTO = obj.Heroes.Find((Hero searchd) => searchd.ID == heroId);

                    HeroEntity heroEntity = ConvertHero(heroDTO);
                    itemEntity.Hero = heroEntity;
                    dotaEntity.AddItem(itemEntity);

                    itemEntity.Effects = new List<EffectEntity>();
                    itemDTO.Effects.ForEach((Effect eff)=>{
                        EffectEntity effEntity = new EffectEntity
                        {
                            Main = eff.Main,
                            Secondary = eff.Secondary
                        };

                        itemEntity.AddEffect(effEntity);
                    });

                });
            }
            return dotaEntity;

        }
        private SkillEntity ConvertSkill(Skill skill){
            SkillEntity entity = new SkillEntity();
            entity.SkillTypes = new List<SkillTypeEntity>();
            Type type = skill.GetType();
            foreach(var f in type.GetFields().Where(f => f.IsPublic)){
                SkillTypeEntity skillType = new SkillTypeEntity();
                skillType.SkillName = (string)f.GetValue(skill);
                entity.AddSkill(skillType);
            }
            return entity;
        }
        private HeroEntity ConvertHero(Hero heroDTO){
            
            HeroEntity heroEntity = new HeroEntity();
            heroEntity.Affiliation = heroDTO.Affiliation;
            heroEntity.Armor = heroDTO.Armor;
            heroEntity.Atribute = heroDTO.Short.Description;
            heroEntity.AtributeType = heroDTO.Short.Short;
            heroEntity.Attack = heroDTO.Attack;
            heroEntity.DPS = heroDTO.DPS;
            heroEntity.Movespeed = heroDTO.Movespeed;
            heroEntity.ID = heroDTO.ID;
            heroEntity.Status = heroDTO.Status;
            heroEntity.Title = heroDTO.Title;

            heroEntity.Skills = new List<SkillEntity>();
            heroDTO.Skills.ForEach(skill => {
                heroEntity.Skills.Add(ConvertSkill(skill));
            });

            return heroEntity;

        }



    }
}
