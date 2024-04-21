using Auth.Application.Commands.Register;
using Auth.Core.Entities;
using AutoMapper;

namespace Auth.Application.AutoMapperProfile;

public class AotoMapper : Profile
{
    public AotoMapper()
    {
        CreateMap<User, RegisterCommand>();
    }
}