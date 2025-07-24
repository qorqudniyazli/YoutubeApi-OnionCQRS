using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Exceptions;

public class RefreshTokenShouldNotBeExpiredException : BaseExceptions
{
    public RefreshTokenShouldNotBeExpiredException() : base("Yeniləmə token-in vaxtı bitib!") { }
}
