﻿using Microsoft.EntityFrameworkCore;
using backend.Model;

// db context is single threaded 
namespace backend.Data
{
    public class AppDbContext : DbContext //class extension of Db context
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Document>()
                .HasOne(p => p.Person)
                .WithMany(s => s.Documents)
                .HasForeignKey(p => p.PersonId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Person)
                .WithMany(s => s.Comments)
                .HasForeignKey(c => c.PersonId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Document)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.DocumentId);
        }

    }
}
