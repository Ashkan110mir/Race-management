using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Race_management.Models;

namespace Race_management.Data
{
    public class RbContext : IdentityDbContext<RmUserIdentity>
    {
        public RbContext(DbContextOptions<RbContext> option) : base(option)
        {
        }

        public DbSet<Show> Shows { get; set; }

        public DbSet<Team> Teams { get; set; }

 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Show>(e =>
            {
                e.HasKey(e => e.ShowId);
                e.Property(e => e.ShowId).UseIdentityColumn();
                e.Property(e => e.ShowTitle).IsRequired().HasMaxLength(100);
                e.Property(e => e.ShowDate).IsRequired();
                e.Property(e => e.AverageScore).HasMaxLength(2);

                //relation

                e.HasOne(e => e.ShowPlayer).WithMany(e => e.PlayerShows);
               
                
            });

            builder.Entity<Team>(e =>
            {
                e.HasKey(e => e.TeamId);
                e.Property(e=>e.TeamId).UseIdentityColumn();
                e.Property(e => e.TeamName).IsRequired().HasMaxLength(70);
                //relation

                e.HasMany(e => e.Players).WithOne(e => e.PlayerTeam);
                e.HasOne(e => e.Coach).WithMany(e => e.CoachTeams);
            });
            builder.Entity<ShowToCoach>(e =>
            {
                e.HasKey(e=>new {e.ShowId,e.Coachid});
                e.Property(e => e.score).IsRequired().HasMaxLength(2);
                e.HasOne(e => e.Show).WithMany(e => e.ShowToCoach).HasForeignKey(e => e.ShowId);
                e.HasOne(e => e.Coach).WithMany(e => e.CoachToShow).HasForeignKey(e => e.Coachid);
            });
           
            base.OnModelCreating(builder);
        }
    }
}
