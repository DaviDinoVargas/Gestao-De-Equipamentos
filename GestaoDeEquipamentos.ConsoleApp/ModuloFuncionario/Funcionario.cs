using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFuncionario;

public class Funcionario : EntidadeBase<Funcionario>
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Departamento { get; set; }

    public Funcionario() { }

    public Funcionario(string nome, string email, string telefone, string departamento)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Departamento = departamento;
    }

    public override void AtualizarRegistro(Funcionario funcionarioAtualizado)
    {
        Nome = funcionarioAtualizado.Nome;
        Email = funcionarioAtualizado.Email;
        Telefone = funcionarioAtualizado.Telefone;
        Departamento = funcionarioAtualizado.Departamento;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo 'Nome' é obrigatório.\n";

        if (string.IsNullOrWhiteSpace(Email))
            erros += "O campo 'Email' é obrigatório.\n";

        if (string.IsNullOrWhiteSpace(Telefone))
            erros += "O campo 'Telefone' é obrigatório.\n";

        if (string.IsNullOrWhiteSpace(Departamento))
            erros += "O campo 'Departamento' é obrigatório.\n";

        return erros;
    }
}