using MediatR;
using System.ComponentModel;

namespace YoutubeApi.Application.Features.Auth.Command.Login;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
    [DefaultValue("niyazli2000@mail.ru")]
    public string Email { get; set; }
    [DefaultValue("qorqud010203.")]
    public string Password { get; set; }
}
