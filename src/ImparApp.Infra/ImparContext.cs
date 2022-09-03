﻿using System.Reflection;
using ImparApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ImparApp.Infra
{
    public class ImparContext : DbContext
    {
        public ImparContext(DbContextOptions options)
            : base(options) { 
        }

        public DbSet<Card> Cards { get; set; } = null!;

        public DbSet<Photo> Photos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureDeleteBehavior(modelBuilder);

            // TODO fix: causing exception
            //modelBuilder.SeedDatabase();


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ImparContext))!);
        }

        private void ConfigureDeleteBehavior(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
