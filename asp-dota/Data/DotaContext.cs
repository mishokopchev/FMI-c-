using System;
using System.Configuration;
using aspdota.Models;
using Microsoft.EntityFrameworkCore;

namespace aspdota.Data
{
    public class DotaContext : DbContext
    {
        private static string DB = @"Server=localhost;database=asp;uid=root;pwd=rootroot;";

        public DbSet<Hero> Hero { get; set; }
        public DbSet<Item> Item{ get; set; }
        public DbSet<Skill> Skill{ get; set; }
        public DbSet<Effect> Effect{ get; set; }
        public DbSet<SkillType> SkillType{ get; set; }
        public DbSet<Game> Game{ get; set; }

        public DotaContext(DbContextOptions<DotaContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseMySQL(DB);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>().ToTable("hero".ToUpper());
            modelBuilder.Entity<Effect>().ToTable("effect".ToUpper());
            modelBuilder.Entity<Building>().ToTable("building".ToUpper());
            modelBuilder.Entity<Skill>().ToTable("SKILL");
            modelBuilder.Entity<Item>().ToTable("ITEM");
            modelBuilder.Entity<Game>().ToTable("GAME");

        }

    }
}
