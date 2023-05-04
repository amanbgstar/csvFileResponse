using EF_Multilayer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Multilayer.Domain.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SystemDetail> SystemDetails { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(builder =>
            {
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id).UseIdentityColumn();
                builder.Property(e => e.Name).HasMaxLength(50);
                builder.Property(e => e.Age).IsRequired(false);


                builder.HasOne<SystemDetail>(e => e.SystemDetail).
                WithOne(e => e.Employee).
                HasForeignKey<SystemDetail>(d => d.EmployeeId)
                .IsRequired();

                builder.HasMany<Skill>(a => a.Skills).
                WithOne(s => s.Employee).
                HasForeignKey(s => s.EmployeeId);
                //.OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Skill>(skillBulder =>
            {
                skillBulder.HasKey(s => s.SkillId);
                skillBulder.Property(e => e.SkillId).UseIdentityColumn();
                skillBulder.Property(e => e.TechName).HasMaxLength(50).IsRequired(true);
                skillBulder.Property(e => e.WorkExp).HasMaxLength(50).IsRequired(false);
                skillBulder.Property(e => e.Rating).HasMaxLength(50).IsRequired(false);
            });

            modelBuilder.Entity<SystemDetail>(detailBuilder =>
            {
                detailBuilder.HasKey(e => e.DetailId);
                detailBuilder.Property(e => e.DetailId).UseIdentityColumn();
                detailBuilder.Property(e => e.SystemName).HasMaxLength(50).IsRequired(true);
                detailBuilder.Property(e => e.IpAddress).HasMaxLength(20).IsRequired(true);
                detailBuilder.Property(e => e.SeatCode).HasMaxLength(20).IsRequired(true);

            });
        }
    }
}
