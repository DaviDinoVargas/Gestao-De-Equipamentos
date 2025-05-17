using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.Extensoes;
using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.ModuloFuncionario;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.ConsoleApp.Controllers;

[Route("funcionarios")]
public class ControladorFuncionario : Controller
{
    private ContextoDados contextoDados;
    private IRepositorioFuncionario repositorioFuncionario;

    public ControladorFuncionario()
    {
        contextoDados = new ContextoDados(true);
        repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        return View(new CadastrarFuncionarioViewModel());
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarFuncionarioViewModel viewModel)
    {
        var funcionario = viewModel.ParaEntidade();
        repositorioFuncionario.CadastrarRegistro(funcionario);

        var notificacaoVM = new NotificacaoViewModel(
            "Funcionário Cadastrado!",
            $"O funcionário \"{funcionario.Nome}\" foi cadastrado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id)
    {
        var funcionario = repositorioFuncionario.SelecionarRegistroPorId(id);
        var viewModel = new EditarFuncionarioViewModel(funcionario);

        return View(viewModel);
    }

    [HttpPost("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id, EditarFuncionarioViewModel viewModel)
    {
        var funcionarioEditado = viewModel.ParaEntidade();
        repositorioFuncionario.EditarRegistro(id, funcionarioEditado);

        var notificacaoVM = new NotificacaoViewModel(
            "Funcionário Editado!",
            $"O funcionário \"{funcionarioEditado.Nome}\" foi atualizado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("excluir/{id:int}")]
    public IActionResult Excluir([FromRoute] int id)
    {
        var funcionario = repositorioFuncionario.SelecionarRegistroPorId(id);
        var viewModel = new ExcluirFuncionarioViewModel(id, funcionario.Nome);

        return View(viewModel);
    }

    [HttpPost("excluir/{id:int}")]
    public IActionResult ExcluirConfirmado([FromRoute] int id)
    {
        repositorioFuncionario.ExcluirRegistro(id);

        var notificacaoVM = new NotificacaoViewModel(
            "Funcionário Excluído!",
            "O funcionário foi excluído com sucesso."
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("visualizar")]
    public IActionResult Visualizar()
    {
        var funcionarios = repositorioFuncionario.SelecionarRegistros();
        var viewModel = new VisualizarFuncionariosViewModel(funcionarios);

        return View(viewModel);
    }
}