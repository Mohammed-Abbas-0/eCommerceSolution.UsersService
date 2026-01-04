namespace eCommerce.Core.DTO;

public record RegisterRequest(
    string? PersonName,
    string? Email,
    string? Password,
    GenderOptions Gender
    );
