using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.ModuloUsuario;

namespace GestaoDeEquipamentos.ConsoleApp.Extensoes;

public static class UsuarioExtensions
{
    public static Usuario ParaEntidade(this FormularioUsuarioViewModel viewModel)
    {
        return new Usuario(
            viewModel.Nome,
            viewModel.Email,
            viewModel.Telefone,
            viewModel.Documento,
            viewModel.TipoDocumento
        );
    }

    public static DetalhesUsuarioViewModel ParaDetalhesVM(this Usuario usuario)
    {
        return new DetalhesUsuarioViewModel(
            usuario.Id,
            usuario.Nome,
            usuario.Email,
            usuario.Telefone,
            usuario.Documento,
            usuario.TipoDocumento.ToString()
        );
    }
}