using System;
using System.Configuration;
using aspdota.Models;
using Microsoft.EntityFrameworkCore;

namespace aspdota.Data
{
    public class DotaContext : DbContext
    {
        private static string DB = @"Server=localhost;database=asp;uid=root;pwd=rootroot;";

        public DbSet<HeroEntity> Hero { get; set; }
        public DbSet<ItemEntity> Item{ get; set; }
        public DbSet<SkillEntity> Skill{ get; set; }
        public DbSet<EffectEntity> Effect{ get; set; }
        public DbSet<SkillTypeEntity> SkillType{ get; set; }
        public DbSet<GameEntity> Game{ get; set; }

        public DotaContext(DbContextOptions<DotaContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseMySQL(DB);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroEntity>().ToTable("HERO");
            modelBuilder.Entity<EffectEntity>().ToTable("EFFECT");
            modelBuilder.Entity<BuildingEntity>().ToTable("BUILDING");
            modelBuilder.Entity<SkillEntity>().ToTable("SKILL;");
            modelBuilder.Entity<ItemEntity>().ToTable("ITEM");
            modelBuilder.Entity<GameEntity>().ToTable("GAME");

        }

    }
}
