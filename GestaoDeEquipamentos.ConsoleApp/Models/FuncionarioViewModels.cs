using GestaoDeEquipamentos.ConsoleApp.Extensoes;
using GestaoDeEquipamentos.ConsoleApp.ModuloFuncionario;

namespace GestaoDeEquipamentos.ConsoleApp.Models;

public class FormularioFuncionarioViewModel
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Departamento { get; set; }
}

public class CadastrarFuncionarioViewModel : FormularioFuncionarioViewModel { }

public class EditarFuncionarioViewModel : FormularioFuncionarioViewModel
{
    public int Id { get; set; }

    public EditarFuncionarioViewModel() { }

    public EditarFuncionarioViewModel(Funcionario funcionario)
    {
        Id = funcionario.Id;
        Nome = funcionario.Nome;
        Email = funcionario.Email;
        Telefone = funcionario.Telefone;
        Departamento = funcionario.Departamento;
    }
}

public class ExcluirFuncionarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ExcluirFuncionarioViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarFuncionariosViewModel
{
    public List<DetalhesFuncionarioViewModel> Registros { get; set; }

    public VisualizarFuncionariosViewModel(List<Funcionario> funcionarios)
    {
        Registros = funcionarios.Select(f => f.ParaDetalhesVM()).ToList();
    }
}

public class DetalhesFuncionarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Departamento { get; set; }

    public DetalhesFuncionarioViewModel(int id, string nome, string email, string telefone, string departamento)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Departamento = departamento;
    }

    public override string ToString()
    {
        return $"Id: {Id} - Nome: {Nome} - Departamento: {Departamento} - Email: {Email} - Telefone: {Telefone}";
    }
}