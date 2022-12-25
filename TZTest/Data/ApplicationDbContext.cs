using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using TZTest.Models;

namespace TZTest.Data
{
	public class ApplicationDbContext:DbContext
	{
        public DbSet<FolderClass> Folders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
           
        }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FolderConfiguration());

        }
    }
}

