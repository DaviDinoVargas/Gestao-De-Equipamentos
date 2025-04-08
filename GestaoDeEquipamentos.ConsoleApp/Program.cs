using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento.GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using System;

namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
            RepositorioFabricante repositorioFabricante = new RepositorioFabricante(repositorioEquipamento);

            TelaFabricante telaFabricante = new TelaFabricante(repositorioFabricante);
            TelaEquipamento telaEquipamento = new TelaEquipamento(repositorioFabricante, repositorioEquipamento);

            TelaChamado telaChamado = new TelaChamado(telaEquipamento.repositorioEquipamento);


            while (true)
            {
                string opcaoPrincipal = ObterOpcaoPrincipal();

                if (opcaoPrincipal.ToUpper() == "S")
                    break;

                switch (opcaoPrincipal)
                {
                    case "1":
                        string opcaoEquipamento = telaEquipamento.ApresentarMenu();
                        switch (opcaoEquipamento)
                        {
                            case "1": telaEquipamento.CadastrarEquipamento(); break;
                            case "2": telaEquipamento.EditarEquipamento(); break;
                            case "3": telaEquipamento.ExcluirEquipamento(); break;
                            case "4": telaEquipamento.VisualizarEquipamentos(true); break;
                        }
                        break;

                    case "2":
                        string opcaoChamado = telaChamado.ApresentarMenu();
                        switch (opcaoChamado)
                        {
                            case "1": telaChamado.CadastrarChamado(); break;
                            case "2": telaChamado.EditarChamado(); break;
                            case "3": telaChamado.ExcluirChamado(); break;
                            case "4": telaChamado.VisualizarChamados(true); break;
                        }
                        break;

                    case "3":
                        string opcaoFabricante = telaFabricante.ApresentarMenu();
                        switch (opcaoFabricante)
                        {
                            case "1": telaFabricante.CadastrarFabricante(); break;
                            case "2": telaFabricante.EditarFabricante(); break;
                            case "3": telaFabricante.ExcluirFabricante(); break;
                            case "4": telaFabricante.VisualizarFabricantes(); break;
                            case "S": break;
                            default: MostrarOpcaoInvalida(); break;
                        }
                        break;

                    default:
                        MostrarOpcaoInvalida();
                        break;
                }
            }

            static string ObterOpcaoPrincipal()
            {
                return MenuPrincipal.Exibir();
            }

            static void MostrarOpcaoInvalida()
            {
                Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
