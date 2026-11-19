using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Models;

namespace OnlineLearningPlatform.Configurations
{
    public class EnrollmentConfiguration
     : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => new
            {
                e.StudentId,
                e.CourseId
            });

            builder.Property(e => e.EnrollmentDate)
                .IsRequired();

            builder.Property(e => e.ProgressPercentage)
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(e => e.Status)
                .IsRequired();

            builder.Property(e => e.FinalGrade)
                .HasPrecision(5, 2)
                .IsRequired(false);

            builder.HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
    new Enrollment
    {
        StudentId = 1,
        CourseId = 1,
        EnrollmentDate = new DateTime(2025, 3, 1),
        ProgressPercentage = 100,
        Status = EnrollmentStatus.Completed,
        FinalGrade = 95
    },
    new Enrollment
    {
        StudentId = 2,
        CourseId = 2,
        EnrollmentDate = new DateTime(2025, 3, 5),
        ProgressPercentage = 40,
        Status = EnrollmentStatus.Active,
        FinalGrade = null
    },
    new Enrollment
    {
        StudentId = 3,
        CourseId = 1,
        EnrollmentDate = new DateTime(2025, 3, 10),
        ProgressPercentage = 20,
        Status = EnrollmentStatus.Active,
        FinalGrade = null
    }
);
        }
    }
}
