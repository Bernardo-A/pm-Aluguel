using Aluguel.API.Services;
using Aluguel.API.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace Aluguel.API.Controllers;

[ApiController]
[Route("funcionario")]
public class FuncionarioController : ControllerBase
{

    private readonly ILogger<FuncionarioController> _logger;

    private readonly IFuncionarioService _funcionarioService;


    public FuncionarioController(ILogger<FuncionarioController> logger, IFuncionarioService funcionarioService)
    {
        _logger = logger;
        _funcionarioService = funcionarioService;
    }


    [HttpPost]
    [Route("")]
    public IActionResult Create([FromBody] FuncionarioInsertViewModel funcionario)
    {
        _logger.LogInformation("Criando funcionário...");

        var result = _funcionarioService.CreateFuncionario(funcionario);
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult Get(int id)
    {
        if (_funcionarioService.Contains(id))
        {
            return Ok(_funcionarioService.GetFuncionario(id));
        }
        return NotFound();
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Edit([FromBody] FuncionarioEditViewModel funcionarioNovo, int id)
    {
        _logger.LogInformation("Alterando funcionário...");
        if (_funcionarioService.Contains(id))
        {
            var result = _funcionarioService.UpdateFuncionario(funcionarioNovo, id);
            return Ok(result);
        }
        return NotFound();
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation("Deletando funcionário...");
        if (_funcionarioService.Contains(id))
        {
            var funcionario = _funcionarioService.DeleteFuncionario(id);
            return Ok(funcionario);
        }
        return NotFound();
    }

    [HttpGet]
    [Route("")]
    public IActionResult GetAll()
    {
        if (_funcionarioService.IsEmpty())
        {
            return NotFound();
        }
        return Ok(_funcionarioService.GetAll());
    }

}
