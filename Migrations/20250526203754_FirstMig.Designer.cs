﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recuriment_Platform.Data;

#nullable disable

namespace Recuriment_Platform.Migrations
{
    [DbContext(typeof(MyContextDB))]
    [Migration("20250526203754_FirstMig")]
    partial class FirstMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Recuriment_Platform.Models.Apply", b =>
                {
                    b.Property<int>("JobId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("CandidateId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("JobId", "CandidateId");

                    b.HasIndex("CandidateId");

                    b.ToTable("Applies");
                });

            modelBuilder.Entity("Recuriment_Platform.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExperienceYear")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("Recuriment_Platform.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CGPA")
                        .HasColumnType("float");

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Institution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Year")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("Recuriment_Platform.Models.Job", b =>
                {
                    b.Property<int>("jobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("jobId"));

                    b.Property<string>("companyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("jobDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("jobLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("jobRequirment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("jobSalary")
                        .HasColumnType("float");

                    b.Property<string>("jobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("jobType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("numberEmployees")
                        .HasColumnType("int");

                    b.HasKey("jobId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Recuriment_Platform.Models.Apply", b =>
                {
                    b.HasOne("Recuriment_Platform.Models.Candidate", "Candidate")
                        .WithMany("Applies")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Recuriment_Platform.Models.Job", "Job")
                        .WithMany("Applies")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Recuriment_Platform.Models.Education", b =>
                {
                    b.HasOne("Recuriment_Platform.Models.Candidate", "Candidate")
                        .WithMany("Educations")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("Recuriment_Platform.Models.Candidate", b =>
                {
                    b.Navigation("Applies");

                    b.Navigation("Educations");
                });

            modelBuilder.Entity("Recuriment_Platform.Models.Job", b =>
                {
                    b.Navigation("Applies");
                });
#pragma warning restore 612, 618
        }
    }
}
