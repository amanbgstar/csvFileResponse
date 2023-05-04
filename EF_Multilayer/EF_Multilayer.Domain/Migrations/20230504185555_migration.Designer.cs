﻿// <auto-generated />
using System;
using EF_Multilayer.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_Multilayer.Domain.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20230504185555_migration")]
    partial class migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EF_Multilayer.Domain.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EF_Multilayer.Domain.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillId"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Rating")
                        .HasMaxLength(50)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TechName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("WorkExp")
                        .HasMaxLength(50)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SkillId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("EF_Multilayer.Domain.Models.SystemDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailId"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SeatCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SystemName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DetailId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("SystemDetails");
                });

            modelBuilder.Entity("EF_Multilayer.Domain.Models.Skill", b =>
                {
                    b.HasOne("EF_Multilayer.Domain.Models.Employee", "Employee")
                        .WithMany("Skills")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EF_Multilayer.Domain.Models.SystemDetail", b =>
                {
                    b.HasOne("EF_Multilayer.Domain.Models.Employee", "Employee")
                        .WithOne("SystemDetail")
                        .HasForeignKey("EF_Multilayer.Domain.Models.SystemDetail", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EF_Multilayer.Domain.Models.Employee", b =>
                {
                    b.Navigation("Skills");

                    b.Navigation("SystemDetail")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
