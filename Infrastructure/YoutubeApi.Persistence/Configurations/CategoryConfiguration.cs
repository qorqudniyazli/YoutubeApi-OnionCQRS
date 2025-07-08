using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(256);

        var category1 = new Category
        {
            Id = 1,
            ParentId = 0,
            Name = "Electronics",
            Priorty = 1,
            CreatedDate = new DateTime(2024, 1, 1),
            IsDeleted = false
        };

        var category2 = new Category
        {
            Id = 2,
            ParentId = 0,
            Name = "Moda",
            Priorty = 2,
            CreatedDate = new DateTime(2024, 1, 2),
            IsDeleted = false
        };

        var parent1 = new Category
        {
            Id = 3,
            ParentId = 1,
            Name = "Computer",
            Priorty = 1,
            CreatedDate = new DateTime(2024, 1, 3),
            IsDeleted = true
        };

        var parent2 = new Category
        {
            Id = 4,
            ParentId = 2,
            Name = "Kadin",
            Priorty = 1,
            CreatedDate = new DateTime(2024, 1, 4),
            IsDeleted = true
        };

        builder.HasData(category1, category2, parent1, parent2);
    }

}
