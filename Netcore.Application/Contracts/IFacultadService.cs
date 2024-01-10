using Netcore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netcore.Application
{

  public interface IFacultadService
  {
    Task<IEnumerable<Facultad>> GetAll();
    Task<Facultad> GetById(int id);
    Task<int> Create(CreateRequestFacultad model);
    Task Update(int id, UpdateRequestFacultad model);
    Task Delete(int id_facultad_source, int id_facultad_destination);

    Task<IEnumerable<Facultad>> GetAllDeleted();
  }
}
