using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class TelaFabricante
    {
        public RepositorioFabricante repositorioFabricante;

        public TelaFabricante(RepositorioFabricante repositorioFabricante)
        {
            this.repositorioFabricante = repositorioFabricante;
        }

        public String ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("        Gestão de Fabricantes        ");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1 - Cadastrar Fabricante");
            Console.WriteLine("2 - Editar Fabricante");
            Console.WriteLine("3 - Excluir Fabricante");
            Console.WriteLine("4 - Visualizar Fabricantes");
            Console.WriteLine("S - Voltar");
            Console.WriteLine("--------------------------------------------\n");

            Console.Write("Escolha uma opção: ");
            return Console.ReadLine()!;
        }

        public void CadastrarFabricante()
        {
            ExibirCabecalho("Cadastro de Fabricante");

            Console.Write("Nome do fabricante: ");
            string nome = Console.ReadLine()!;

            Console.Write("Email do fabricante: ");
            string email = Console.ReadLine()!;

            Console.Write("Telefone do fabricante: ");
            string telefone = Console.ReadLine()!;

            Fabricante novoFabricante = new Fabricante(nome, email, telefone);

            string erros = novoFabricante.Validar();

            if (erros.Length > 0)
            {
                Notificador.ExibirMensagem(erros, ConsoleColor.Red);

                CadastrarFabricante();

                return;
            }

            repositorioFabricante.CadastrarFabricante(novoFabricante);

            Console.WriteLine("\nFabricante cadastrado com sucesso!");
            Console.ReadLine();
        }

        public void EditarFabricante()
        {
            ExibirCabecalho("Edição de Fabricante");
            VisualizarFabricantes(false);

            Console.Write("\nDigite o ID do fabricante que deseja editar: ");
            int id = LerInteiro();

            Fabricante fabricanteAtual = repositorioFabricante.SelecionarFabricantePorId(id);

            if (fabricanteAtual == null)
            {
                MostrarMensagemErro("Fabricante não encontrado!");
                return;
            }

            Console.Write("Novo nome (ENTER para manter): ");
            string novoNome = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(novoNome))
                fabricanteAtual.Nome = novoNome;

            Console.Write("Novo email (ENTER para manter): ");
            string novoEmail = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(novoEmail))
                fabricanteAtual.Email = novoEmail;

            Console.Write("Novo telefone (ENTER para manter): ");
            string novoTelefone = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(novoTelefone))
                fabricanteAtual.Telefone = novoTelefone;

            repositorioFabricante.EditarFabricante(id, fabricanteAtual);

            MostrarMensagemSucesso("Fabricante editado com sucesso!");
        }

        public void ExcluirFabricante()
        {
            ExibirCabecalho("Exclusão de Fabricante");
            VisualizarFabricantes(false);

            Console.Write("\nDigite o ID do fabricante que deseja excluir: ");
            int id = LerInteiro();

            bool conseguiuExcluir = repositorioFabricante.ExcluirFabricante(id);

            if (!conseguiuExcluir)
            {
                MostrarMensagemErro("Fabricante não encontrado!");
                return;
            }

            MostrarMensagemSucesso("Fabricante excluído com sucesso!");
        }

        public void VisualizarFabricantes(bool exibirCabecalho = true)
        {
            if (exibirCabecalho)
                ExibirCabecalho("Lista de Fabricantes");

            Console.WriteLine("{0,-5} | {1,-20} | {2,-25} | {3,-15} | {4,-10} ",
                "ID", "Nome", "Email", "Telefone", "Equipamentos");
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            foreach (Fabricante fabricante in repositorioFabricante.SelecionarFabricantes())
            {
                if (fabricante == null)
                    continue;

                int qtdEquipamentos = repositorioFabricante.ObterQuantidadeEquipamentos(fabricante);

                Console.WriteLine("{0,-5} | {1,-20} | {2,-25} | {3,-15} | {4,-10}",
                    fabricante.Id,
                    fabricante.Nome,
                    fabricante.Email,
                    fabricante.Telefone,
                    qtdEquipamentos);
            }

            if (exibirCabecalho)
                Console.ReadLine();
        }

        #region Métodos Auxiliares
        private void ExibirCabecalho(string titulo)
        {
            Console.Clear();
            Console.WriteLine($"--------------------------------------------");
            Console.WriteLine($"        {titulo}       ");
            Console.WriteLine($"--------------------------------------------\n");
        }

        private void MostrarMensagemSucesso(string mensagem)
        {
            Console.WriteLine($"\n{mensagem}");
            Console.ReadLine();
        }

        private void MostrarMensagemErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{mensagem}");
            Console.ResetColor();
            Console.ReadLine();
        }

        private int LerInteiro()
        {
            int valor;
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Entrada inválida. Digite um número: ");
            }
            return valor;
        }
        #endregion
    }
}