using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.Extensoes;
using GestaoDeEquipamentos.ConsoleApp.Models;
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
        public IActionResult ExibirFormularioCadastroEquipamento()
        {
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contexto);

            List<Fabricante> fabricantes = repositorioFabricante.SelecionarRegistros();

            CadastrarEquipamentoViewModel cadastrarVM = new CadastrarEquipamentoViewModel
            {
                Fabricantes = fabricantes
            };

            return View("Cadastrar", cadastrarVM);

        }

        [HttpPost("cadastrar")]
        public IActionResult CadastrarEquipamento(CadastrarEquipamentoViewModel cadastrarVM)
        {
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contexto);

            cadastrarVM.Fabricante = repositorioFabricante.SelecionarRegistroPorId(cadastrarVM.FabricanteId);

            Equipamento novoEquipamento = cadastrarVM.ParaEntidade();

            IRepositorioEquipamento repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);
            repositorioEquipamento.CadastrarRegistro(novoEquipamento);


            ViewBag.Mensagem = $"O equipamento \"{cadastrarVM.Nome}\" foi cadastrado com sucesso!";

            return View("Notificacao");
        }

        [HttpGet("editar/{id:int}")]
        public IActionResult ExibirFormularioEdicaoEquipamento([FromRoute] int id)
        {
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioEquipamento repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);

            Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarRegistroPorId(id);

            IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contexto);

            List<Fabricante> fabricantes = repositorioFabricante.SelecionarRegistros();


            EditarEquipamentoViewModel editarVM = new EditarEquipamentoViewModel(
                id,
                equipamentoSelecionado.Nome,
                equipamentoSelecionado.Fabricante, 
                equipamentoSelecionado.PrecoAquisicao,
                equipamentoSelecionado.DataFabricacao
            )
            {
                Fabricantes = fabricantes 
            };

            return View("Editar", editarVM);
        }

        [HttpPost("editar/{id:int}")]
        public IActionResult EditarEquipamento([FromRoute] int id, EditarEquipamentoViewModel editarVM)
        {
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioEquipamento repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);

            Equipamento equipamentoAtualizado = editarVM.ParaEntidade();

            repositorioEquipamento.EditarRegistro(id, equipamentoAtualizado);

            ViewBag.Mensagem = $"O equipamento \"{editarVM.Nome}\" foi editado com sucesso!";

            return View("Notificacao");
        }

        [HttpGet("excluir/{id:int}")]
        public IActionResult ExibirFormularioExclusaoEquipamento([FromRoute] int id)
        {
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioEquipamento repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);

            Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarRegistroPorId(id);
            ExcluirEquipamentoViewModel excluirVM = new ExcluirEquipamentoViewModel(
                equipamentoSelecionado.Id,
                equipamentoSelecionado.Nome
            );

            return View("Excluir", excluirVM);
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

            VisualizarEquipamentosViewModel visualizarVM = new VisualizarEquipamentosViewModel(equipamentos);

            return View("Visualizar", visualizarVM);
        }
    }
}
