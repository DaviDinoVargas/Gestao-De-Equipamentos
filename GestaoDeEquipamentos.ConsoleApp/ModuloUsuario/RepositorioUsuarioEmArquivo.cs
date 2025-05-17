using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloUsuario
{
    public class RepositorioUsuarioEmArquivo : RepositorioBaseEmArquivo<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuarioEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Usuario> ObterRegistros()
        {
            return contexto.Usuarios;
        }
    }
}
