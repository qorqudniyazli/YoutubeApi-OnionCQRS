using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Exceptions;

public class UserAlreadyExistException : BaseExceptions
{
    public UserAlreadyExistException() : base("Belə bir istifadəçi var!") { }
}

