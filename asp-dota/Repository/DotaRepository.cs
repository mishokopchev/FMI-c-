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
                    throw new Exception(e.Message, e.InnerException);
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
                    throw new Exception(e.Message, e.InnerException);
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
                    throw new Exception(e.Message, e.InnerException);
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
                    throw new Exception(e.Message, e.InnerException);
                }

                try{
                  
					_dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    errMessage = "Could not persist The Objects";
                    Console.WriteLine(errMessage);
                    throw new Exception(e.Message,e.InnerException);
                }
            }

        }

        private void Add<T>(T newItem) where T : class => _dbContext.Set<T>().Add(newItem);
    }
}
