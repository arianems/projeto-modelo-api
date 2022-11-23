﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TokenAPI.Infra.Contexts;

#nullable disable

namespace TokenAPI.Infra.Migrations
{
    [DbContext(typeof(SQLServerContext))]
    [Migration("20221122034659_user-entity-v2")]
    partial class userentityv2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ModelAPIProject.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeID")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TokenAPI.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("TokenAPI.Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfAdmission")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<Guid>("DepartmentID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ModelAPIProject.Domain.Entities.User", b =>
                {
                    b.HasOne("TokenAPI.Domain.Entities.Employee", "Employee")
                        .WithOne("User")
                        .HasForeignKey("ModelAPIProject.Domain.Entities.User", "EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("TokenAPI.Domain.Value_Objects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(90)
                                .HasColumnType("nvarchar(90)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("TokenAPI.Domain.Entities.Employee", b =>
                {
                    b.HasOne("TokenAPI.Domain.Entities.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("TokenAPI.Domain.Value_Objects.FullName", "Name", b1 =>
                        {
                            b1.Property<Guid>("EmployeeId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("MiddleName")
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("MiddleName");

                            b1.Property<string>("Surname")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("Surname");

                            b1.HasKey("EmployeeId");

                            b1.HasIndex("FirstName", "Surname");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.Navigation("Department");

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("TokenAPI.Domain.Entities.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("TokenAPI.Domain.Entities.Employee", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
