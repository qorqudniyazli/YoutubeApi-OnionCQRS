using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products = await unitOfWork.GetReadRepository<Product>()
            .GetAllAsync();

        List<GetAllProductsQueryResponse> responses = new List<GetAllProductsQueryResponse>();

        foreach (var product in products)
            responses.Add(new GetAllProductsQueryResponse
            {
                Title = product.Title,
                Description = product.Description,
                Discount = product.Discount,
                Price = product.Price - (product.Price * product.Discount / 100)
            });

        return responses;

    }
}
