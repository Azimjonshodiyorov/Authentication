using Auth.Application.Exceptions;
using Auth.Application.Security.Interfaces;
using Auth.Core.Entities;
using Auth.Core.Enum;
using Auth.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Auth.Application.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand ,Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly IRoleRepository _roleRepository;

    public RegisterCommandHandler(IUserRepository userRepository , IPasswordManager passwordManager , IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _roleRepository = roleRepository;
    }
    public async Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmailAsync(request.Email) is not null)
            throw new AlreadyExistException(nameof(User), request.Email);

        this._passwordManager.CreatePasswordHash(request.Password, out var hash, out var salt);
         var user = await this._userRepository.CreateAsync(
             new User
             {
                 Email = request.Email,
                 PasswordHash = hash,
                 PasswordSalt = salt,
                 Role = await this._roleRepository.GetRoleByValueAsync(RoleName.User) ??
                        new Role
                        {
                            RoleName = RoleName.User
                        },
                 FirstName = "Azimjon",
                 LastName = "Shodiyorov",
                 Age = 24,
             });
         return user.Id;
    }
}