using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.Extensoes;
using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.ModuloUsuario;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.ConsoleApp.Controllers;

[Route("usuarios")]
public class ControladorUsuario : Controller
{
    private ContextoDados contextoDados;
    private IRepositorioUsuario repositorioUsuario;

    public ControladorUsuario()
    {
        contextoDados = new ContextoDados(true);
        repositorioUsuario = new RepositorioUsuarioEmArquivo(contextoDados);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        return View(new CadastrarUsuarioViewModel());
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarUsuarioViewModel viewModel)
    {
        var usuario = viewModel.ParaEntidade();
        var erros = usuario.Validar();

        if (!string.IsNullOrEmpty(erros))
        {
            ViewBag.Erros = erros;
            return View(viewModel);
        }

        repositorioUsuario.CadastrarRegistro(usuario);

        var notificacaoVM = new NotificacaoViewModel(
            "Usuário Cadastrado!",
            $"O usuário \"{usuario.Nome}\" foi cadastrado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id)
    {
        var usuario = repositorioUsuario.SelecionarRegistroPorId(id);
        var viewModel = new EditarUsuarioViewModel(usuario);

        return View(viewModel);
    }

    [HttpPost("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id, EditarUsuarioViewModel viewModel)
    {
        var usuarioEditado = viewModel.ParaEntidade();
        var erros = usuarioEditado.Validar();

        if (!string.IsNullOrEmpty(erros))
        {
            ViewBag.Erros = erros;
            return View(viewModel);
        }

        repositorioUsuario.EditarRegistro(id, usuarioEditado);

        var notificacaoVM = new NotificacaoViewModel(
            "Usuário Editado!",
            $"O usuário \"{usuarioEditado.Nome}\" foi atualizado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("excluir/{id:int}")]
    public IActionResult Excluir([FromRoute] int id)
    {
        var usuario = repositorioUsuario.SelecionarRegistroPorId(id);
        var viewModel = new ExcluirUsuarioViewModel(id, usuario.Nome);

        return View(viewModel);
    }

    [HttpPost("excluir/{id:int}")]
    public IActionResult ExcluirConfirmado([FromRoute] int id)
    {
        repositorioUsuario.ExcluirRegistro(id);

        var notificacaoVM = new NotificacaoViewModel(
            "Usuário Excluído!",
            "O usuário foi excluído com sucesso."
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("visualizar")]
    public IActionResult Visualizar()
    {
        var usuarios = repositorioUsuario.SelecionarRegistros();
        var viewModel = new VisualizarUsuariosViewModel(usuarios);

        return View(viewModel);
    }
}