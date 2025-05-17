using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.ModuloFuncionario;

namespace GestaoDeEquipamentos.ConsoleApp.Extensoes;

public static class FuncionarioExtensions
{
    public static Funcionario ParaEntidade(this FormularioFuncionarioViewModel viewModel)
    {
        return new Funcionario(
            viewModel.Nome,
            viewModel.Email,
            viewModel.Telefone,
            viewModel.Departamento
        );
    }

    public static DetalhesFuncionarioViewModel ParaDetalhesVM(this Funcionario funcionario)
    {
        return new DetalhesFuncionarioViewModel(
            funcionario.Id,
            funcionario.Nome,
            funcionario.Email,
            funcionario.Telefone,
            funcionario.Departamento
        );
    }
}