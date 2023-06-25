using Aluguel.API.Services;
using Aluguel.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace Aluguel.API.Controllers;

[ApiController]
[Route("aluguel")]
public class AluguelController : ControllerBase
{

    private readonly ILogger<AluguelController> _logger;

    private readonly IAluguelService _AluguelService;

    public AluguelController(ILogger<AluguelController> logger, IAluguelService AluguelService)
    {
        _logger = logger;
        _AluguelService = AluguelService;
    }

    [HttpPost]
    [Route("")]
    public IActionResult Create([FromBody] AluguelInsertViewModel aluguel)
    {
        if (_AluguelService.HasAluguelAtivo(aluguel.CiclistaId))
        {
            
            //TODO caso de uso enviar email com os dados do aluguel
            return BadRequest();
        }
        //TODO conferir se existe bicicleta na tranca e condições de uso
        //TODO gerar cobrança
        //TODO conferir pagamento
        var result = _AluguelService.CreateAluguel(aluguel);
        //TODO alterar status tranca e bicicleta
        return Ok(result);
    }

    [HttpPost]
    [Route("/devolucao")]
    public IActionResult Retrieve([FromBody] AluguelInsertViewModel aluguel)
    {
        return Ok();
    }


}
