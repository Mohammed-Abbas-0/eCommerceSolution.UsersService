using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;
internal class ApplicationUserToUserDTOMappingProfile:Profile
{
    public ApplicationUserToUserDTOMappingProfile()
    {
        CreateMap<ApplicationUser, UserDTO>()
            .ForMember(idx => idx.UserId, src => src.MapFrom(e => e.UserId))
            .ForMember(idx => idx.Email, src => src.MapFrom(e => e.Email))
            .ForMember(idx => idx.Gender, src => src.MapFrom(e => e.Gender))
            .ForMember(idx => idx.PersonName, src => src.MapFrom(e => e.PersonName));
    }
}
