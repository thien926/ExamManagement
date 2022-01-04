using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ExamDBContext : DbContext
    {
        public ExamDBContext(DbContextOptions<ExamDBContext> options) : base(options) {}

        // public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<RegistionForm> RegistionForms { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
            // modelBuilder.Entity<Teacher>(entity => {
            //     entity.ToTable("Teachers");
            //     entity.HasKey(o => o.Id);
            //     entity.Property(o => o.name).HasMaxLength(100).IsRequired();
            //     entity.Property(o => o.gender).IsRequired().HasMaxLength(3);
            //     entity.Property(o => o.phone).HasMaxLength(10).IsRequired();
            // });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("Levels");
                entity.HasKey(o => o.Id);
                entity.Property(o => o.name).HasMaxLength(3).IsRequired();
            });

            modelBuilder.Entity<Examination>(entity => {
                entity.ToTable("Examinations");
                entity.HasKey(o => o.Id);
                entity.Property(o => o.name).HasMaxLength(200).IsRequired();
                entity.Property(o => o.examDate).IsRequired();
            });

            modelBuilder.Entity<Student>(entity => {
                entity.ToTable("Students");
                entity.HasKey(o => o.Id);
                entity.Property(o => o.name).HasMaxLength(100).IsRequired();
                entity.Property(o => o.gender).HasMaxLength(3).IsRequired();
                entity.Property(o => o.bornDate).IsRequired();
                entity.Property(o => o.citizenCard).HasMaxLength(12).IsRequired();
                entity.Property(o => o.issueDate).IsRequired();
                entity.Property(o => o.issuePlace).IsRequired();
                entity.Property(o => o.phone).HasMaxLength(10).IsRequired();
                entity.Property(o => o.email).HasMaxLength(320).IsRequired();

                entity.HasIndex(o => o.citizenCard).IsUnique();
            });

            modelBuilder.Entity<RegistionForm>(entity => {
                entity.ToTable("RegistionForms");
                entity.HasKey(o => o.Id);
                entity.Property(o => o.status).IsRequired();
                entity.HasIndex(o => new { o.examinationId, o.levelId, o.studentId }).IsUnique();

                entity.HasOne<Student>(o => o.student)
                    .WithMany(m => m.RegistionForms)
                    .HasForeignKey(o => o.studentId)
                    // .HasForeignKey("RegistionForms_Students")
                    // .HasConstraintName("FK_RegistionForms_Students_studentId")
                    .OnDelete(DeleteBehavior.Cascade);
                
                entity.HasOne<Examination>(o => o.examination)
                    .WithMany(m => m.RegistionForms)
                    .HasForeignKey(o => o.examinationId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Level>(o => o.level)
                    .WithMany(m => m.RegistionForms)
                    .HasForeignKey(o => o.levelId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Result>(o => o.result)
                    .WithOne(m => m.registionForm)
                    .HasForeignKey<Result>(m => m.registionFormId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Room>(entity => {
                entity.ToTable("Rooms");
                entity.HasKey(o => o.Id);
                entity.Property(o => o.name).HasMaxLength(100).IsRequired();
                entity.Property(o => o.amount).IsRequired();
                // entity.Property(o => o.endTime).IsRequired();

                entity.HasOne<Examination>(o => o.examination)
                    .WithMany(m => m.Rooms)
                    .HasForeignKey(o => o.examinationId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Level>(o => o.level)
                    .WithMany(m => m.Rooms)
                    .HasForeignKey(o => o.examinationId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // modelBuilder.Entity<Watcher>(entity => {
            //     entity.ToTable("Watchers");
            //     entity.HasKey(o => new { o.roomId, o.teacherId });
            // });

            modelBuilder.Entity<Result>(entity => {
                entity.ToTable("Results");
                entity.HasKey(o => o.Id);
                entity.Property(o => o.examRoom).HasMaxLength(5).IsRequired();
                entity.Property(o => o.SBD).HasMaxLength(5).IsRequired();
                // entity.Property(o => o.pointListen).IsRequired();
                // entity.Property(o => o.pointRead).IsRequired();
                // entity.Property(o => o.pointSpeak).IsRequired();
                // entity.Property(o => o.pointWrite).IsRequired();

                entity.HasOne<Room>(o => o.room)
                    .WithMany(m => m.Results)
                    .HasForeignKey(o => o.roomId)
                    .OnDelete(DeleteBehavior.Cascade);

                // entity.HasOne<Student>(o => o.student)
                //     .WithMany(m => m.Results)
                //     .HasForeignKey(o => o.studentId)
                //     .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}