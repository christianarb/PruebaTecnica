using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netcore.Domain
{
  public interface ICarreraRepository
  {
    Task<IEnumerable<Carrera>> GetAll();
    Task<Carrera> GetById(int id);
    Task<int> Create(Carrera item);
    Task Update(Carrera item);
    Task Delete(int id_Carrera);

    Task<IEnumerable<Carrera>> GetAllDeleted();

  }
}
