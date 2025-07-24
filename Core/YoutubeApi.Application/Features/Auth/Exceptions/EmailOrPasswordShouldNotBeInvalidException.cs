using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Exceptions;

public class EmailOrPasswordShouldNotBeInvalidException : BaseExceptions
{
    public EmailOrPasswordShouldNotBeInvalidException() : base("İstifadəçi adı və ya yanlışdır!") { }
}

