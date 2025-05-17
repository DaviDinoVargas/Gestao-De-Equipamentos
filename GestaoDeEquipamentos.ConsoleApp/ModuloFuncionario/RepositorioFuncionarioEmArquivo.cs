using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFuncionario;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFuncionario;

public class RepositorioFuncionarioEmArquivo : RepositorioBaseEmArquivo<Funcionario>, IRepositorioFuncionario
{
    public RepositorioFuncionarioEmArquivo(ContextoDados contexto) : base(contexto)
    {
    }

    protected override List<Funcionario> ObterRegistros()
    {
        return contexto.Funcionarios;
    }
}
