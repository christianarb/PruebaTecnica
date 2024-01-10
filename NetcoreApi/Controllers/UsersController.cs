namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Users;
using WebApi.Services;

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
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _facultadService.GetById(id);
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRequestFacultad model)
    {
        await _facultadService.Create(model);
        return Ok(new { message = "Facultad created" });
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateRequestFacultad model)
    {
        await _facultadService.Update(model);
        return Ok(new { message = "Facultad updated" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _facultadService.Delete(id);
        return Ok(new { message = "Facultad deleted" });
    }
}