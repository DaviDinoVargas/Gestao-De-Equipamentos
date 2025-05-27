using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using Microsoft.AspNetCore.Mvc;
using static GestaoDeEquipamentos.ConsoleApp.Models.DashboardViewModel;

namespace GestaoDeEquipamentos.ConsoleApp.Controllers;

[Route("/")]
public class ControladorInicial : Controller
{
    private ContextoDados contextoDados;
    private IRepositorioChamado repositorioChamado;

    public ControladorInicial()
    {
        contextoDados = new ContextoDados(true);
        repositorioChamado = new RepositorioChamadoEmArquivo(contextoDados);
    }

    public IActionResult PaginaInicial()
    {
        var chamados = repositorioChamado.SelecionarRegistros() ?? new List<Chamado>();

        var agora = DateTime.Now;
        var trintaDiasAtras = agora.AddDays(-30);

        var fechadosUltimos30Dias = chamados
            .Where(c => c.Status == StatusChamado.Fechado && c.DataFechamento >= trintaDiasAtras)
            .ToList();

        var tendenciaResolucao = new Dictionary<string, TendenciaResolucaoData>();
        for (int i = 29; i >= 0; i--)
        {
            var data = agora.AddDays(-i).Date;
            var dataStr = data.ToString("dd-MM-yyyy");

            var abertos = chamados.Count(c => c.DataAbertura.Date == data);
            var fechados = chamados.Count(c => c.DataFechamento.HasValue && c.DataFechamento.Value.Date == data);

            tendenciaResolucao[dataStr] = new TendenciaResolucaoData
            {
                Abertos = abertos,
                Fechados = fechados
            };
        }
        var logsRecentes = chamados
                .SelectMany(c => c.Logs)
                .OrderByDescending(l => l.Data)
                .Take(10)
                .Select(l => new LogChamadoViewModel(l.Data, l.Acao, l.Responsavel))
                .ToList();

        var chamadosCriticos = chamados
                .Where(c => c.Status != StatusChamado.Fechado)
                .OrderByDescending(c => c.TempoDecorrido)
                .Take(10)
                .Select(c => new ChamadoCriticoViewModel
                {
                    Titulo = c.Titulo,
                    NomeEquipamento = c.Equipamento?.Nome ?? "N/A",
                    DiasEmAberto = c.TempoDecorrido,
                    NomeFuncionarioResponsavel = c.FuncionarioResponsavel?.Nome ?? "N/A"
                }).ToList();

        var mediaDias = chamados.Any() ? chamados.Average(c => c.TempoDecorrido) : 0;


        var chamadosFechados = chamados
    .Where(c => c.Status == StatusChamado.Fechado && c.DataFechamento.HasValue)
    .ToList();

        var mediaResolucao = chamadosFechados.Any()
            ? chamadosFechados.Average(c => (c.DataFechamento.Value - c.DataAbertura).TotalDays)
            : 0;

        var viewModel = new DashboardViewModel
        {
            TotalChamados = chamados.Count,
            ChamadosAbertos = chamados.Count(c => c.Status == StatusChamado.Aberto),
            ChamadosPendentes = chamados.Count(c => c.Status == StatusChamado.Pendente),
            ChamadosFechadosUltimos30Dias = fechadosUltimos30Dias.Count,
            MediaDiasEmAberto = mediaDias,

            DistribuicaoPorStatus = new Dictionary<string, int>
        {
            { "Aberto", chamados.Count(c => c.Status == StatusChamado.Aberto) },
            { "Pendente", chamados.Count(c => c.Status == StatusChamado.Pendente) },
            { "Fechado", chamados.Count(c => c.Status == StatusChamado.Fechado) }
        },

            TendenciaResolucao = tendenciaResolucao,
            ChamadosCriticos = chamadosCriticos,

            TaxaResolucao = chamados.Any()
                ? chamados.Count(c => c.Status == StatusChamado.Fechado) / (double)chamados.Count
                : 0,
            TempoMedioResolucao = mediaResolucao,

            ChamadosPorResponsavel = chamados
                .GroupBy(c => c.FuncionarioResponsavel?.Nome ?? "Não atribuído")
                .ToDictionary(g => g.Key, g => g.Count()),
            LogsRecentes = logsRecentes,

            ChamadosPorEquipamento = chamados
            .Where(c => c.Equipamento != null)
            .GroupBy(c => c.Equipamento.Nome)
            .OrderByDescending(g => g.Count())
            .ToDictionary(g => g.Key, g => g.Count())
        };

        return View("PaginaInicial", viewModel);
    }
}
