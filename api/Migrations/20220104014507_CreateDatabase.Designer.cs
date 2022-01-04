﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Repositories;

namespace api.Migrations
{
    [DbContext(typeof(ExamDBContext))]
    [Migration("20220104014507_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("api.Models.Examination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("examDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Examinations");
                });

            modelBuilder.Entity("api.Models.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("api.Models.RegistionForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("examinationId")
                        .HasColumnType("int");

                    b.Property<int>("levelId")
                        .HasColumnType("int");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("levelId");

                    b.HasIndex("studentId");

                    b.HasIndex("examinationId", "levelId", "studentId")
                        .IsUnique();

                    b.ToTable("RegistionForms");
                });

            modelBuilder.Entity("api.Models.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SBD")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("examRoom")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<float?>("pointListen")
                        .HasColumnType("real");

                    b.Property<float?>("pointRead")
                        .HasColumnType("real");

                    b.Property<float?>("pointSpeak")
                        .HasColumnType("real");

                    b.Property<float?>("pointWrite")
                        .HasColumnType("real");

                    b.Property<int>("registionFormId")
                        .HasColumnType("int");

                    b.Property<int>("roomId")
                        .HasColumnType("int");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("registionFormId")
                        .IsUnique();

                    b.HasIndex("roomId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("api.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<int>("examinationId")
                        .HasColumnType("int");

                    b.Property<int>("levelId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("examinationId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("api.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("bornDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("citizenCard")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("issueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("issuePlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("citizenCard")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("api.Models.RegistionForm", b =>
                {
                    b.HasOne("api.Models.Examination", "examination")
                        .WithMany("RegistionForms")
                        .HasForeignKey("examinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Level", "level")
                        .WithMany("RegistionForms")
                        .HasForeignKey("levelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Student", "student")
                        .WithMany("RegistionForms")
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("examination");

                    b.Navigation("level");

                    b.Navigation("student");
                });

            modelBuilder.Entity("api.Models.Result", b =>
                {
                    b.HasOne("api.Models.RegistionForm", "registionForm")
                        .WithOne("result")
                        .HasForeignKey("api.Models.Result", "registionFormId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("api.Models.Room", "room")
                        .WithMany("Results")
                        .HasForeignKey("roomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("registionForm");

                    b.Navigation("room");
                });

            modelBuilder.Entity("api.Models.Room", b =>
                {
                    b.HasOne("api.Models.Examination", "examination")
                        .WithMany("Rooms")
                        .HasForeignKey("examinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Level", "level")
                        .WithMany("Rooms")
                        .HasForeignKey("examinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("examination");

                    b.Navigation("level");
                });

            modelBuilder.Entity("api.Models.Examination", b =>
                {
                    b.Navigation("RegistionForms");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("api.Models.Level", b =>
                {
                    b.Navigation("RegistionForms");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("api.Models.RegistionForm", b =>
                {
                    b.Navigation("result");
                });

            modelBuilder.Entity("api.Models.Room", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("api.Models.Student", b =>
                {
                    b.Navigation("RegistionForms");
                });
#pragma warning restore 612, 618
        }
    }
}