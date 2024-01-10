namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using Netcore.Application;
using System.Net;


[ApiController]
[Route("[controller]")]
public class CarreraController : ControllerBase
{
  private ICarreraService _CarreraService;

  public CarreraController(ICarreraService CarreraService)
  {
    _CarreraService = CarreraService;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var items = await _CarreraService.GetAll();
    return Ok(new { data = items, StatusCode = (int)HttpStatusCode.OK });
  }


  [HttpGet]
  [Route("GetAllDeleted")]
  public async Task<IActionResult> GetAllDeleted()
  {
    var items = await _CarreraService.GetAllDeleted();
    return Ok(new { data = items, StatusCode = (int)HttpStatusCode.OK });
  }


  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    var item = await _CarreraService.GetById(id);
    return Ok(new { data = item, StatusCode = (int)HttpStatusCode.OK });
  }

  [HttpPost]
  public async Task<IActionResult> Create(CreateRequestCarrera model)
  {
    var id = await _CarreraService.Create(model);
    return Ok(new { id =  id, message = "Carrera created", StatusCode = (int)HttpStatusCode.OK });
  }

  [HttpPost]
  [Route("Update")]
  public async Task<IActionResult> Update(UpdateRequestCarrera model)
  {
    await _CarreraService.Update(model.id.Value, model);
    return Ok(new { message = "Carrera updated", StatusCode = (int)HttpStatusCode.OK });
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    await _CarreraService.Delete(id);
    return Ok(new { message = "Carrera deleted", StatusCode = (int)HttpStatusCode.OK});
  }
}