using Aluguel.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Aluguel.API.Controllers;

[ApiController]
[Route("[[ciclista]]")]
public class CiclistaController : ControllerBase
{
    private readonly ILogger<CiclistaController> _logger;

    public CiclistaController(ILogger<CiclistaController> logger)
    {
        _logger = logger;
    }

    public CiclistaController(MapperConfiguration config)
    {
        this.config = config;
    } 
    private MapperConfiguration config;

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> Create([FromBody] CiclistaInsertViewModel ciclista)
    {
        _logger.LogInformation("Criando ciclista...");
        try
        {
            var mapper = new Mapper(config);
            var result = mapper.Map<CiclistaViewModel>(ciclista);
            return Ok(result);
        } catch (Exception ex)
        {
            ModelState.AddModelError("CreateCiclista", "Erro ao criar ciclista!");
            return BadRequest(ModelState);
        }
        
    }
}