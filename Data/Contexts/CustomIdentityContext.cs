using FitHub.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitHub.Contexts
{
    public class CustomIdentityContext : IdentityDbContext
    {

        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }
        public virtual DbSet<MuscleGroup> MuscleGroups { get; set; }

        public CustomIdentityContext(DbContextOptions<CustomIdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
