using Bogus;
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistence.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(256);

        Faker faker = new Faker("az");

        builder.HasData(
            new Brand
            {
                Id = 1,
                Name = "Kitablar, Elektronika & musiqi",
                //Name = faker.Commerce.Department(),
                CreatedDate = new DateTime(2022, 6, 10),
                IsDeleted = false
            },
            new Brand
            {
                Id = 2,
                Name = "Filmlər",
                //Name = faker.Commerce.Department(),
                CreatedDate = new DateTime(2024, 1, 1),
                IsDeleted = false
            },
            new Brand
            {
                Id = 3,
                //Name = faker.Commerce.Department(),
                Name = "Ev, turizm & oyunlar",
                CreatedDate = new DateTime(2024, 1, 2),
                IsDeleted = true
            }
        );
    }

}
