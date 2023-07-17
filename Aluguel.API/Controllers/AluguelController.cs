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
    public async Task<IActionResult> Create([FromBody] AluguelInsertViewModel aluguel)
    {
        try 
        {
            var result = await _AluguelService.CreateAluguel(aluguel);
            if (result == null) { return BadRequest(); }
            return Ok(result);
        }catch { return BadRequest(); }
        
    }

    [HttpPost]
    [Route("/devolucao")]
    public async Task<IActionResult> Retrieve([FromBody] AluguelRetrieveViewModel aluguel)
    {
        try
        {
            var result = await _AluguelService.Devolver(aluguel);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        } catch
        {
            return BadRequest();
        }
    }


}
