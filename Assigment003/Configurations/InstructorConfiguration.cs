using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace OnlineLearningPlatform.Configurations
{
    public class InstructorConfiguration
    : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(i => i.Bio)
                .HasMaxLength(500);

            builder.Property(i => i.JoinedDate)
                .IsRequired();

            builder.HasData(
    new Instructor
    {
        Id = 1,
        FullName = "Ahmed Mohamed",
        Email = "ahmed@gmail.com",
        Bio = "Backend Developer",
        JoinedDate = new DateTime(2025, 1, 1)
    },
    new Instructor
    {
        Id = 2,
        FullName = "Sara Ali",
        Email = "sara@gmail.com",
        Bio = "Frontend Developer",
        JoinedDate = new DateTime(2025, 2, 1)
    }
);
        }



    }


}
