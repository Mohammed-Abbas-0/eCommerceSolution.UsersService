using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository,IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AuthenticationResponse?> Login(LoginRequest request)
    {
        ApplicationUser? response = await _userRepository.GetUserByEmailAndPassword(request.Email, request.Password);

        if (response is null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(response) with { Success = true,Token = "token" };
    }

    public async Task<AuthenticationResponse?> RegisterUser(RegisterRequest request)
    {
        ApplicationUser? applicationUser = await _userRepository.AddUser(new ApplicationUser
        {
            Email = request.Email,
            Password = request.Password,
            PersonName = request.PersonName,
            Gender = request.Gender.ToString(),

        });
        if (applicationUser is null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(applicationUser);
    }
}
