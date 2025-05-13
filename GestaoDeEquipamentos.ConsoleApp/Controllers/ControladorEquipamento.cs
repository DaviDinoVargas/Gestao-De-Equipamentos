using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GestaoDeEquipamentos.ConsoleApp.Controllers
{
    [Route("equipamentos")]
    public class ControladorEquipamento : Controller
    {
        [HttpGet("cadastrar")]
        public IActionResult ExibirFormularioCadastro()
        {
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contexto);

            List<Fabricante> fabricantes = repositorioFabricante.SelecionarRegistros();
            ViewBag.Fabricantes = fabricantes;

            return View("Cadastrar");
        }

        [HttpPost("cadastrar")]
        public IActionResult CadastrarEquipamento(
            [FromForm] string nome,
            [FromForm] decimal precoAquisicao,
            [FromForm] DateTime dataFabricacao,
            [FromForm] int fabricanteId)
        {
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioEquipamento repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);
            IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contexto);

            Fabricante fabricante = repositorioFabricante.SelecionarRegistroPorId(fabricanteId);
            Equipamento equipamento = new Equipamento(nome, precoAquisicao, dataFabricacao, fabricante);

            repositorioEquipamento.CadastrarRegistro(equipamento);

            ViewBag.Mensagem = $"O equipamento \"{equipamento.Nome}\" foi cadastrado com sucesso!";
            return View("Notificacao");
        }

        [HttpGet("editar/{id:int}")]
        public IActionResult ExibirFormularioEdicao([FromRoute] int id)
        {
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioEquipamento repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);
            IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contexto);

            Equipamento equipamento = repositorioEquipamento.SelecionarRegistroPorId(id);
            List<Fabricante> fabricantes = repositorioFabricante.SelecionarRegistros();

            ViewBag.Equipamento = equipamento;
            ViewBag.Fabricantes = fabricantes;

            return View("Editar");
        }

        [HttpPost("editar/{id:int}")]
        public IActionResult EditarEquipamento(
            [FromRoute] int id,
            [FromForm] string nome,
            [FromForm] decimal precoAquisicao,
            [FromForm] DateTime dataFabricacao,
            [FromForm] int fabricanteId)
        {
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioEquipamento repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);
            IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contexto);

            Fabricante fabricante = repositorioFabricante.SelecionarRegistroPorId(fabricanteId);
            Equipamento equipamentoAtualizado = new Equipamento(nome, precoAquisicao, dataFabricacao, fabricante);

            repositorioEquipamento.EditarRegistro(id, equipamentoAtualizado);

            ViewBag.Mensagem = $"O equipamento \"{equipamentoAtualizado.Nome}\" foi editado com sucesso!";
            return View("Notificacao");
        }

        [HttpGet("excluir/{id:int}")]
        public IActionResult ExibirFormularioExclusao([FromRoute] int id)
        {
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioEquipamento repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);

            Equipamento equipamento = repositorioEquipamento.SelecionarRegistroPorId(id);
            ViewBag.Equipamento = equipamento;

            return View("Excluir");
        }

        [HttpPost("excluir/{id:int}")]
        public IActionResult ExcluirEquipamento([FromRoute] int id)
        {
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioEquipamento repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);

            repositorioEquipamento.ExcluirRegistro(id);

            ViewBag.Mensagem = "O equipamento foi excluído com sucesso!";
            return View("Notificacao");
        }

        [HttpGet("visualizar")]
        public IActionResult VisualizarEquipamentos()
        {
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioEquipamento repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);

            List<Equipamento> equipamentos = repositorioEquipamento.SelecionarRegistros();
            ViewBag.Equipamentos = equipamentos;

            return View("Visualizar");
        }
    }
}
