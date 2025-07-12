using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeApi.Application.Features.Products.Command.UpdateProduct;

public class UpdateProductCommandValidatior : AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductCommandValidatior()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithName("Id");

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
