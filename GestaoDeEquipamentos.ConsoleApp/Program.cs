namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaEquipamento telaEquipamento = new TelaEquipamento();

            while (true)
            {
                string opcaoEscolhida = telaEquipamento.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case "1":
                        telaEquipamento.CadastrarEquipamento();
                        break;

                    case "2":
                        telaEquipamento.EditarEquipamento();
                        break;

                    case "3":
                        telaEquipamento.ExcluirEquipamento();
                        break;

                    case "4":
                        telaEquipamento.VisualizarEquipamentos(true);
                        break;

                    default:
                        Console.WriteLine("Saindo do programa...");
                        break;
                }

                Console.ReadLine();
            }

        }
    }
}