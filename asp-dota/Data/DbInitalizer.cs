using System;
using System.Collections.Generic;
using aspdota.Models;
using Microsoft.EntityFrameworkCore;

namespace aspdota.Data
{
    public class DbInitializer
    {
        private DbContext DbContext { get; set; }

        public DbInitializer(DotaContext context)
        {
            this.DbContext = context;
        }

        public void Initialize()
        {
            
            try
            {
                this.DbContext.Database.EnsureCreated();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        /*
        public Building CreateBulding()
        {
            Building building = new Building
            {
                Side = Side.scorge,
                Main = "main",
                Region = "region",
                Type = "type",
                Life = 100,
                Defence = 123,
                Damage = 100

            };
            return building;
        }

        public Item CreateItem(List<Effect> effects, Hero hero)
        {
            Item item = new Item
            {
                Slot = 1,
                Merchant = "merchant",
                Price = 12,
                Need = "tes",
                Description = "description",
                Hero = hero,
                Effects = effects

            };
            return item;
        }
        public Hero CreateHero(Skill skill)
        {
            try
            {
                AttributeHero attr = new AttributeHero();
                attr.Short = Short.AGI;
                Hero hero = new Hero();
                hero.ID = "EarthDick";
                hero.Movespeed = 2;
                hero.Skills = new List<Skill>();
                hero.Skills.Add(skill);
                hero.Affiliation = Affiliation.scorge;
                hero.Attack = Attack.melee;
                hero.Title = "wqq";
                hero.Status = "21";
                hero.DPS = 12;
                hero.Armor = "wqwq";
                hero.Short = attr;

                return hero;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }

        }
        */
    }
}
