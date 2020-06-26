using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestWeb1.Models.Entities;

namespace TestWeb1.Models.Services.Infrastructure
{
    public partial class MyCourseDbContext : DbContext
    {
        public MyCourseDbContext(DbContextOptions<MyCourseDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Courses"); //Indica nome tabella, superflua se la tabella ha lo stesso nome della property del dbSet
                entity.HasKey(course => course.Id); //Indica la chiave primaria

                //Mapping per gli owned types
                entity.OwnsOne(course => course.CurrentPrice, builder => {
                    builder.Property(money => money.Currency).HasConversion<string>();
                });

                entity.OwnsOne(course => course.FullPrice, builder => {
                    builder.Property(money => money.Currency).HasConversion<string>();
                });

                //Mapping per le relazioni
                entity.HasMany(course => course.Lessons)
                      .WithOne(lesson => lesson.Course)
                      .HasForeignKey(lesson => lesson.CourseId);
                    

                #region Mapping generato automaticamente dal tool di reverse engineering
                // entity.Property(e => e.Id).ValueGeneratedNever();

                // entity.Property(e => e.Author)
                //     .IsRequired()
                //     .HasColumnType("TEXT (100)");

                // entity.Property(e => e.CurrentPriceAmount)
                //     .IsRequired()
                //     .HasColumnName("CurrentPrice_Amount")
                //     .HasColumnType("NUMERIC")
                //     .HasDefaultValueSql("0");

                // entity.Property(e => e.CurrentPriceCurrency)
                //     .IsRequired()
                //     .HasColumnName("CurrentPrice_Currency")
                //     .HasColumnType("TEXT (3)")
                //     .HasDefaultValueSql("'EUR'");

                // entity.Property(e => e.Description).HasColumnType("TEXT (10000)");

                // entity.Property(e => e.Email).HasColumnType("TEXT (100)");

                // entity.Property(e => e.FullPriceAmount)
                //     .IsRequired()
                //     .HasColumnName("FullPrice_Amount")
                //     .HasColumnType("NUMERIC")
                //     .HasDefaultValueSql("0");

                // entity.Property(e => e.FullPriceCurrency)
                //     .IsRequired()
                //     .HasColumnName("FullPrice_Currency")
                //     .HasColumnType("TEXT (3)")
                //     .HasDefaultValueSql("'EUR'");

                // entity.Property(e => e.ImagePath).HasColumnType("TEXT (100)");

                // entity.Property(e => e.Title)
                //     .IsRequired()
                //     .HasColumnType("TEXT (100)");
                #endregion
            });

            modelBuilder.Entity<Lesson>(entity =>
            {

                #region Mapping generato automaticamente dal tool di reverse engineering
                // entity.Property(e => e.Id).ValueGeneratedNever();

                // entity.Property(e => e.Description).HasColumnType("TEXT (10000)");

                // entity.Property(e => e.Duration)
                //     .IsRequired()
                //     .HasColumnType("TEXT (8)")
                //     .HasDefaultValueSql("'00:00:00'");

                // entity.Property(e => e.Title)
                //     .IsRequired()
                //     .HasColumnType("TEXT (100)");

                // entity.HasOne(d => d.Course)
                //     .WithMany(p => p.Lessons)
                //     .HasForeignKey(d => d.CourseId);
                #endregion
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
