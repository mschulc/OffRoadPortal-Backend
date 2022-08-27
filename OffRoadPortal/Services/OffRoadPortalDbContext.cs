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
        public DbSet<Car>? Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .Property(r => r.EventName).IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}