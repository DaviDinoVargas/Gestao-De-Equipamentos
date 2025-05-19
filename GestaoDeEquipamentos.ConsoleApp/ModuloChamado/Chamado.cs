using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFuncionario;
using GestaoDeEquipamentos.ConsoleApp.ModuloUsuario;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public enum StatusChamado
{
    Aberto,
    Pendente,
    Fechado
}
public class TendenciaPorDia
{
    public int Abertos { get; set; }
    public int Fechados { get; set; }
}
public class LogChamado
{
    public DateTime Data { get; set; }
    public string Acao { get; set; }
    public string Responsavel { get; set; }

    public LogChamado(string acao, string responsavel)
    {
        Data = DateTime.Now;
        Acao = acao;
        Responsavel = responsavel;
    }
}

public class Chamado : EntidadeBase<Chamado>
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public Equipamento Equipamento { get; set; }
    public Usuario Usuario { get; set; }
    public Funcionario FuncionarioResponsavel { get; set; }
    public StatusChamado Status { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime? DataFechamento { get; set; }
    public List<LogChamado> Logs { get; set; }

    public int TempoDecorrido
    {
        get
        {
            TimeSpan diferencaTempo = (DataFechamento ?? DateTime.Now).Subtract(DataAbertura);
            return (int)Math.Ceiling(diferencaTempo.TotalDays);
        }
    }

    public Chamado()
    {
        Logs = new List<LogChamado>();
    }

    public Chamado(string titulo, string descricao, Equipamento equipamento, Usuario usuario, Funcionario funcionario) : this()
    {
        Titulo = titulo;
        Descricao = descricao;
        Equipamento = equipamento;
        Usuario = usuario;
        FuncionarioResponsavel = funcionario;
        Status = StatusChamado.Aberto;
        DataAbertura = DateTime.Now;

        Logs.Add(new LogChamado("Chamado criado", funcionario?.Nome ?? "Sistema"));
    }

    public void AtualizarStatus(StatusChamado novoStatus, Funcionario responsavel)
    {
        Status = novoStatus;

        if (novoStatus == StatusChamado.Fechado)
            DataFechamento = DateTime.Now;
        else
            DataFechamento = null; 

        Logs.Add(new LogChamado($"Status alterado para {novoStatus}", responsavel.Nome));
    }

    public override void AtualizarRegistro(Chamado chamadoAtualizado)
    {
        Titulo = chamadoAtualizado.Titulo;
        Descricao = chamadoAtualizado.Descricao;
        Equipamento = chamadoAtualizado.Equipamento;
        Usuario = chamadoAtualizado.Usuario;
        FuncionarioResponsavel = chamadoAtualizado.FuncionarioResponsavel;

        Logs.Add(new LogChamado("Chamado atualizado", chamadoAtualizado.FuncionarioResponsavel?.Nome ?? "Sistema"));
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Titulo))
            erros += "O campo 'Título' é obrigatório.\n";

        if (Titulo.Length < 3)
            erros += "O campo 'Título' precisa conter ao menos 3 caracteres.\n";

        if (string.IsNullOrWhiteSpace(Descricao))
            erros += "O campo 'Descrição' é obrigatório.\n";

        if (Equipamento == null)
            erros += "O campo 'Equipamento' é obrigatório.\n";

        if (Usuario == null)
            erros += "O campo 'Usuário' é obrigatório.\n";

        if (FuncionarioResponsavel == null)
            erros += "O campo 'Funcionário Responsável' é obrigatório.\n";

        return erros;
    }
    public void AtualizarStatus(StatusChamado novoStatus, string responsavel)
    {
        Status = novoStatus;

        if (novoStatus == StatusChamado.Fechado)
            DataFechamento = DateTime.Now;
        else
            DataFechamento = null;

        Logs.Add(new LogChamado($"Status alterado para {novoStatus}", responsavel));
    }
}