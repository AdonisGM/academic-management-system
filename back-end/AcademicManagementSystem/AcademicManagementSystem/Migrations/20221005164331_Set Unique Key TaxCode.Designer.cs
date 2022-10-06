﻿// <auto-generated />
using System;
using AcademicManagementSystem.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AcademicManagementSystem.Migrations
{
    [DbContext(typeof(AmsContext))]
    [Migration("20221005164331_Set Unique Key TaxCode")]
    partial class SetUniqueKeyTaxCode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.ActiveRefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ExpDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("exp_date");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("refresh_token");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("active_refresh_token");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Admin", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("UserId");

                    b.ToTable("admin");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Center", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int")
                        .HasColumnName("district_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int")
                        .HasColumnName("province_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.Property<int>("WardId")
                        .HasColumnType("int")
                        .HasColumnName("ward_id");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.HasIndex("ProvinceId");

                    b.HasIndex("WardId");

                    b.ToTable("center");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Course", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("code");

                    b.Property<string>("CourseFamilyCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("course_family_code");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<int>("SemesterCount")
                        .HasColumnType("int")
                        .HasColumnName("semester_count");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Code");

                    b.HasIndex("CourseFamilyCode");

                    b.ToTable("course");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.CourseFamily", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<int>("PublishedYear")
                        .HasColumnType("int")
                        .HasColumnName("published_year");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Code");

                    b.ToTable("course_family");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.CourseModuleSemester", b =>
                {
                    b.Property<string>("CourseCode")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("course_code");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int")
                        .HasColumnName("module_id");

                    b.Property<int>("SemesterId")
                        .HasColumnType("int")
                        .HasColumnName("semester_id");

                    b.HasKey("CourseCode", "ModuleId", "SemesterId");

                    b.HasIndex("ModuleId");

                    b.HasIndex("SemesterId");

                    b.ToTable("course_module_semester");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("prefix");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int")
                        .HasColumnName("province_id");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("district");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("gender");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CenterId")
                        .HasColumnType("int")
                        .HasColumnName("center_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<int>("Days")
                        .HasColumnType("int")
                        .HasColumnName("days");

                    b.Property<string>("ExamType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("exam_type");

                    b.Property<int>("Hours")
                        .HasColumnType("int")
                        .HasColumnName("hours");

                    b.Property<int?>("MaxPracticalGrade")
                        .HasColumnType("int")
                        .HasColumnName("max_practical_grade");

                    b.Property<int?>("MaxTheoryGrade")
                        .HasColumnType("int")
                        .HasColumnName("max_theory_grade");

                    b.Property<string>("ModuleExamNamePortal")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("module_exam_name_portal");

                    b.Property<string>("ModuleName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("module_name");

                    b.Property<string>("ModuleType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("module_type");

                    b.Property<string>("SemesterNamePortal")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("semester_name_portal");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("CenterId");

                    b.ToTable("module");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("province");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("capacity");

                    b.Property<int>("CenterId")
                        .HasColumnType("int")
                        .HasColumnName("center_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int")
                        .HasColumnName("room_type_id");

                    b.HasKey("Id");

                    b.HasIndex("CenterId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("room");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("room_type");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("semester");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Sro", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("UserId");

                    b.ToTable("sro");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Teacher", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("company_address");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nickname");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("salary");

                    b.Property<DateTime>("StartWorkingDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("start_working_date");

                    b.Property<string>("TaxCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("tax_code");

                    b.Property<int>("TeacherTypeId")
                        .HasColumnType("int")
                        .HasColumnName("teacher_type_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.Property<int>("WorkingTimeId")
                        .HasColumnType("int")
                        .HasColumnName("working_time_id");

                    b.HasKey("UserId");

                    b.HasIndex("TaxCode")
                        .IsUnique();

                    b.HasIndex("TeacherTypeId");

                    b.HasIndex("WorkingTimeId");

                    b.ToTable("teacher");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.TeacherType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("teacher_type");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Avatar")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("avatar");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date")
                        .HasColumnName("birthday");

                    b.Property<int>("CenterId")
                        .HasColumnType("int")
                        .HasColumnName("center_id");

                    b.Property<string>("CitizenIdentityCardNo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("citizen_identity_card_no");

                    b.Property<DateTime>("CitizenIdentityCardPublishedDate")
                        .HasColumnType("date")
                        .HasColumnName("citizen_identity_card_published_date");

                    b.Property<string>("CitizenIdentityCardPublishedPlace")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("citizen_identity_card_published_place");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int")
                        .HasColumnName("district_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("EmailOrganization")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("email_organization");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("first_name");

                    b.Property<int>("GenderId")
                        .HasColumnType("int")
                        .HasColumnName("gender_id");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("last_name");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("mobile_phone");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int")
                        .HasColumnName("province_id");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.Property<int>("WardId")
                        .HasColumnType("int")
                        .HasColumnName("ward_id");

                    b.HasKey("Id");

                    b.HasIndex("CenterId");

                    b.HasIndex("CitizenIdentityCardNo")
                        .IsUnique();

                    b.HasIndex("DistrictId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("EmailOrganization")
                        .IsUnique();

                    b.HasIndex("GenderId");

                    b.HasIndex("MobilePhone")
                        .IsUnique();

                    b.HasIndex("ProvinceId");

                    b.HasIndex("RoleId");

                    b.HasIndex("WardId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Ward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DistrictId")
                        .HasColumnType("int")
                        .HasColumnName("district_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("prefix");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int")
                        .HasColumnName("province_id");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("ward");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.WorkingTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("working_time");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.ActiveRefreshToken", b =>
                {
                    b.HasOne("AcademicManagementSystem.Context.AmsModels.User", "User")
                        .WithMany("ActiveRefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Admin", b =>
                {
                    b.HasOne("AcademicManagementSystem.Context.AmsModels.User", "User")
                        .WithOne("Admin")
                        .HasForeignKey("AcademicManagementSystem.Context.AmsModels.Admin", "UserId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Center", b =>
                {
                    b.HasOne("AcademicManagementSystem.Context.AmsModels.District", "District")
                        .WithMany("Centers")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("AcademicManagementSystem.Context.AmsModels.Province", "Province")
                        .WithMany("Centers")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("AcademicManagementSystem.Context.AmsModels.Ward", "Ward")
                        .WithMany()
                        .HasForeignKey("WardId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("District");

                    b.Navigation("Province");

                    b.Navigation("Ward");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Course", b =>
                {
                    b.HasOne("AcademicManagementSystem.Context.AmsModels.CourseFamily", "CourseFamily")
                        .WithMany("Courses")
                        .HasForeignKey("CourseFamilyCode")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("CourseFamily");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.CourseModuleSemester", b =>
                {
                    b.HasOne("AcademicManagementSystem.Context.AmsModels.Course", "Course")
                        .WithMany("CourseModuleSemesters")
                        .HasForeignKey("CourseCode")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("AcademicManagementSystem.Context.AmsModels.Module", "Module")
                        .WithMany("CourseModuleSemesters")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("AcademicManagementSystem.Context.AmsModels.Semester", "Semester")
                        .WithMany("CoursesModuleSemesters")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Module");

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.District", b =>
                {
                    b.HasOne("AcademicManagementSystem.Context.AmsModels.Province", "Province")
                        .WithMany("Districts")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Module", b =>
                {
                    b.HasOne("AcademicManagementSystem.Context.AmsModels.Center", "Center")
                        .WithMany("Modules")
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Center");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Room", b =>
                {
                    b.HasOne("AcademicManagementSystem.Context.AmsModels.Center", "Center")
                        .WithMany("Rooms")
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("AcademicManagementSystem.Context.AmsModels.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Center");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Sro", b =>
                {
                    b.HasOne("AcademicManagementSystem.Context.AmsModels.User", "User")
                        .WithOne("Sro")
                        .HasForeignKey("AcademicManagementSystem.Context.AmsModels.Sro", "UserId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Teacher", b =>
                {
                    b.HasOne("AcademicManagementSystem.Context.AmsModels.TeacherType", "TeacherType")
                        .WithMany("Teachers")
                        .HasForeignKey("TeacherTypeId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("AcademicManagementSystem.Context.AmsModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("AcademicManagementSystem.Context.AmsModels.WorkingTime", "WorkingTime")
                        .WithMany("Teachers")
                        .HasForeignKey("WorkingTimeId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("TeacherType");

                    b.Navigation("User");

                    b.Navigation("WorkingTime");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.User", b =>
                {
                    b.HasOne("AcademicManagementSystem.Context.AmsModels.Center", "Center")
                        .WithMany("Users")
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("AcademicManagementSystem.Context.AmsModels.District", "District")
                        .WithMany("Users")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("AcademicManagementSystem.Context.AmsModels.Gender", "Gender")
                        .WithMany("Users")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("AcademicManagementSystem.Context.AmsModels.Province", "Province")
                        .WithMany("Users")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("AcademicManagementSystem.Context.AmsModels.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("AcademicManagementSystem.Context.AmsModels.Ward", "Ward")
                        .WithMany()
                        .HasForeignKey("WardId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Center");

                    b.Navigation("District");

                    b.Navigation("Gender");

                    b.Navigation("Province");

                    b.Navigation("Role");

                    b.Navigation("Ward");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Ward", b =>
                {
                    b.HasOne("AcademicManagementSystem.Context.AmsModels.District", "District")
                        .WithMany("Wards")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("AcademicManagementSystem.Context.AmsModels.Province", "Province")
                        .WithMany("Wards")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("District");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Center", b =>
                {
                    b.Navigation("Modules");

                    b.Navigation("Rooms");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Course", b =>
                {
                    b.Navigation("CourseModuleSemesters");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.CourseFamily", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.District", b =>
                {
                    b.Navigation("Centers");

                    b.Navigation("Users");

                    b.Navigation("Wards");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Gender", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Module", b =>
                {
                    b.Navigation("CourseModuleSemesters");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Province", b =>
                {
                    b.Navigation("Centers");

                    b.Navigation("Districts");

                    b.Navigation("Users");

                    b.Navigation("Wards");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Semester", b =>
                {
                    b.Navigation("CoursesModuleSemesters");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.TeacherType", b =>
                {
                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.User", b =>
                {
                    b.Navigation("ActiveRefreshTokens");

                    b.Navigation("Admin")
                        .IsRequired();

                    b.Navigation("Sro")
                        .IsRequired();
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.WorkingTime", b =>
                {
                    b.Navigation("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}
