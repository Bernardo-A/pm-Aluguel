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

    private readonly IMapper _mapper;

    private readonly ICiclistaService _ciclistaService;

    public CiclistaController(ILogger<CiclistaController> logger, IMapper mapper, ICiclistaService ciclistaService)
    {
        _logger = logger;
        _mapper = mapper;
        _ciclistaService = ciclistaService;
    }


    [HttpPost]
    [Route("")]
    public IActionResult Create([FromBody] CiclistaInsertViewModel ciclista)
    {
        _logger.LogInformation("Criando ciclista...");
        var result = _mapper.Map<CiclistaViewModel>(ciclista);
        return Ok(result);
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Edit([FromBody] CiclistaEditViewModel ciclistaNovo, int id)
    {
        _logger.LogInformation("Alterando ciclista...");
        var ciclistaAntigo = _ciclistaService.GetCiclista();
        var result = _mapper.Map(ciclistaNovo, ciclistaAntigo); 
        result.Id = id;
        return Ok(result);
    }

    [HttpPost]
    [Route("{id}/ativar")]
    public IActionResult EnableCiclista([FromBody] string requisicaoId, int id)
    {
        _logger.LogInformation("Atualizando status...");
        var ciclista = _ciclistaService.GetCiclista();
        ciclista.Id = id;
        ciclista.EmailConfirmado = true;
        return Ok(ciclista);
    }

    [HttpPut]
    [Route("{id}/cartao")]
    public IActionResult EditCartao([FromBody] MeioDePagamentoViewModel meio, int id)
    {
        _logger.LogInformation("Atualizando cartao...");
        var ciclista = _ciclistaService.GetCiclista();
        ciclista.Id = id;
        ciclista.MeioDePagamento = meio;
        return Ok(ciclista);
    }
}
