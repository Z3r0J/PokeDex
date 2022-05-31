using Microsoft.EntityFrameworkCore;
using Pokedex.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){}

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Models.Type> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //Fluent API

            #region Tables

            modelBuilder.Entity<Pokemon>().ToTable("Products");
            modelBuilder.Entity<Region>().ToTable("Regions");
            modelBuilder.Entity<Models.Type>().ToTable("Types");

            #endregion

            #region Primary Key

            modelBuilder.Entity<Pokemon>().HasKey(pokemon=>pokemon.Id);
            modelBuilder.Entity<Region>().HasKey(region=>region.Id);
            modelBuilder.Entity<Models.Type>().HasKey(type=>type.Id);

            #endregion

            #region Foreign Key

            modelBuilder.Entity<Region>()
                .HasMany<Pokemon>(region => region.Pokemons)
                .WithOne(pokemon => pokemon.Region)
                .HasForeignKey(pokemon => pokemon.RegionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.Type>()
                .HasMany<Pokemon>(type => type.PimaryType)
                .WithOne(pokemon => pokemon.PrimaryType)
                .HasForeignKey(pokemon => pokemon.PrimaryTypeId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Models.Type>()
                .HasMany<Pokemon>(type => type.SecondaryType)
                .WithOne(pokemon => pokemon.SecondaryType)
                .HasForeignKey(pokemon => pokemon.SecondaryTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Properties Configuration

            #region Pokemon

            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.Name)
                .IsRequired();

            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.RegionId)
                .IsRequired();

            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.PhotoUrl)
                .IsRequired();

            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.Color)
                .IsRequired();

            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.PrimaryTypeId)
                .IsRequired();

            #endregion
            
            #region Region

            modelBuilder.Entity<Region>()
                .Property(region => region.Name)
                .IsRequired()
                .HasMaxLength(100);

            #endregion 
            
            #region Type

            modelBuilder.Entity<Models.Type>()
                .Property(type => type.Name)
                .IsRequired()
                .HasMaxLength(100);

            #endregion

            #endregion

        }


    }
}
