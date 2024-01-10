namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using Netcore.Application;
using System.Net;


[ApiController]
[Route("[controller]")]
public class FacultadController : ControllerBase
{
  private IFacultadService _facultadService;

  public FacultadController(IFacultadService facultadService)
  {
    _facultadService = facultadService;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var items = await _facultadService.GetAll();
    return Ok(new { data = items, StatusCode = (int)HttpStatusCode.OK });
  }


  [HttpGet]
  [Route("GetAllDeleted")]
  public async Task<IActionResult> GetAllDeleted()
  {
    var items = await _facultadService.GetAllDeleted();
    return Ok(new { data = items, StatusCode = (int)HttpStatusCode.OK });
  }


  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    var item = await _facultadService.GetById(id);
    return Ok(new { data = item, StatusCode = (int)HttpStatusCode.OK });
  }

  [HttpPost]
  public async Task<IActionResult> Create(CreateRequestFacultad model)
  {
   var id =  await _facultadService.Create(model);
    return Ok(new { id = id, message = "Facultad created", StatusCode = (int)HttpStatusCode.OK });
  }

  [HttpPost]
  [Route("Update")]
  public async Task<IActionResult> Update(UpdateRequestFacultad model)
  {
    await _facultadService.Update(model.id.Value, model);
    return Ok(new { message = "Facultad updated", StatusCode = (int)HttpStatusCode.OK });
  }

  [HttpDelete("{id_facultad_source}/{id_facultad_destination}")]
  public async Task<IActionResult> Delete(int id_facultad_source, int id_facultad_destination)
  {
    await _facultadService.Delete(id_facultad_source, id_facultad_destination);
    return Ok(new { message = "Facultad deleted", StatusCode = (int)HttpStatusCode.OK });
  }
}