using System;
using aspdota.Models;
using Microsoft.EntityFrameworkCore;

namespace aspdota.Data
{
    public class DotaContext : DbContext
    {
        public DbSet<Game> Game;
        public DbSet<Hero> Hero;
        public DbSet<Item> Item;
        public DbSet<Skill> Skill;
        public DbSet<Effect> Effect;
        public DbSet<AttributeHero> AttributeHero;

        public DotaContext(DbContextOptions<DotaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>().ToTable("Hero");
            modelBuilder.Entity<Skill>().ToTable("Skill");
            modelBuilder.Entity<AttributeHero>().ToTable("AttributeHero");
            modelBuilder.Entity<Item>();
            modelBuilder.Entity<Effect>().ToTable("Effect");

   

        }

    }
}
