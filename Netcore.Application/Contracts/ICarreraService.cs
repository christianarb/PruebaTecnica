using Netcore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netcore.Application
{
  public interface ICarreraService
  {
    Task<IEnumerable<Carrera>> GetAll();
    Task<Carrera> GetById(int id);
    Task<int> Create(CreateRequestCarrera model);
    Task Update(int id, UpdateRequestCarrera model);
    Task Delete(int id);

    Task<IEnumerable<Carrera>> GetAllDeleted();
  }
}
