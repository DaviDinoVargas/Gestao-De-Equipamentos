using GestaoDeEquipamentos.ConsoleApp.Extensoes;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.Models;

public abstract class FormularioChamadoViewModel
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int EquipamentoId { get; set; }
    public List<SelecionarEquipamentoViewModel> EquipamentosDisponiveis { get; set; }

    protected FormularioChamadoViewModel()
    {
        EquipamentosDisponiveis = new List<SelecionarEquipamentoViewModel>();
    }
}

public class SelecionarEquipamentoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public SelecionarEquipamentoViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class CadastrarChamadoViewModel : FormularioChamadoViewModel
{
    public CadastrarChamadoViewModel() { }

    public CadastrarChamadoViewModel(List<Equipamento> equipamentos)
    {
        foreach (var equipamento in equipamentos)
            EquipamentosDisponiveis.Add(new SelecionarEquipamentoViewModel(equipamento.Id, equipamento.Nome));
    }
}

public class EditarChamadoViewModel : FormularioChamadoViewModel
{
    public int Id { get; set; }

    public EditarChamadoViewModel() { }

    public EditarChamadoViewModel(Chamado chamado, List<Equipamento> equipamentos)
    {
        Id = chamado.Id;
        Titulo = chamado.Titulo;
        Descricao = chamado.Descricao;
        EquipamentoId = chamado.Equipamento.Id;

        foreach (var equipamento in equipamentos)
            EquipamentosDisponiveis.Add(new SelecionarEquipamentoViewModel(equipamento.Id, equipamento.Nome));
    }
}

public class ExcluirChamadoViewModel
{
    public int Id { get; set; }
    public string Titulo { get; set; }

    public ExcluirChamadoViewModel(int id, string titulo)
    {
        Id = id;
        Titulo = titulo;
    }
}

public class VisualizarChamadosViewModel
{
    public List<DetalhesChamadoViewModel> Registros { get; set; }

    public VisualizarChamadosViewModel(List<Chamado> chamados)
    {
        Registros = chamados.Select(c => c.ParaDetalhesVM()).ToList();
    }
}

public class DetalhesChamadoViewModel
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string NomeEquipamento { get; set; }
    public DateTime DataAbertura { get; set; }
    public int DiasEmAberto { get; set; }

    public DetalhesChamadoViewModel(int id, string titulo, string descricao, string nomeEquipamento, DateTime dataAbertura, int diasEmAberto)
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        NomeEquipamento = nomeEquipamento;
        DataAbertura = dataAbertura;
        DiasEmAberto = diasEmAberto;
    }

    public override string ToString()
    {
        return $"Id: {Id} - Título: {Titulo} - Equipamento: {NomeEquipamento} - Aberto em: {DataAbertura:d} - Dias em aberto: {DiasEmAberto}";
    }
}
