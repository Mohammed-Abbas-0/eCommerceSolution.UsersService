using System.Data;

namespace eCommerce.Infrastructure.Context;

public class DapperDbContext
{
    public IDbConnection DbConnection { get; }

    public DapperDbContext(IDbConnection dbConnection)
    {
        DbConnection = dbConnection;
    }
}
