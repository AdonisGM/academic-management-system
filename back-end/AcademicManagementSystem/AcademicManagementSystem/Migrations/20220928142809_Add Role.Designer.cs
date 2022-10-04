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
    [Migration("20220928142809_Add Role")]
    partial class AddRole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Center", b =>
                {
                    b.HasOne("AcademicManagementSystem.Context.AmsModels.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("AcademicManagementSystem.Context.AmsModels.Province", "Province")
                        .WithMany()
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

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.District", b =>
                {
                    b.HasOne("AcademicManagementSystem.Context.AmsModels.Province", "Province")
                        .WithMany("Districts")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Province");
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

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.District", b =>
                {
                    b.Navigation("Wards");
                });

            modelBuilder.Entity("AcademicManagementSystem.Context.AmsModels.Province", b =>
                {
                    b.Navigation("Districts");

                    b.Navigation("Wards");
                });
#pragma warning restore 612, 618
        }
    }
}