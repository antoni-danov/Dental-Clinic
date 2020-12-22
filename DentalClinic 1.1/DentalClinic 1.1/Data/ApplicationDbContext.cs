using System;
using System.Collections.Generic;
using System.Text;
using DentalClinic_1._1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DentalClinic_1._1.ViewModels.Patient;
using DentalClinic_1._1.ViewModels.Dentist;
using DentalClinic_1._1.ViewModels.Specialty;

namespace DentalClinic_1._1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<ApplicationUser>()
            //    .HasOne(u => u.Specialization)
            //    .WithMany(s => s.Users)
            //    .OnDelete(DeleteBehavior.SetNull);
           
            builder.Entity<Appointment>()
            .HasOne(a => a.User)
            .WithMany(a => a.Appointments);

            builder.Entity<ApplicationUser>()
            .HasMany(c => c.Appointments)
            .WithOne(e => e.User)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AllPatientsViewModel>().HasKey(x => x.Id);
           
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable(name: "UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogin");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable(name: "UserToken");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRole");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable(name: "RoleClaim");
            });
            
            
        }
       
        public DbSet<DentalClinic_1._1.Models.Specialization> Specializations { get; set; }
        public DbSet<DentalClinic_1._1.Models.Town> Towns { get; set; }
        public DbSet<DentalClinic_1._1.Models.Appointment> Appointments { get; set; }
        public DbSet<DentalClinic_1._1.ViewModels.Specialty.AllSpecializationViewModel> AllSpecializationViewModel { get; set; }

    }
}
