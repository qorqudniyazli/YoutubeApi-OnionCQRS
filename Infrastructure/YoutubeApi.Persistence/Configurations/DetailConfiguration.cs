using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistence.Configurations;

public class DetailConfiguration : IEntityTypeConfiguration<Detail>
{
    public void Configure(EntityTypeBuilder<Detail> builder)
    {
        Faker faker = new Faker("az");

        builder.HasData(
            new Detail
            {
                Id = 1,
                Title = "Omnis.",
                Description = "Dolorem fugiat voluptatem nam quia.",
                CategoryId = 1,
                CreatedDate = new DateTime(2024, 01, 01),
                IsDeleted = false
            },
            new Detail
            {
                Id = 2,
                Title = "Est id.",
                Description = "Rerum maiores alias repellat tempore.",
                CategoryId = 3,
                CreatedDate = new DateTime(2024, 01, 02),
                IsDeleted = true
            },
            new Detail
            {
                Id = 3,
                Title = "Voluptas.",
                Description = "Aut fugiat earum sed consequatur.",
                CategoryId = 4,
                CreatedDate = new DateTime(2024, 01, 03),
                IsDeleted = false
            }
        );
    }

}
