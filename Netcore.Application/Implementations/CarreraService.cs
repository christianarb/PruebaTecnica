namespace Netcore.Application;

using AutoMapper;
using BCrypt.Net;
using Netcore.Application;
using Netcore.Domain;



public class CarreraService : ICarreraService
{
  private ICarreraRepository _CarreraRepository;
  private IFacultadRepository _FacultadRepository;
  private readonly IMapper _mapper;

  public CarreraService(
      ICarreraRepository CarreraRepository,
      IFacultadRepository FacultadRepository,
      IMapper mapper)
  {
    _CarreraRepository = CarreraRepository;
    _FacultadRepository = FacultadRepository;
    _mapper = mapper;
  }

  public async Task<IEnumerable<Carrera>> GetAll()
  {
    return await _CarreraRepository.GetAll();
  }

  public async Task<IEnumerable<Carrera>> GetAllDeleted()
  {
    return await _CarreraRepository.GetAllDeleted();
  }

  public async Task<Carrera> GetById(int id)
  {
    var Carrera = await _CarreraRepository.GetById(id);

    if (Carrera == null)
      throw new KeyNotFoundException("Carrera not found");

    return Carrera;
  }

  public async Task<int> Create(CreateRequestCarrera model)
  {
    // validate

    var Facultad = await _FacultadRepository.GetById(model.facultad.Value);

    if (Facultad == null)
      throw new KeyNotFoundException("Facultad not found");

    // map model to new Carrera object
    var Carrera = _mapper.Map<Carrera>(model);

    ;

    // save Carrera
   return await _CarreraRepository.Create(Carrera);
  }

  public async Task Update(int id, UpdateRequestCarrera model)
  {
    var Carrera = await _CarreraRepository.GetById(id);

    if (Carrera == null)
      throw new KeyNotFoundException("Carrera not found");


    var Facultad = await _FacultadRepository.GetById(model.facultad.Value);

    if (Facultad == null)
      throw new KeyNotFoundException("Facultad not found");

    // validate

    // copy model props to Carrera
    _mapper.Map(model, Carrera);

    // save Carrera

    Carrera.id = id;
    await _CarreraRepository.Update(Carrera);
  }

  public async Task Delete(int id)
  {

    var Carrera = await _CarreraRepository.GetById(id);

    if (Carrera == null)
      throw new KeyNotFoundException("Carrera source not found");


    await _CarreraRepository.Delete(id);
  }


}