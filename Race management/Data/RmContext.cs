using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Race_management.Models;

namespace Race_management.Data
{
    public class RmContext : IdentityDbContext<RmUserIdentity>
    {
        public RmContext(DbContextOptions<RmContext> option) : base(option)
        {
        }

        public DbSet<Show> Shows { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<ShowToCoach> ShowToCoache { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Config Tables
            builder.Entity<Show>(e =>
            {
                e.HasKey(e => e.ShowId);
                e.Property(e => e.ShowId).UseIdentityColumn();
                e.Property(e => e.ShowTitle).IsRequired().HasMaxLength(100);
                e.Property(e => e.ShowDate).IsRequired();
                e.Property(e => e.AverageScore).HasMaxLength(2);
                //relation
                e.HasOne(e => e.ShowPlayer).WithMany(e => e.PlayerShows).HasForeignKey(e=>e.ShowplayerId);
                              
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

            #endregion
            #region seaddata
            //0-2=for roles
            //3=for admin
            //4-5=for coach
            //6-7=for player

            var ids = new string[8];
            for(int i=0; i<ids.Length; i++)
            {
                ids[i] = Guid.NewGuid().ToString();
            }
            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityRole>(e =>
            {
                e.HasData(new IdentityRole()
                {
                    Id = ids[0],
                    Name="Admin",
                    NormalizedName="ADMIN",
                });
                e.HasData(new IdentityRole()
                {
                    Id = ids[1],
                    Name = "Coach",
                    NormalizedName = "COACH"
                });
                e.HasData(new IdentityRole()
                {
                    Id = ids[2],
                    Name = "Player",
                    NormalizedName = "PLAYER"
                });
            });
            builder.Entity<RmUserIdentity>(e =>
            {
                e.HasData(new RmUserIdentity()
                {
                    Id = ids[3],
                    Name = "Ashkan",
                    UserName = "Ashkanmir",
                    NormalizedUserName="ASHKANMIR",
                    LastName = "Mirdamadi",
                    Email = "ashkan110mir@gmail.com",
                    NormalizedEmail="ASHKAN110MIR@GMAIL.COM",
                    PhoneNumber = "09908752252",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Ashkanmir22!")
                });


                //coach
                e.HasData(new RmUserIdentity()
                {
                    Id = ids[4],
                    Name = "Ali",
                    UserName = "AliZM",
                    NormalizedUserName="ALIZM",
                    LastName = "Mohammadi",
                    Email = "aliMohammadi@yahoo.com",
                    NormalizedEmail="ALIMOHAMMADI@YAHOO.COM",
                    PhoneNumber = "09139875623",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "AliZMMohammadi12!")
                });
                e.HasData(new RmUserIdentity()
                {
                    Id = ids[5],
                    Name = "Reza",
                    UserName = "RezaAhmadi",
                    NormalizedUserName="REZAAHMADI",
                    LastName = "Ahmadi",
                    Email = "AhmadiReza@outlook.com",
                    NormalizedEmail="AHMADIREZA@OUTLOOK.COM",
                    PhoneNumber = "09139958123",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "RezaAhmadi!")
                });



                //player
                e.HasData(new RmUserIdentity()
                {
                    Id = ids[6],
                    Name = "Fatemeh",
                    LastName = "Akbari",
                    UserName = "FatemehAk",
                    NormalizedUserName="FATEMEHAK",
                    Email = "Akbari@outlook.com",
                    NormalizedEmail="AKBARI@OUTLOOK.COM",
                    PhoneNumber = "09137456723",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Akbari!333!")
                });

                e.HasData(new RmUserIdentity()
                {
                    Id = ids[7],
                    Name = "Amir",
                    LastName = "Rahimi",
                    UserName = "RahimiA",
                    NormalizedUserName="RAHIMIA",
                    Email = "Rahimi@yahoo.com",
                    NormalizedEmail="RAHIMI@YAHOO.COM",
                    PhoneNumber = "09139874571",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "123456789DFww!")
                });

            });
            
            builder.Entity<Show>(e =>
            {
                e.HasData(new Show()
                {
                    ShowId = 1,
                    ShowDate = DateTime.Parse("2024/07/07"),
                    ShowTitle = "اجرا 1",
                    ShowplayerId = ids[6],
                    AverageScore=-1
                });
                e.HasData(new Show
                {
                    ShowId = 2,
                    ShowDate = DateTime.Parse("2024/07/07"),
                    ShowTitle = "اجرا 2",
                    ShowplayerId = ids[7],
                    AverageScore=-1
                });
            });
            builder.Entity<IdentityUserRole<string>>(e =>
            {
                //admin
                e.HasData(new IdentityUserRole<string>()
                {
                    RoleId = ids[0],
                    UserId = ids[3],
                });
                //coach
                e.HasData(new IdentityUserRole<string>()
                {
                    RoleId = ids[1],
                    UserId = ids[4],
                });
                e.HasData(new IdentityUserRole<string>()
                {
                    RoleId = ids[1],
                    UserId = ids[5],
                });
                //player
                e.HasData(new IdentityUserRole<string>()
                {
                    RoleId = ids[2],
                    UserId = ids[6],
                });
                e.HasData(new IdentityUserRole<string>()
                {
                    RoleId = ids[2],
                    UserId = ids[7],
                });
            });
            #endregion
            base.OnModelCreating(builder);
        }
    }
}
