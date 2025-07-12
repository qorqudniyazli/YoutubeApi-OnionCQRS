using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Application.Interfaces.AutoMapperInterface;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Products.Command.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, Unit>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

        var map = mapper.Map<Product, UpdateProductCommandRequest>(request);

        var productCategories = await unitOfWork.GetReadRepository<ProductCategory>()
            .GetAllAsync(x => x.ProductId == product.Id);

        await unitOfWork.GetWriteRepository<ProductCategory>()
            .HardDeleteRangeAsync(productCategories);

        foreach (var categoryId in request.CategoryIds)
        {
            await unitOfWork.GetWriteRepository<ProductCategory>()
                .AddAsync(new ProductCategory
                {
                    CategoryId = categoryId,
                    ProductId = product.Id
                });
        }

        await unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
