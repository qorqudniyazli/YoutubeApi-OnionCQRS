using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Products.Exceptions;

public class ProductTittleMustNotBeSameException : BaseExceptions
{
    public ProductTittleMustNotBeSameException() : base("Məhsul başlığı artıq var!") { }
}
