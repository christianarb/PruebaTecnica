using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netcore.Domain
{
  public interface IFacultadRepository
  {
    Task<IEnumerable<Facultad>> GetAll();
    Task<Facultad> GetById(int id);
    Task<int> Create(Facultad item);
    Task Update(Facultad item);
    Task Delete(int id_facultad_source, int id_facultad_destination);

    Task<IEnumerable<Facultad>> GetAllDeleted();

  }
}
