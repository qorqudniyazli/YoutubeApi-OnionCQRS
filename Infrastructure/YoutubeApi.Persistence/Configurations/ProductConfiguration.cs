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

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        Faker faker = new Faker("az");

        builder.HasData(
            new Product
            {
                Id = 1,
                Title = "İnanılmaz Rezin Kəmər",
                Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                BrandId = 1,
                Discount = 0.73m,
                Price = 87.16m,
                CreatedDate = new DateTime(2024, 1, 1),
                //Title = faker.Commerce.ProductName(),
                //Description = faker.Commerce.ProductDescription(),
                //Discount = faker.Random.Decimal(0, 10),
                //Price = faker.Finance.Amount(10, 1000),
                IsDeleted = false


            },
            new Product
            {
                Id = 2,
                Title = "İnanılmaz Pambıq Kəmər",
                Description = "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
                BrandId = 3,
                Discount = 5.73m,
                Price = 491.16m,
                CreatedDate = new DateTime(2024, 1, 2),
                //Title = faker.Commerce.ProductName(),
                //Description = faker.Commerce.ProductDescription(),
                //Discount = faker.Random.Decimal(0, 10),
                //Price = faker.Finance.Amount(10, 1000),
                IsDeleted = false
            }
        );
    }

}
