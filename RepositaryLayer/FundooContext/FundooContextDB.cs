using Microsoft.EntityFrameworkCore;
using Repositary_Layer.Entities;
using RepositaryLayer.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositary_Layer.FundooContext
{
    public class FundooContextDB : DbContext
    {
        public FundooContextDB(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Label> Label { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        }

    }
}
