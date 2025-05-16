using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.Extensoes;

public static class ChamadoExtensions
{
    public static Chamado ParaEntidade(this FormularioChamadoViewModel viewModel, List<Equipamento> equipamentos)
    {
        var equipamento = equipamentos.FirstOrDefault(e => e.Id == viewModel.EquipamentoId);
        return new Chamado(viewModel.Titulo, viewModel.Descricao, equipamento);
    }

    public static DetalhesChamadoViewModel ParaDetalhesVM(this Chamado chamado)
    {
        return new DetalhesChamadoViewModel(
            chamado.Id,
            chamado.Titulo,
            chamado.Descricao,
            chamado.Equipamento?.Nome ?? "N/A",
            chamado.DataAbertura,
            chamado.TempoDecorrido
        );
    }
}
