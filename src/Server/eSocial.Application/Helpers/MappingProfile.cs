using AutoMapper;
using eSocial.Application.Features.FeatureUser.Commands;
using eSocial.Application.Features.FeatureUser.Responses;
using eSocial.Domain.UserAggregate;

namespace eSocial.Application.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User
        CreateMap<CreateUserCommand, User>();
        CreateMap<User, GetMeResponse>();
    }
}