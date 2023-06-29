using Aluguel.API.Services;
using Aluguel.API.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace Aluguel.API.Controllers;

[ApiController]
[Route("ciclista")]
public class CiclistaController : ControllerBase
{

    private readonly ILogger<CiclistaController> _logger;

    private readonly ICiclistaService _CiclistaService;
    private readonly IAluguelService _AluguelService;


    public CiclistaController(ILogger<CiclistaController> logger, ICiclistaService CiclistaService, IAluguelService AluguelService)
    {
        _logger = logger;
        _CiclistaService = CiclistaService;
        _AluguelService = AluguelService;
    }


    [HttpPost]
    [Route("")]
    public IActionResult Create([FromBody] CiclistaInsertViewModel Ciclista)
    {
        if (_CiclistaService.IsEmailRegistered(Ciclista.Email))
        {
            return BadRequest();
        }
        _logger.LogInformation("Criando ciclista...");

        var result = _CiclistaService.CreateCiclista(Ciclista);
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult Get(int id)
    {
        if (_CiclistaService.Contains(id))
        {
            return Ok(_CiclistaService.GetCiclista(id));
        }
        return NotFound();
    }

    [HttpPost]
    [Route("{id}/ativar")]
    public IActionResult Activate (int id)
    {
        if (_CiclistaService.Contains(id))
        {
            _logger.LogInformation("Ativando ciclista...");
            var result = _CiclistaService.Activate(id);
            return Ok(result);
        }
        return NotFound();
    }

    [HttpGet]
    [Route("{id}/permiteAluguel")]
    public IActionResult CheckAluguel (int id)
    {
        if (_CiclistaService.Contains(id))
        {
            var result = _AluguelService.GetAluguelAtivo(id);
            if (result != null)
            {
                return Ok(false);
            }
            return Ok(true);
        }
        return NotFound();
    }

    [HttpGet]
    [Route("{id}/bicicletaAlugada")]
    public IActionResult GetBicicleta (int id)
    {
        if (_CiclistaService.Contains(id))
        {
            var ativo = _AluguelService.GetAluguelAtivo(id);
            if (ativo != null)
            {
                return Ok(ativo.BicicletaId);
            }
        }
        return Ok(id);
    }

    [HttpGet]
    [Route("existeEmail/{email}")]
    public bool CheckEmail(string email)
    {
        return _CiclistaService.IsEmailRegistered(email);
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Edit([FromBody] CiclistaEditViewModel CiclistaNovo, int id)
    {
        _logger.LogInformation("Alterando ciclista...");
        if (_CiclistaService.Contains(id))
        {
            var result = _CiclistaService.UpdateCiclista(CiclistaNovo, id);
            return Ok(result);
        }
        return NotFound();
    }

    [HttpGet]
    [Route("cartaoDeCredito/{id}")]
    public IActionResult GetCard(int id)
    {
        if (_CiclistaService.Contains(id))
        {
            var ciclista = _CiclistaService.GetCiclista(id);
            var result = ciclista.MeioDePagamento;
            return Ok(result);
        }
        return NotFound();
    }

    [HttpPut]
    [Route("cartaoDeCredito/{id}")]
    public IActionResult EditCard([FromBody] MeioDePagamentoViewModel cartaoNovo, int id)
    {
        _logger.LogInformation("Alterando cartão do ciclista...");
        if (_CiclistaService.Contains(id))
        {
            var result = _CiclistaService.UpdateCartao(cartaoNovo, id);
            return Ok(result);
        }
        return NotFound();
    }

}
