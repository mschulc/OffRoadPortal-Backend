/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: OffRoadPortalDbContext.cs                         //
/////////////////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;
using OffRoadPortal.Entities;

namespace OffRoadPortal.Services
{
    public class OffRoadPortalDbContext : DbContext
    {
        private readonly string _connectionString = "Server=DESKTOP-A1KG436;Database=OffroadPortalDb;Integrated Security=sspi;";

        public DbSet<Event>? Events { get; set; }
        public DbSet<Article>? Articles { get; set; }
        public DbSet<ArticleComment>? ArticleComments { get; set; }
        public DbSet<EventComment>? EventComments { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<Car>? Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User Entity
            modelBuilder.Entity<User>()
                .Property(u => u.Email).IsRequired();

            //Role Entity
            modelBuilder.Entity<Role>()
                .Property(r => r.Name).IsRequired();

            //Article Entity
            modelBuilder.Entity<Article>()
                .Property(a => a.Title).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Article>()
               .Property(a => a.Content).IsRequired();
            modelBuilder.Entity<Article>()
               .Property(a => a.Author).IsRequired();
            modelBuilder.Entity<Article>()
               .Property(a => a.ImageUrl).IsRequired();

            //ArticleCommemt Entity
            modelBuilder.Entity<ArticleComment>()
                .Property(ac => ac.Content).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<ArticleComment>()
                .Property(ac => ac.Author).IsRequired();

            //Car Entity
            modelBuilder.Entity<Car>()
                .Property(c => c.Name).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Car>()
                .Property(c => c.Mark).IsRequired();
            modelBuilder.Entity<Car>()
               .Property(c => c.Model).IsRequired();
            modelBuilder.Entity<Car>()
               .Property(c => c.Year).IsRequired();

            //Event Entity
            modelBuilder.Entity<Event>()
                .Property(e => e.EventName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Event>()
                .Property(e => e.EventDescription).IsRequired();
            modelBuilder.Entity<Event>()
                .Property(e => e.EventOrganizerId).IsRequired();
            modelBuilder.Entity<Event>()
                .Property(e => e.StartEventDate).IsRequired();
            modelBuilder.Entity<Event>()
                .Property(e => e.EndEventDate).IsRequired();
            modelBuilder.Entity<Event>()
                .Property(e => e.Category).IsRequired();
            modelBuilder.Entity<Event>()
                .Property(e => e.Type).IsRequired();

            //EventComment Entity
            modelBuilder.Entity<EventComment>()
                .Property(ec => ec.Content).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<EventComment>()
               .Property(ec => ec.Author).IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}