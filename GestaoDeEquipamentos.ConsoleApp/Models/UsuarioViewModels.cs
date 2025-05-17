using GestaoDeEquipamentos.ConsoleApp.ModuloUsuario;

namespace GestaoDeEquipamentos.ConsoleApp.Models;

public class FormularioUsuarioViewModel
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Documento { get; set; }
    public TipoDocumento TipoDocumento { get; set; }
}

public class CadastrarUsuarioViewModel : FormularioUsuarioViewModel { }

public class EditarUsuarioViewModel : FormularioUsuarioViewModel
{
    public int Id { get; set; }

    public EditarUsuarioViewModel() { }

    public EditarUsuarioViewModel(Usuario usuario)
    {
        Id = usuario.Id;
        Nome = usuario.Nome;
        Email = usuario.Email;
        Telefone = usuario.Telefone;
        Documento = usuario.Documento;
        TipoDocumento = usuario.TipoDocumento;
    }
}

public class ExcluirUsuarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ExcluirUsuarioViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarUsuariosViewModel
{
    public List<DetalhesUsuarioViewModel> Registros { get; set; }

    public VisualizarUsuariosViewModel(List<Usuario> usuarios)
    {
        Registros = usuarios.Select(u => u.ParaDetalhesVM()).ToList();
    }
}

public class DetalhesUsuarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Documento { get; set; }
    public string TipoDocumento { get; set; }

    public DetalhesUsuarioViewModel(int id, string nome, string email, string telefone, string documento, string tipoDocumento)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Documento = documento;
        TipoDocumento = tipoDocumento;
    }

    public override string ToString()
    {
        return $"Id: {Id} - Nome: {Nome} - {TipoDocumento}: {Documento} - Email: {Email} - Telefone: {Telefone}";
    }
}