using Aluguel.API.Services;
using Aluguel.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace Aluguel.API.Controllers;

[ApiController]
[Route("aluguel")]
public class AluguelController : ControllerBase
{
    private readonly IAluguelService _AluguelService;
    private readonly ICiclistaService _CiclistaService;
    private readonly IEquipamentoService _EquipamentoService;

    public AluguelController(IAluguelService AluguelService, ICiclistaService ciclistaService, IEquipamentoService equipamentoService)
    {
        _AluguelService = AluguelService;
        _CiclistaService = ciclistaService;
        _EquipamentoService = equipamentoService;
    }

    [HttpPost]
    [Route("")]
    public IActionResult Create([FromBody] AluguelInsertViewModel aluguel)
    {
        if (_CiclistaService.Contains(aluguel.CiclistaId))
        {   
            var ciclista = _CiclistaService.GetCiclista(aluguel.CiclistaId);
            if (_AluguelService.GetAluguel(ciclista.Id) != null)
            {
                return BadRequest();
            }
            var tranca = _EquipamentoService.GetTranca(aluguel.TrancaId);
            if (tranca.BicicletaId == null)
            {
                return BadRequest();
            }
            var result = _AluguelService.CreateAluguel(ciclista, tranca);
            return Ok(result);
        }
        return BadRequest();
    }

    [HttpPost]
    [Route("/devolucao")]
    public IActionResult Retrieve([FromBody] AluguelInsertViewModel aluguel)
    {
        return Ok();
    }


}
