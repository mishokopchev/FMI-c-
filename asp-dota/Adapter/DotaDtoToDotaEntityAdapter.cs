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

                    dotaEntity.Buildings.Add(buildingEntity);

                }

            }

            dotaEntity.Heroes = new List<HeroEntity> ();

            if(obj.Heroes != null && obj.Heroes.Capacity > 0){
                obj.Heroes.ForEach((Hero heroDTO)=> {
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
                    heroDTO.Skills.ForEach(skill=>{
                        heroEntity.Skills.Add(AdaptSkill(skill));
                    });

                });

            }

            if(obj.Items != null && obj.Items.Capacity > 0){
                //do it for items the same
            }


            return dotaEntity;



        }
        private SkillEntity AdaptSkill(Skill skill){
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
    }
}
