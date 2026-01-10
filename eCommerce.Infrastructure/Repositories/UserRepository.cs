using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.Context;

namespace eCommerce.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly DapperDbContext _dbContext;
    public UserRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();
        // Sql query to insert user into database can be added here using _dapperDb
        string query = """
                INSERT INTO public.users
                (user_id, email, person_name, gender, password)
                VALUES
                (@UserId, @Email, @PersonName, @Gender, @Password)
                """;
        int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);
        if (rowCountAffected > 0)
        {
            return user;
        }
        return null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query = """
        SELECT
            user_id AS "UserId",
            email,
            person_name AS "PersonName",
            gender,
            password
        FROM public.users
        WHERE email = @Email
          AND password = @Password
        LIMIT 1
    """;

        var user = await _dbContext.DbConnection
            .QueryFirstOrDefaultAsync<ApplicationUser>(
                query,
                new { Email = email, Password = password }
            );
        return user;
    }
}
