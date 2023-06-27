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
    private readonly ICiclistaService _CiclistaService;
    private readonly IEquipamentoService _EquipamentoService;

    public AluguelController(ILogger<AluguelController> logger, IAluguelService AluguelService, ICiclistaService ciclistaService, IEquipamentoService equipamentoService)
    {
        _logger = logger;
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
            if (_AluguelService.HasAluguelAtivo(ciclista.Id))
            {
                //TODO caso de uso enviar email com os dados do aluguel
                return BadRequest();
            }
            var tranca = _EquipamentoService.GetTranca(aluguel.TrancaId);
            if (tranca.BicicletaId == null)
            {
                return BadRequest();
            }
            //TODO Chamar serviço para validar cartão
            //TODO gerar cobrança
            //TODO conferir pagamento
            //TODO alterar status tranca e bicicleta
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
