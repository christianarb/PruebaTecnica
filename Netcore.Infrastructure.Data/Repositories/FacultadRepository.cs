
using Dapper;
using Netcore.Domain;
using System.Data;

namespace Netcore.Infrastructure.Data
{


  public class FacultadRepository : IFacultadRepository
  {
    private DataContext _context;

    public FacultadRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Facultad>> GetAll()
    {
      using var connection = _context.CreateConnection();
      return await connection.QueryAsync<Facultad>(Variables.StoresProcedures.SP_FacultadGetAll);
    }

    public async Task<IEnumerable<Facultad>> GetAllDeleted()
    {
      using var connection = _context.CreateConnection();
      return await connection.QueryAsync<Facultad>(Variables.StoresProcedures.SP_FacultadGetAllDeleted);
    }

    public async Task<Facultad> GetById(int id)
    {
      using var connection = _context.CreateConnection();

      return await connection.QuerySingleOrDefaultAsync<Facultad>(Variables.StoresProcedures.SP_FacultadGetById, new { id });
    }



    public async Task<int> Create(Facultad item)
    {
      using var connection = _context.CreateConnection();

      var param = new DynamicParameters();
      param.Add("@nombre_facultad", item.nombre_facultad, DbType.String);
      param.Add("@codigo_facultad", item.codigo_facultad, DbType.String);
      param.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);
      await connection.ExecuteAsync(Variables.StoresProcedures.SP_FacultadCreated, param);
      return param.Get<int>("@id");
    }

    public async Task Update(Facultad item)
    {
      using var connection = _context.CreateConnection();

      var param = new DynamicParameters();
      param.Add("@id", item.id, DbType.Int32);
      param.Add("@nombre_facultad", item.nombre_facultad, DbType.String);
      param.Add("@codigo_facultad", item.codigo_facultad, DbType.String);

      await connection.ExecuteAsync(Variables.StoresProcedures.SP_FacultadUpdate, param);
    }

    public async Task Delete(int id_facultad_source, int id_facultad_destination)
    {
      using var connection = _context.CreateConnection();


      var param = new DynamicParameters();
      param.Add("@id_facultad_source", id_facultad_source, DbType.Int32);
      param.Add("@id_facultad_destination", id_facultad_destination, DbType.Int32);

      await connection.ExecuteAsync(Variables.StoresProcedures.SP_FacultadDelete, param);
    }
  }

}