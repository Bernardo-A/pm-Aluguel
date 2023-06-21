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

    private readonly IMapper _mapper;

    private readonly IFuncionarioService _funcionarioService;

    public FuncionarioController(ILogger<FuncionarioController> logger, IMapper mapper, IFuncionarioService funcionarioService)
    {
        _logger = logger;
        _mapper = mapper;
        _funcionarioService = funcionarioService;
    }


    [HttpPost]
    [Route("")]
    public IActionResult Create([FromBody] FuncionarioInsertViewModel funcionario)
    {
        _logger.LogInformation("Criando funcionário...");

        var result = _mapper.Map<FuncionarioViewModel>(funcionario);
        return Ok(result);
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Edit([FromBody] FuncionarioEditViewModel funcionarioNovo, int id)
    {

        _logger.LogInformation("Alterando funcionário...");
        var funcionarioAntigo = _funcionarioService.GetFuncionario();
        var result = _mapper.Map<FuncionarioEditViewModel, FuncionarioViewModel>(funcionarioNovo, funcionarioAntigo);
        result.Id = id;
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation("Deletando funcionário...");

        var funcionario = _funcionarioService.GetFuncionario();
        funcionario.Habilitado = false;
        funcionario.Id = id;
        return Ok(funcionario);
    }
}
