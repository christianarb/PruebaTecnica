
using Dapper;
using Netcore.Domain;
using System.Data;


namespace Netcore.Infrastructure.Data
{


  public class CarreraRepository : ICarreraRepository
  {
    private DataContext _context;

    public CarreraRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Carrera>> GetAll()
    {
      using var connection = _context.CreateConnection();
      return await connection.QueryAsync<Carrera>(Variables.StoresProcedures.SP_CarreraGetAll);
    }

    public async Task<IEnumerable<Carrera>> GetAllDeleted()
    {
      using var connection = _context.CreateConnection();
      return await connection.QueryAsync<Carrera>(Variables.StoresProcedures.SP_CarreraGetAllDeleted);
    }

    public async Task<Carrera> GetById(int id)
    {
      using var connection = _context.CreateConnection();

      return await connection.QuerySingleOrDefaultAsync<Carrera>(Variables.StoresProcedures.SP_CarreraGetById, new { id });
    }



    public async Task<int> Create(Carrera item)
    {
      using var connection = _context.CreateConnection();

      var param = new DynamicParameters();
      param.Add("@nombre_Carrera", item.nombre_carrera, DbType.String);
      param.Add("@codigo_Carrera", item.codigo_carrera, DbType.String);
      param.Add("@facultad", item.facultad, DbType.Int32);

      param.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);
      await connection.ExecuteAsync(Variables.StoresProcedures.SP_CarreraCreated, param);

      return param.Get<int>("@id");
    }

    public async Task Update(Carrera item)
    {
      using var connection = _context.CreateConnection();

      var param = new DynamicParameters();
      param.Add("@id", item.id, DbType.Int32);
      param.Add("@nombre_Carrera", item.nombre_carrera, DbType.String);
      param.Add("@codigo_Carrera", item.codigo_carrera, DbType.String);
      param.Add("@facultad", item.facultad, DbType.Int32);

      await connection.ExecuteAsync(Variables.StoresProcedures.SP_CarreraUpdate, param);
    }

    public async Task Delete(int id_Carrera)
    {
      using var connection = _context.CreateConnection();

      var param = new DynamicParameters();
      param.Add("@id", id_Carrera, DbType.Int32);

      await connection.ExecuteAsync(Variables.StoresProcedures.SP_CarreraDelete, param);
    }
  }

}