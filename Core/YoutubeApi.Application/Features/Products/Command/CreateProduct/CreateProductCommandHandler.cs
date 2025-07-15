using MediatR;
using Microsoft.AspNetCore.Http;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Features.Products.Rules;
using YoutubeApi.Application.Interfaces.AutoMapperInterface;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Products.Command.CreateProduct;

public class CreateProductCommandHandler : BaseHandler, IRequestHandler<CreateProductCommandRequest, Unit>
{
    private readonly ProductRoles productRoles;

    public CreateProductCommandHandler(ProductRoles productRoles, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        
        this.productRoles = productRoles;
    }
    public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

        await productRoles.ProductTittleMustNotBeSame(products, request.Title);

        Product product = new Product(request.Title, request.Description, request.BrandId, request.Price, request.Discount);

        await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
        if (await unitOfWork.SaveChangesAsync() > 0)
        {
            foreach (var categoryId in request.CategoryIds)
                await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new ProductCategory
                {
                    CategoryId = categoryId,
                    ProductId = product.Id
                });
            await unitOfWork.SaveChangesAsync();
        }

        return Unit.Value;

    }
}
