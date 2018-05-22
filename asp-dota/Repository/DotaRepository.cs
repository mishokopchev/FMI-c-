using System;
using System.Collections.Generic;
using aspdota.Data;
using aspdota.Models;


namespace aspdota.Repository
{
    public class DotaRepository :IDotaRepository
    {
        private DotaContext _dbContext;


        public DotaRepository(DotaContext context)
        {
            this._dbContext = context;
        }

        public void Persist(DotaEntity dotaEntity)
        {
            string errMessage;
            if(dotaEntity != null)
            {
                try
                {
                    GameEntity gameEntity = dotaEntity.Game;
                    this.Add<GameEntity>(gameEntity);
                }
                catch (Exception e)
                {
                    errMessage = "Could not persist GameEntity";
                    Console.WriteLine(errMessage);
                    throw e;   
                }
                try
                {
                    List<HeroEntity> heroes = dotaEntity.Heroes;
                    heroes.ForEach((HeroEntity HeroEntity)=>{
                        Add<HeroEntity>(HeroEntity);
                    });

                }
                catch (Exception e)
                {
                    errMessage = "Could not persist Hero:";
                    Console.WriteLine(errMessage);
                    throw e;
                }


                try
                {
                    List<ItemEntity> items = dotaEntity.Items;
                    items.ForEach((ItemEntity itemEntity) => {
                        Add<ItemEntity>(itemEntity);
                    });

                }
                catch (Exception e)
                {
                    errMessage = "Could not persist Items:";
                    Console.WriteLine(errMessage);
                    throw e;
                }

                try
                {
                    List<BuildingEntity> items = dotaEntity.Buildings;
                    items.ForEach((BuildingEntity buildingEntity) => {
                        Add<BuildingEntity>(buildingEntity);
                    });

                }
                catch (Exception e)
                {
                    errMessage = "Could not persist Building:";
                    Console.WriteLine(errMessage);
                    throw e;
                }


            }

        }

        public void Add<T>(T newItem) where T : class
        {
            _dbContext.Set<T>().Add(newItem);
        }
    }
}
