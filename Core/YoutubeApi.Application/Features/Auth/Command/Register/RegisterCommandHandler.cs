﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Features.Auth.Rules;
using YoutubeApi.Application.Interfaces.AutoMapperInterface;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Auth.Command.Register;

public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
{
    private readonly AuthRoles authRoles;
    private readonly UserManager<User> userManager;
    private readonly RoleManager<Role> roleManager;

    public RegisterCommandHandler(AuthRoles authRoles, UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.authRoles = authRoles;
        this.userManager = userManager;
        this.roleManager = roleManager;
    }
    public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        await authRoles.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));
        User user = mapper.Map<User, RegisterCommandRequest>(request);
        user.UserName = request.Email;
        user.SecurityStamp = Guid.NewGuid().ToString();

        IdentityResult result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            if (!await roleManager.RoleExistsAsync("user"))
                await roleManager.CreateAsync(new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "user",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });

            await userManager.AddToRoleAsync(user, "user");
        }

        return Unit.Value;
    }
}
