﻿using FluentValidation;

namespace YoutubeApi.Application.Features.Products.Command.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithName("Başlıq");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithName("Açıqlama");

        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithName("Marka");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithName("Qiymət");

        RuleFor(x => x.Discount)
            .GreaterThanOrEqualTo(0)
            .WithName("Endirim Faizi");

        RuleFor(x => x.CategoryIds)
            .NotEmpty()
            .WithName("Kateqoriyalar")
            .Must(categories => categories.Any());
    }
}
