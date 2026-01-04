using eCommerce.Core.DTO;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (loginRequest is null)
            {
                return BadRequest("Invalid login request.");
            }
            AuthenticationResponse? authenticationResponse = await _userService.Login(loginRequest);
            if (authenticationResponse is null || authenticationResponse.Success is false)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(authenticationResponse);

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (registerRequest is null)
            {
                return BadRequest("Invalid registration request.");
            }

            AuthenticationResponse? authenticationResponse = await _userService.RegisterUser(registerRequest);

            if (authenticationResponse is null || authenticationResponse.Success is false)
            {
                return BadRequest(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }
    }
}
