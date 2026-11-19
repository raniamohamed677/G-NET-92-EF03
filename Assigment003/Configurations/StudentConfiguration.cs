using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Models;
namespace OnlineLearningPlatform.Configurations
{
    public class StudentConfiguration
     : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(s => s.DateOfBirth)
                .IsRequired();

            builder.HasData(
    new Student
    {
        Id = 1,
        FullName = "Omar Ahmed",
        Email = "omar@gmail.com",
        DateOfBirth = new DateTime(2002, 5, 10)
    },
    new Student
    {
        Id = 2,
        FullName = "Mona Ali",
        Email = "mona@gmail.com",
        DateOfBirth = new DateTime(2003, 8, 15)
    },
    new Student
    {
        Id = 3,
        FullName = "Youssef Mohamed",
        Email = "youssef@gmail.com",
        DateOfBirth = new DateTime(2001, 12, 20)
    }
);
        }
    }
}
