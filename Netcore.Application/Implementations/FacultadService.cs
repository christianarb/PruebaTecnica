namespace Netcore.Application;

using AutoMapper;
using BCrypt.Net;
using Netcore.Application;
using Netcore.Domain;


public class FacultadService : IFacultadService
{
  private IFacultadRepository _FacultadRepository;
  private readonly IMapper _mapper;

  public FacultadService(
      IFacultadRepository FacultadRepository,
      IMapper mapper)
  {
    _FacultadRepository = FacultadRepository;
    _mapper = mapper;
  }

  public async Task<IEnumerable<Facultad>> GetAll()
  {
    return await _FacultadRepository.GetAll();
  }

  public async Task<IEnumerable<Facultad>> GetAllDeleted()
  {
    return await _FacultadRepository.GetAllDeleted();
  }

  public async Task<Facultad> GetById(int id)
  {
    var Facultad = await _FacultadRepository.GetById(id);

    if (Facultad == null)
      throw new KeyNotFoundException("Facultad not found");

    return Facultad;
  }

  public async Task<int> Create(CreateRequestFacultad model)
  {
    // validate


    // map model to new Facultad object
    var Facultad = _mapper.Map<Facultad>(model);

;

    // save Facultad
    return await _FacultadRepository.Create(Facultad);
  }

  public async Task Update(int id,UpdateRequestFacultad model)
  {
    var Facultad = await _FacultadRepository.GetById(id);

    if (Facultad == null)
      throw new KeyNotFoundException("Facultad not found");

    // validate
  
    // copy model props to Facultad
    _mapper.Map(model, Facultad);

    // save Facultad

    Facultad.id = id;
    await _FacultadRepository.Update(Facultad);
  }

  public async Task Delete(int id_facultad_source, int id_facultad_destination)
  {

    var Facultad = await _FacultadRepository.GetById(id_facultad_source);

    if (Facultad == null)
      throw new KeyNotFoundException("Facultad source not found");

    Facultad = await _FacultadRepository.GetById(id_facultad_destination);

    if (Facultad == null)
      throw new KeyNotFoundException("Facultad destination not found");

    await _FacultadRepository.Delete(id_facultad_source, id_facultad_destination);
  }

 
}