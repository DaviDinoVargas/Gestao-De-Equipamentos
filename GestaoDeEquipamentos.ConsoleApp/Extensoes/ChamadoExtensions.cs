using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFuncionario;
using GestaoDeEquipamentos.ConsoleApp.ModuloUsuario;

namespace GestaoDeEquipamentos.ConsoleApp.Extensoes;

public static class ChamadoExtensions
{
    public static Chamado ParaEntidade(this FormularioChamadoViewModel viewModel,
        List<Equipamento> equipamentos,
        List<Usuario> usuarios,
        List<Funcionario> funcionarios)
    {
        var equipamento = equipamentos.FirstOrDefault(e => e.Id == viewModel.EquipamentoId);
        var usuario = usuarios.FirstOrDefault(u => u.Id == viewModel.UsuarioId);
        var funcionario = funcionarios.FirstOrDefault(f => f.Id == viewModel.FuncionarioResponsavelId);

        return new Chamado(
            viewModel.Titulo,
            viewModel.Descricao,
            equipamento,
            usuario,
            funcionario
        );
    }

    public static DetalhesChamadoViewModel ParaDetalhesVM(this Chamado chamado)
    {
        return new DetalhesChamadoViewModel(
            chamado.Id,
            chamado.Titulo,
            chamado.Descricao,
            chamado.Equipamento?.Nome ?? "N/A",
            chamado.Usuario?.Nome ?? "N/A",
            chamado.FuncionarioResponsavel?.Nome ?? "N/A",
            chamado.Status.ToString(),
            chamado.DataAbertura,
            chamado.DataFechamento,
            chamado.TempoDecorrido,
            chamado.Logs.Select(l => new LogChamadoViewModel(l.Data, l.Acao, l.Responsavel)).ToList()
        );
    }
}