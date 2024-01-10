
using System.Data;
using Dapper;
using global::Netcore.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Netcore.Infrastructure.Data
{
  public class DataContext
  {
    private DbSettings _dbSettings;

    public DataContext(IOptions<DbSettings> dbSettings)
    {
      _dbSettings = dbSettings.Value;
    }

    public IDbConnection CreateConnection()
    {
      var connectionString = $"Data Source={_dbSettings.Server}; Initial Catalog={_dbSettings.Database}; User Id={_dbSettings.UserId}; Password={_dbSettings.Password}; TrustServerCertificate=true";
      return new SqlConnection(connectionString);
    }


  }
}