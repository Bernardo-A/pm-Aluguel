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

        try
        {
            var result = _mapper.Map<CiclistaViewModel>(ciclista);
            return Ok(result);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("CreateCiclista", "Erro ao criar ciclista!");
            _logger.LogError(ex, "Erro ao criar ciclista!");
            return BadRequest(ModelState);
        }

    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Edit([FromBody] CiclistaEditViewModel ciclistaNovo, int id)
    {
        _logger.LogInformation("Alterando ciclista...");

        try
        {
            var ciclistaAntigo = CiclistaService.GetCiclista();
            var result = _mapper.Map<CiclistaEditViewModel, CiclistaViewModel>(ciclistaNovo, ciclistaAntigo);
            return Ok(result);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("EditCiclista", "Erro ao alterar ciclista!");
            _logger.LogError(ex, "Erro ao alterar ciclista!");
            return BadRequest(ModelState);
        }
    }


}
