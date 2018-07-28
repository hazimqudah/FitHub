using FitHub.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitHub.Contexts
{
    public class FitContext : DbContext
    {
        public FitContext(DbContextOptions<FitContext> options) : base(options)
        {

        }

        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Result>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<Result>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<Result>()
                .Property(e => e.Comment)
                .IsFixedLength();
        }


    }
}
