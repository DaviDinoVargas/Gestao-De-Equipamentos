using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento
{
    namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento
    {
        public class TelaEquipamento
        {
            public RepositorioEquipamento repositorioEquipamento;
            private RepositorioFabricante repositorioFabricante;

            public TelaEquipamento(RepositorioFabricante repositorioFabricante, RepositorioEquipamento repositorioEquipamento)
            {
                this.repositorioFabricante = repositorioFabricante;
                this.repositorioEquipamento = repositorioEquipamento;
            }
            public string ApresentarMenu()
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Gestão de Equipamentos");
                Console.WriteLine("--------------------------------------------");

                Console.WriteLine("Escolha a operação desejada:");
                Console.WriteLine("1 - Cadastro de Equipamento");
                Console.WriteLine("2 - Edição de Equipamento");
                Console.WriteLine("3 - Exclusão de Equipamento");
                Console.WriteLine("4 - Visualização de Equipamentos");
                Console.WriteLine("5 - Voltar");
                Console.WriteLine("--------------------------------------------");

                Console.Write("Digite um opção válida: ");
                string opcaoEscolhida = Console.ReadLine();

                return opcaoEscolhida;
            }

            public void CadastrarEquipamento()
            {
                if (!Validador.ValidarFabricantesDisponiveis(repositorioFabricante))
                    return;

                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Gestão de Equipamentos");
                Console.WriteLine("--------------------------------------------");

                Console.WriteLine("Cadastrando Equipamento...");
                Console.WriteLine("--------------------------------------------");

                Console.WriteLine();

                Console.Write("Digite o nome do equipamento: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o ID do fabricante: ");
                int idFabricante = Convert.ToInt32(Console.ReadLine());

                Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarFabricantePorId(idFabricante);

                Console.Write("Digite o preço de aquisição R$ ");
                decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Digite a data de fabricação do equipamento (dd/MM/yyyy) ");
                DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

                Equipamento novoEquipamento = new Equipamento(nome, fabricanteSelecionado, precoAquisicao, dataFabricacao);
                repositorioEquipamento.CadastrarEquipamento(novoEquipamento);

                Console.WriteLine("\nEquipamento cadastrado com sucesso!");
                Console.ReadLine();
            }

            public void EditarEquipamento()
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Gestão de Equipamentos");
                Console.WriteLine("--------------------------------------------");

                Console.WriteLine("Editando Equipamento...");
                Console.WriteLine("--------------------------------------------");

                VisualizarEquipamentos(false);

                Console.Write("Digite o ID do registro que deseja selecionar: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                Console.Write("Digite o nome do equipamento: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Fabricantes disponíveis:");
                Fabricante[] fabricantes = repositorioFabricante.SelecionarFabricantes();
                foreach (Fabricante f in fabricantes)
                {
                    if (f != null)
                        Console.WriteLine($"ID: {f.Id} - Nome: {f.Nome}");
                }
                Console.Write("Digite o ID do fabricante: ");
                int idFabricante = Convert.ToInt32(Console.ReadLine());

                Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarFabricantePorId(idFabricante);

                if (fabricanteSelecionado == null)
                {
                    Console.WriteLine("Fabricante não encontrado. Operação cancelada.");
                    return;
                }

                Console.Write("Digite o preço de aquisição R$ ");
                decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Digite a data de fabricação do equipamento (dd/MM/yyyy) ");
                DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

                Equipamento novoEquipamento = new Equipamento(nome, fabricanteSelecionado, precoAquisicao, dataFabricacao);

                bool conseguiuEditar = repositorioEquipamento.EditarEquipamento(idSelecionado, novoEquipamento);

                if (!conseguiuEditar)
                {
                    Console.WriteLine("Houve um erro durante a edição de um registro...");
                    return;
                }

                Console.WriteLine();
                Console.WriteLine("O equipamento foi editado com sucesso!");
            }

            public void ExcluirEquipamento()
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Gestão de Equipamentos");
                Console.WriteLine("--------------------------------------------");

                Console.WriteLine("Excluindo Equipamento...");
                Console.WriteLine("--------------------------------------------");

                VisualizarEquipamentos(false);

                Console.Write("Digite o ID do registro que deseja selecionar: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                bool conseguiuExcluir = repositorioEquipamento.ExcluirEquipamento(idSelecionado);

                if (!conseguiuExcluir)
                {
                    Console.WriteLine("Houve um erro durante a exclusão de um registro...");
                    return;
                }

                Console.WriteLine();
                Console.WriteLine("O equipamento foi excluído com sucesso!");
                Console.ReadLine();
            }

            public void VisualizarEquipamentos(bool exibirTitulo)
            {
                if (exibirTitulo)
                {
                    Console.Clear();
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("Gestão de Equipamentos");
                    Console.WriteLine("--------------------------------------------");

                    Console.WriteLine("Visualizando Equipamentos...");
                    Console.WriteLine("--------------------------------------------");
                }

                Console.WriteLine();

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
                    "Id", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação"
                );

                Equipamento[] equipamentosCadastrados = repositorioEquipamento.SelecionarEquipamentos();

                for (int i = 0; i < equipamentosCadastrados.Length; i++)
                {
                    Equipamento e = equipamentosCadastrados[i];

                    if (e == null) continue;

                    Console.WriteLine(
                        "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
                        e.Id, e.Nome, e.ObterNumeroSerie(), e.Fabricante.Nome, e.PrecoAquisicao.ToString("C2"), e.DataFabricacao.ToShortDateString()
                    );
                }

                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}