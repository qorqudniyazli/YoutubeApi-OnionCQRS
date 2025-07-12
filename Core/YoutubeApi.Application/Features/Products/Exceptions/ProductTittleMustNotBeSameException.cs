using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Products.Exceptions;

public class ProductTittleMustNotBeSameException : BaseExceptions
{
    public ProductTittleMustNotBeSameException() : base("Məhsul başlığı artıq var!") { }
}
