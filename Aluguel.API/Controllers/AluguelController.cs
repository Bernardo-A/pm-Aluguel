using Aluguel.API.Services;
using Aluguel.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace Aluguel.API.Controllers;

[ApiController]
[Route("aluguel")]
public class AluguelController : ControllerBase
{
    private readonly IAluguelService _AluguelService;

    public AluguelController(IAluguelService AluguelService)
    {
        _AluguelService = AluguelService;
    }

    [HttpPost]
    [Route("")]
    public IActionResult Create([FromBody] AluguelInsertViewModel aluguel)
    {
        try 
        {
            var result = _AluguelService.CreateAluguel(aluguel);
            return Ok(result);
        }catch { return BadRequest(); }
        
    }

    [HttpPost]
    [Route("/devolucao")]
    public IActionResult Retrieve([FromBody] AluguelRetrieveViewModel aluguel)
    {
        var result = _AluguelService.Devolver(aluguel);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }


}
