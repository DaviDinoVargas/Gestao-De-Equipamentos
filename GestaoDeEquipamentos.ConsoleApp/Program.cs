using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using System;

namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaEquipamento telaEquipamento = new TelaEquipamento();
            TelaChamado telaChamado = new TelaChamado(telaEquipamento);

            while (true)
            {
                string opcaoPrincipal = ObterOpcaoPrincipal();

                if (opcaoPrincipal.ToUpper() == "S")
                    break;

                switch (opcaoPrincipal)
                {
                    case "1":
                        string opcaoEquipamento = telaEquipamento.ApresentarMenu();
                        if (opcaoEquipamento == "5")
                            break;

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
                        if (opcaoChamado == "5")
                            break;

                        switch (opcaoChamado)
                        {
                            case "1": telaChamado.CadastrarChamado(); break;
                            case "2": telaChamado.EditarChamado(); break;
                            case "3": telaChamado.ExcluirChamado(); break;
                            case "4": telaChamado.VisualizarChamados(); break;
                        }
                        break;
                }
            }
        }

        static string ObterOpcaoPrincipal()
        {
            return MenuPrincipal.Exibir();
        }
    }
}
