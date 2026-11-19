using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int? ParentCategoryId { get; set; }

        public Category? ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; }
            = new List<Category>();

        public ICollection<Course> Courses { get; set; }
            = new List<Course>();
    }
}
