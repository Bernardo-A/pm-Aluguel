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

    public CiclistaController(ILogger<CiclistaController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
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
        var ciclistaAntigo = CiclistaService.GetCiclista();
        var result = _mapper.Map<CiclistaEditViewModel, CiclistaViewModel>(ciclistaNovo, ciclistaAntigo);
        return Ok(result);
    }


}
