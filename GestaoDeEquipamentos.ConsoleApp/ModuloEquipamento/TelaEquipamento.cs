namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento
{
    public class TelaEquipamento
    {
        public Equipamento[] equipamentos = new Equipamento[100];
        public int contadorEquipamentos = 0;

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
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Cadastrando Equipamento...");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();

            Console.Write("Digite o nome do equipamento: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do fabricante equipamento: ");
            string fabricante = Console.ReadLine();

            Console.Write("Digite o preço de aquisição R$ ");
            decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite a data de fabricação do equipamento (dd/MM/yyyy) ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Equipamento novoEquipamento = new Equipamento(nome, fabricante, precoAquisicao, dataFabricacao);
            novoEquipamento.Id = GeradorIds.GerarIdEquipamento();

            equipamentos[contadorEquipamentos++] = novoEquipamento;
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

            Console.Write("Digite o nome do fabricante equipamento: ");
            string fabricante = Console.ReadLine();

            Console.Write("Digite o preço de aquisição R$ ");
            decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite a data de fabricação do equipamento (dd/MM/yyyy) ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Equipamento novoEquipamento = new Equipamento(nome, fabricante, precoAquisicao, dataFabricacao);

            bool conseguiuEditar = false;

            for (int i = 0; i < equipamentos.Length; i++)
            {
                if (equipamentos[i] == null) continue;

                else if (equipamentos[i].Id == idSelecionado)
                {
                    equipamentos[i].Nome = novoEquipamento.Nome;
                    equipamentos[i].Fabricante = novoEquipamento.Fabricante;
                    equipamentos[i].PrecoAquisicao = novoEquipamento.PrecoAquisicao;
                    equipamentos[i].DataFabricacao = novoEquipamento.DataFabricacao;

                    conseguiuEditar = true;
                }
            }

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

            bool conseguiuExcluir = false;

            for (int i = 0; i < equipamentos.Length; i++)
            {
                if (equipamentos[i] == null) continue;

                else if (equipamentos[i].Id == idSelecionado)
                {
                    equipamentos[i] = null;
                    conseguiuExcluir = true;
                }
            }

            if (!conseguiuExcluir)
            {
                Console.WriteLine("Houve um erro durante a exclusão de um registro...");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("O equipamento foi excluído com sucesso!");
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
                Console.ReadLine();
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
                "Id", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação"
            );

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = equipamentos[i];

                if (e == null) continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
                    e.Id, e.Nome, e.ObterNumeroSerie(), e.Fabricante, e.PrecoAquisicao.ToString("C2"), e.DataFabricacao.ToShortDateString()

                );
            }

            Console.ReadLine();
        }
    }
}