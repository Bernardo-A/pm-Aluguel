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


    public CiclistaController(ILogger<CiclistaController> logger, ICiclistaService CiclistaService)
    {
        _logger = logger;
        _CiclistaService = CiclistaService;
    }


    [HttpPost]
    [Route("")]
    public IActionResult Create([FromBody] CiclistaInsertViewModel Ciclista)
    {
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
    public IActionResult Active (int id)
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
        return Ok(id);
    }

    [HttpGet]
    [Route("{id}/bicicletaAlugada")]
    public IActionResult GetBicicleta (int id)
    {
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
    public IActionResult Edit([FromBody] MeioDePagamentoViewModel cartaoNovo, int id)
    {
        _logger.LogInformation("Alterando cartão do ciclista...");
        if (_CiclistaService.Contains(id))
        {
            var result = _CiclistaService.UpdateCartao(cartaoNovo, id);
            return Ok(result);
        }
        return NotFound();
    }
    

    //[HttpDelete]
    //[Route("{id}")]
    //public IActionResult Delete(int id)
    //{
    //    _logger.LogInformation("Deletando funcionário...");
    //    if (_CiclistaService.GetCiclista(id) == null)
    //    {
    //        return NotFound();
    //    }
    //    var Ciclista = _CiclistaService.DeleteCiclista(id);
    //    return Ok(Ciclista);
    //}
}
