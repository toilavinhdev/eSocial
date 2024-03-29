using AutoMapper;
using eSocial.Application.Features.FeatureFriendRequest.Commands;
using eSocial.Application.Features.FeatureMessage.Commands;
using eSocial.Application.Features.FeatureUser.Commands;
using eSocial.Application.Features.FeatureUser.Responses;
using eSocial.Domain.FriendRequestAggregate;
using eSocial.Domain.MessageAggregate;
using eSocial.Domain.UserAggregate;

namespace eSocial.Application.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        /* User */
        CreateMap<CreateUserCommand, User>();
        CreateMap<User, GetMeResponse>();
        
        /* Friend Request */
        CreateMap<CreateFriendRequestCommand, FriendRequest>();
        
        /* Message */
        CreateMap<CreateMessageCommand, Message>();
    }
}