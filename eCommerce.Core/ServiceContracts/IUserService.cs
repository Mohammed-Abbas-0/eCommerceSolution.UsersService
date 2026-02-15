using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;

public interface IUserService
{
    /// <summary>
    /// Defines a method for user login.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequest request);

    /// <summary>
    /// Defines a method for user registration.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> RegisterUser(RegisterRequest request);

    /// <summary>
    /// Defines a method to retrieve a user by their unique user ID.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<UserDTO> GetUserByUserId(Guid? userId);


}
