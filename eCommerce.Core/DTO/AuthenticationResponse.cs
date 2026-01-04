namespace eCommerce.Core.DTO;

public record AuthenticationResponse
(
    Guid UserId,
    string? PersonName,
    string? Email,
    string? Token,
    string? Gender,
    bool Success
 )
{
    public AuthenticationResponse():this(default, default, default, default, default, default)
    {
    }

}
