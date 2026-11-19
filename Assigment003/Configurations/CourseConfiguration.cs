using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace OnlineLearningPlatform.Configurations
{
    public class CourseConfiguration
     : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Description)
                .HasMaxLength(1000);

            builder.Property(c => c.Price)
                .HasPrecision(18, 2);

            builder.Property(c => c.Level)
                .IsRequired();

            builder.Property(c => c.IsPublished)
                .IsRequired();

            builder.Property(c => c.PublishedDate)
                .IsRequired(false);

            builder.HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Category)
                .WithMany(c => c.Courses)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
    new Course
    {
        Id = 1,
        Title = "C# Basics",
        Description = "Introduction to C#",
        Price = 500,
        Level = CourseLevel.Beginner,
        IsPublished = true,
        PublishedDate = new DateTime(2025, 1, 10),
        InstructorId = 1,
        CategoryId = 1
    },
    new Course
    {
        Id = 2,
        Title = "ASP.NET Core",
        Description = "Backend Development",
        Price = 1000,
        Level = CourseLevel.Intermediate,
        IsPublished = true,
        PublishedDate = new DateTime(2025, 2, 10),
        InstructorId = 2,
        CategoryId = 3
    }
);
        }
    }
}
