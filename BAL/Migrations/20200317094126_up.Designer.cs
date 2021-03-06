﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200317094126_up")]
    partial class up
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BO.Models.AwAndPnEmployeeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AwAndPnId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateTime");

                    b.Property<Guid>("EmployeeId");

                    b.Property<bool>("IsRemove");

                    b.Property<string>("RemovedBy");

                    b.Property<string>("UpdateBy");

                    b.HasKey("Id");

                    b.HasIndex("AwAndPnId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("AndPnEmployee");
                });

            modelBuilder.Entity("BO.Models.AwAndPnEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<string>("RemovedBy");

                    b.Property<string>("UpdateBy");

                    b.HasKey("Id");

                    b.ToTable("AwAndPn");
                });

            modelBuilder.Entity("BO.Models.CategoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Name");

                    b.Property<string>("RemovedBy");

                    b.Property<string>("UpdateBy");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("BO.Models.CategorySkillEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("RemovedBy");

                    b.Property<int>("SkillId");

                    b.Property<string>("UpdateBy");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SkillId");

                    b.ToTable("CategorySkill");
                });

            modelBuilder.Entity("BO.Models.CourseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("IsAvailable");

                    b.Property<string>("Name");

                    b.Property<string>("RemovedBy");

                    b.Property<double>("Time");

                    b.Property<string>("UpdateBy");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("BO.Models.EmployeeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Education");

                    b.Property<string>("Email");

                    b.Property<DateTime?>("EndedDate");

                    b.Property<bool>("Gender");

                    b.Property<string>("GraduatedAt");

                    b.Property<string>("HouseholdAddress");

                    b.Property<string>("IdentificationNumber");

                    b.Property<string>("Name");

                    b.Property<string>("NativeLand");

                    b.Property<string>("RemovedBy");

                    b.Property<int>("RoleId");

                    b.Property<DateTime>("StartedDate");

                    b.Property<string>("UpdateBy");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("BO.Models.EmployeeProgramEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<Guid>("EmployeeId");

                    b.Property<DateTime>("EndTime");

                    b.Property<bool>("IsPassed");

                    b.Property<bool>("IsRemove");

                    b.Property<Guid>("ProgramId");

                    b.Property<string>("RemovedBy");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("UpdateBy");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProgramId");

                    b.ToTable("EmployeeProgram");
                });

            modelBuilder.Entity("BO.Models.EmployeeRoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateTime");

                    b.Property<Guid>("EmployeeId");

                    b.Property<int>("EndRoleId");

                    b.Property<bool>("IsCurrent");

                    b.Property<string>("RemovedBy");

                    b.Property<int>("StartRoleId");

                    b.Property<string>("UpdateBy");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeRole");
                });

            modelBuilder.Entity("BO.Models.EmployeeSkillEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<Guid>("EmployeeId");

                    b.Property<int>("Level");

                    b.Property<string>("RemovedBy");

                    b.Property<string>("UpdateBy");

                    b.Property<int>("skillId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("skillId");

                    b.ToTable("EmployeeSkill");
                });

            modelBuilder.Entity("BO.Models.ProgramCourseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CourseId");

                    b.Property<string>("CreatedBy");

                    b.Property<Guid>("ProgramId");

                    b.Property<string>("RemovedBy");

                    b.Property<string>("UpdateBy");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("ProgramId");

                    b.ToTable("ProgramCourse");
                });

            modelBuilder.Entity("BO.Models.ProgramEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Name");

                    b.Property<string>("RemovedBy");

                    b.Property<string>("UpdateBy");

                    b.HasKey("Id");

                    b.ToTable("Program");
                });

            modelBuilder.Entity("BO.Models.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAvailable");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("BO.Models.SkillEnitity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("BO.Models.StoreEmployeeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<Guid>("EmployeeId");

                    b.Property<bool>("IsPrimary");

                    b.Property<string>("RemovedBy");

                    b.Property<Guid>("StoreId");

                    b.Property<string>("UpdateBy");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("StoreId");

                    b.ToTable("StoreEmployee");
                });

            modelBuilder.Entity("BO.Models.StoreEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("EndedDate");

                    b.Property<string>("Name");

                    b.Property<string>("RemovedBy");

                    b.Property<int>("Size");

                    b.Property<DateTime>("StartedDate");

                    b.Property<string>("UpdateBy");

                    b.HasKey("Id");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("BO.Models.UserEntity", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BO.Models.UserRoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("BO.Models.AwAndPnEmployeeEntity", b =>
                {
                    b.HasOne("BO.Models.AwAndPnEntity", "AwAndPnEntity")
                        .WithMany("AwAndPnEmployee")
                        .HasForeignKey("AwAndPnId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BO.Models.EmployeeEntity", "EmployeeEntity")
                        .WithMany("AwAndPnEmployee")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BO.Models.CategorySkillEntity", b =>
                {
                    b.HasOne("BO.Models.CategoryEntity", "Category")
                        .WithMany("CategorySkill")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BO.Models.SkillEnitity", "Skill")
                        .WithMany("CategorySkill")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BO.Models.EmployeeEntity", b =>
                {
                    b.HasOne("BO.Models.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BO.Models.EmployeeProgramEntity", b =>
                {
                    b.HasOne("BO.Models.EmployeeEntity", "Employee")
                        .WithMany("EmployeeCourse")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BO.Models.ProgramEntity", "Program")
                        .WithMany()
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BO.Models.EmployeeRoleEntity", b =>
                {
                    b.HasOne("BO.Models.EmployeeEntity", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BO.Models.EmployeeSkillEntity", b =>
                {
                    b.HasOne("BO.Models.EmployeeEntity", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BO.Models.SkillEnitity", "Skill")
                        .WithMany("EmployeeSkill")
                        .HasForeignKey("skillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BO.Models.ProgramCourseEntity", b =>
                {
                    b.HasOne("BO.Models.CourseEntity", "Course")
                        .WithMany("ProgramCourse")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BO.Models.ProgramEntity", "Program")
                        .WithMany("ProgramCourse")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BO.Models.StoreEmployeeEntity", b =>
                {
                    b.HasOne("BO.Models.EmployeeEntity", "Employee")
                        .WithMany("StoreEmployee")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BO.Models.StoreEntity", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BO.Models.UserEntity", b =>
                {
                    b.HasOne("BO.Models.UserRoleEntity", "UserRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
