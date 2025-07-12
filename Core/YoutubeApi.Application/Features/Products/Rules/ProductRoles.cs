using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Features.Products.Exceptions;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Products.Rules;

public class ProductRoles : BaseRules
{
    public Task ProductTittleMustNotBeSame(IList<Product> products , string requestTitle)
    {
        if(products.Any(x => x.Title == requestTitle)) throw new ProductTittleMustNotBeSameException();
        return Task.CompletedTask;
    }
}
