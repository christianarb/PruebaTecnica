

using AutoMapper;
using Netcore.Domain;

namespace Netcore.Application
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
    

      CreateMap<CreateRequestCarrera, Carrera>();
      CreateMap<UpdateRequestCarrera, Carrera>();

      CreateMap<CreateRequestFacultad, Facultad>();
      CreateMap<UpdateRequestFacultad, Facultad>();

     

    }
  }

}