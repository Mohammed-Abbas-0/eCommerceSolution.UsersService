using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResponse?> Login(LoginRequest request)
    {
        ApplicationUser? response = await _userRepository.GetUserByEmailAndPassword(request.Email, request.Password);

        if (response is null)
        {
            return null;
        }

        return new AuthenticationResponse
        (
            UserId: response.UserId,
            Email: response.Email,
            PersonName: response.PersonName,
            Token: "",
            Gender: response.Gender,
            Success: true
        );
    }

    public async Task<AuthenticationResponse?> RegisterUser(RegisterRequest request)
    {
        ApplicationUser? applicationUser = await _userRepository.AddUser(new ApplicationUser
        {
            Email = request.Email,
            Password = request.Password,
            PersonName = request.PersonName,
            Gender = request.Gender.ToString()
        });

        return new AuthenticationResponse
        (
            UserId: applicationUser.UserId,
            Email: applicationUser.Email,
            PersonName: applicationUser.PersonName,
            Token: "token",
            Gender: applicationUser.Gender,
            Success: true
        );

    }
}
