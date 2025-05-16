using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.Extensoes;
using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.ConsoleApp.Controllers;

[Route("chamados")]
public class ControladorChamado : Controller
{
    private ContextoDados contextoDados;
    private IRepositorioChamado repositorioChamado;
    private IRepositorioEquipamento repositorioEquipamento;

    public ControladorChamado()
    {
        contextoDados = new ContextoDados(true);
        repositorioChamado = new RepositorioChamadoEmArquivo(contextoDados);
        repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contextoDados);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var equipamentos = repositorioEquipamento.SelecionarRegistros();
        var viewModel = new CadastrarChamadoViewModel(equipamentos);

        return View(viewModel);
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarChamadoViewModel viewModel)
    {
        var equipamentos = repositorioEquipamento.SelecionarRegistros();
        var chamado = viewModel.ParaEntidade(equipamentos);

        repositorioChamado.CadastrarRegistro(chamado);

        var notificacaoVM = new NotificacaoViewModel(
            "Chamado Cadastrado!",
            $"O chamado \"{chamado.Titulo}\" foi aberto com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id)
    {
        var chamado = repositorioChamado.SelecionarRegistroPorId(id);
        var equipamentos = repositorioEquipamento.SelecionarRegistros();

        var viewModel = new EditarChamadoViewModel(chamado, equipamentos);

        return View(viewModel);
    }

    [HttpPost("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id, EditarChamadoViewModel viewModel)
    {
        var equipamentos = repositorioEquipamento.SelecionarRegistros();
        var chamadoEditado = viewModel.ParaEntidade(equipamentos);

        repositorioChamado.EditarRegistro(id, chamadoEditado);

        var notificacaoVM = new NotificacaoViewModel(
            "Chamado Editado!",
            $"O chamado \"{chamadoEditado.Titulo}\" foi atualizado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("excluir/{id:int}")]
    public IActionResult Excluir([FromRoute] int id)
    {
        var chamado = repositorioChamado.SelecionarRegistroPorId(id);
        var viewModel = new ExcluirChamadoViewModel(id, chamado.Titulo);

        return View(viewModel);
    }

    [HttpPost("excluir/{id:int}")]
    public IActionResult ExcluirConfirmado([FromRoute] int id)
    {
        repositorioChamado.ExcluirRegistro(id);

        var notificacaoVM = new NotificacaoViewModel(
            "Chamado Excluído!",
            "O chamado foi excluído com sucesso."
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("visualizar")]
    public IActionResult Visualizar()
    {
        var chamados = repositorioChamado.SelecionarRegistros();
        var viewModel = new VisualizarChamadosViewModel(chamados);

        return View(viewModel);
    }
}
