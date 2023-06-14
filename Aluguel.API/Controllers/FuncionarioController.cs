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

    public FuncionarioController(ILogger<FuncionarioController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }


    [HttpPost]
    [Route("")]
    public IActionResult Create([FromBody] FuncionarioInsertViewModel funcionario)
    {
        _logger.LogInformation("Criando funcionário...");

        try
        {
            var result = _mapper.Map<FuncionarioViewModel>(funcionario);
            return Ok(result);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("CreateFuncionario", "Erro ao criar funcionário!");
            _logger.LogError(ex, "Erro ao criar funcionário!");
            return BadRequest(ModelState);
        }

    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Edit([FromBody] FuncionarioEditViewModel funcionarioNovo, int id)
    {
        _logger.LogInformation("Alterando funcionário...");

        try
        {
            var funcionarioAntigo = FuncionarioService.GetFuncionario();
            var result = _mapper.Map<FuncionarioEditViewModel, FuncionarioViewModel>(funcionarioNovo, funcionarioAntigo);
            return Ok(result);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("EditFuncionario", "Erro ao alterar funcionário!");
            _logger.LogError(ex, "Erro ao alterar funcionário!");
            return BadRequest(ModelState);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation("Deletando funcionário...");

        try
        {
            var funcionario = FuncionarioService.GetFuncionario();
            funcionario.Habilitado = false;
            return Ok();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("DeleteFuncionario", "Erro ao deletar funcionário!");
            _logger.LogError(ex, "Erro ao deletar funcionário!");
            return BadRequest(ModelState);
        }
    }
}
