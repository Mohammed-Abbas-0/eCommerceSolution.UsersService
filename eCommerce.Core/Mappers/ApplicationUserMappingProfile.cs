using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public class ApplicationUserMappingProfile:Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(idx => idx.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(idx => idx.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(idx => idx.PersonName, opt => opt.MapFrom(src => src.PersonName))
            .ForMember(idx => idx.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(idx => idx.Success, opt => opt.Ignore())
            .ForMember(idx => idx.Token, opt => opt.Ignore());
    }
}
