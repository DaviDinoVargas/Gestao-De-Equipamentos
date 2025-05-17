using GestaoDeEquipamentos.ConsoleApp.Extensoes;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFuncionario;
using GestaoDeEquipamentos.ConsoleApp.ModuloUsuario;

namespace GestaoDeEquipamentos.ConsoleApp.Models;

public abstract class FormularioChamadoViewModel
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int EquipamentoId { get; set; }
    public int UsuarioId { get; set; }
    public int FuncionarioResponsavelId { get; set; }
    public StatusChamado Status { get; set; }
    public List<SelecionarEquipamentoViewModel> EquipamentosDisponiveis { get; set; }
    public List<SelecionarUsuarioViewModel> UsuariosDisponiveis { get; set; }
    public List<SelecionarFuncionarioViewModel> FuncionariosDisponiveis { get; set; }

    protected FormularioChamadoViewModel()
    {
        EquipamentosDisponiveis = new List<SelecionarEquipamentoViewModel>();
        UsuariosDisponiveis = new List<SelecionarUsuarioViewModel>();
        FuncionariosDisponiveis = new List<SelecionarFuncionarioViewModel>();
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

public class SelecionarUsuarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public SelecionarUsuarioViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class SelecionarFuncionarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public SelecionarFuncionarioViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class CadastrarChamadoViewModel : FormularioChamadoViewModel
{
    public CadastrarChamadoViewModel() { }

    public CadastrarChamadoViewModel(List<Equipamento> equipamentos, List<Usuario> usuarios, List<Funcionario> funcionarios)
    {
        foreach (var equipamento in equipamentos)
            EquipamentosDisponiveis.Add(new SelecionarEquipamentoViewModel(equipamento.Id, equipamento.Nome));

        foreach (var usuario in usuarios)
            UsuariosDisponiveis.Add(new SelecionarUsuarioViewModel(usuario.Id, usuario.Nome));

        foreach (var funcionario in funcionarios)
            FuncionariosDisponiveis.Add(new SelecionarFuncionarioViewModel(funcionario.Id, funcionario.Nome));
    }
}

public class EditarChamadoViewModel : FormularioChamadoViewModel
{
    public int Id { get; set; }

    public EditarChamadoViewModel() { }

    public EditarChamadoViewModel(Chamado chamado, List<Equipamento> equipamentos, List<Usuario> usuarios, List<Funcionario> funcionarios)
    {
        Id = chamado.Id;
        Titulo = chamado.Titulo;
        Descricao = chamado.Descricao;
        EquipamentoId = chamado.Equipamento?.Id ?? 0;
        UsuarioId = chamado.Usuario?.Id ?? 0;
        FuncionarioResponsavelId = chamado.FuncionarioResponsavel?.Id ?? 0;
        Status = chamado.Status;

        foreach (var equipamento in equipamentos)
            EquipamentosDisponiveis.Add(new SelecionarEquipamentoViewModel(equipamento.Id, equipamento.Nome));

        foreach (var usuario in usuarios)
            UsuariosDisponiveis.Add(new SelecionarUsuarioViewModel(usuario.Id, usuario.Nome));

        foreach (var funcionario in funcionarios)
            FuncionariosDisponiveis.Add(new SelecionarFuncionarioViewModel(funcionario.Id, funcionario.Nome));
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
    public string NomeUsuario { get; set; }
    public string NomeFuncionarioResponsavel { get; set; }
    public string Status { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime? DataFechamento { get; set; }
    public int DiasEmAberto { get; set; }
    public List<LogChamadoViewModel> Logs { get; set; }

    public DetalhesChamadoViewModel(
        int id,
        string titulo,
        string descricao,
        string nomeEquipamento,
        string nomeUsuario,
        string nomeFuncionarioResponsavel,
        string status,
        DateTime dataAbertura,
        DateTime? dataFechamento,
        int diasEmAberto,
        List<LogChamadoViewModel> logs)
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        NomeEquipamento = nomeEquipamento;
        NomeUsuario = nomeUsuario;
        NomeFuncionarioResponsavel = nomeFuncionarioResponsavel;
        Status = status;
        DataAbertura = dataAbertura;
        DataFechamento = dataFechamento;
        DiasEmAberto = diasEmAberto;
        Logs = logs;
    }

    public override string ToString()
    {
        return $"Id: {Id} - Título: {Titulo} - Status: {Status} - Equipamento: {NomeEquipamento} " +
               $"- Usuário: {NomeUsuario} - Responsável: {NomeFuncionarioResponsavel} " +
               $"- Aberto em: {DataAbertura:d} - Dias em aberto: {DiasEmAberto}";
    }
}

public class LogChamadoViewModel
{
    public DateTime Data { get; set; }
    public string Acao { get; set; }
    public string Responsavel { get; set; }

    public LogChamadoViewModel(DateTime data, string acao, string responsavel)
    {
        Data = data;
        Acao = acao;
        Responsavel = responsavel;
    }

    public override string ToString()
    {
        return $"{Data:g} - {Acao} - Por: {Responsavel}";
    }
}
public class DetalhesCompletosChamadoViewModel
{
    public DetalhesChamadoViewModel Chamado { get; set; }
    public List<SelecionarEquipamentoViewModel> EquipamentosDisponiveis { get; set; }
    public List<SelecionarUsuarioViewModel> UsuariosDisponiveis { get; set; }
    public List<SelecionarFuncionarioViewModel> FuncionariosDisponiveis { get; set; }

    public DetalhesCompletosChamadoViewModel(
        DetalhesChamadoViewModel chamado,
        List<Equipamento> equipamentos,
        List<Usuario> usuarios,
        List<Funcionario> funcionarios)
    {
        Chamado = chamado;
        EquipamentosDisponiveis = equipamentos.Select(e => new SelecionarEquipamentoViewModel(e.Id, e.Nome)).ToList();
        UsuariosDisponiveis = usuarios.Select(u => new SelecionarUsuarioViewModel(u.Id, u.Nome)).ToList();
        FuncionariosDisponiveis = funcionarios.Select(f => new SelecionarFuncionarioViewModel(f.Id, f.Nome)).ToList();
    }
}