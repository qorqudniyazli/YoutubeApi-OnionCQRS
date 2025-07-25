using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Exceptions;

public class EmailAddressShouldBeValidException : BaseExceptions
{
    public EmailAddressShouldBeValidException() : base("Belə bir email adresi mövcud deyil!") { }
}
