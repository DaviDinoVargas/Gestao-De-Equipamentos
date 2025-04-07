using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado
{
    public class TelaChamado
    {
        private Chamado[] chamados = new Chamado[100];
        private int contadorChamados = 0;
        private TelaEquipamento telaEquipamento;
        public TelaChamado(TelaEquipamento telaEquipamento)
        {
            this.telaEquipamento = telaEquipamento;
        }
        public string ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Chamados");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1 - Cadastro de Chamado");
            Console.WriteLine("2 - Edição de Chamado");
            Console.WriteLine("3 - Exclusão de Chamado");
            Console.WriteLine("4 - Visualização de Chamados");
            Console.WriteLine("5 - Voltar");
            Console.WriteLine("--------------------------------------------");
            Console.Write("Escolha uma opção: ");
            return Console.ReadLine();
        }

        public void CadastrarChamado()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Chamado");
            Console.WriteLine("--------------------------------------------");

            Console.Write("Digite o título do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descrição do chamado: ");
            string descricao = Console.ReadLine();

            telaEquipamento.VisualizarEquipamentos(false);

            Console.Write("Digite o ID do equipamento relacionado: ");
            int idEquipamento = Convert.ToInt32(Console.ReadLine());

            Equipamento equipamentoSelecionado = null;

            for (int i = 0; i < telaEquipamento.equipamentos.Length; i++)
            {
                if (telaEquipamento.equipamentos[i] == null) continue;

                if (telaEquipamento.equipamentos[i].Id == idEquipamento)
                {
                    equipamentoSelecionado = telaEquipamento.equipamentos[i];
                    break;
                }
            }

            if (equipamentoSelecionado == null)
            {
                Console.WriteLine("Equipamento não encontrado!");
                return;
            }

            Console.Write("Digite a data de abertura (dd/MM/yyyy): ");
            DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());

            Chamado novoChamado = new Chamado(titulo, descricao, equipamentoSelecionado, dataAbertura);
            novoChamado.Id = GeradorIds.GerarIdEquipamento();

            chamados[contadorChamados++] = novoChamado;

            Console.WriteLine("Chamado cadastrado com sucesso!");
        }
        public void VisualizarChamados()
        {
            Console.Clear();
            Console.WriteLine("Chamados Registrados");
            Console.WriteLine("--------------------------------------------");
            Console.ReadLine();

            Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -15} | {4, -10}",
                "Id", "Título", "Equipamento", "Abertura", "Dias Abertos");

            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] == null) continue;

                Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -15} | {4, -10}",
                    chamados[i].Id,
                    chamados[i].Titulo,
                    chamados[i].EquipamentoRelacionado.Nome,
                    chamados[i].DataAbertura.ToShortDateString(),
                    chamados[i].ObterDiasEmAberto());
            }

            Console.ReadLine();
        }
        public void EditarChamado()
        {
            Console.Clear();
            Console.WriteLine("Editar Chamado");
            Console.WriteLine("--------------------------------------------");

            VisualizarChamados();

            Console.Write("Digite o ID do chamado a ser editado: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] == null) continue;

                if (chamados[i].Id == idSelecionado)
                {
                    Console.Write("Novo título: ");
                    chamados[i].Titulo = Console.ReadLine();

                    Console.Write("Nova descrição: ");
                    chamados[i].Descricao = Console.ReadLine();

                    telaEquipamento.VisualizarEquipamentos(false);
                    Console.Write("Novo ID de equipamento: ");
                    int idEquip = Convert.ToInt32(Console.ReadLine());

                    for (int j = 0; j < telaEquipamento.equipamentos.Length; j++)
                    {
                        if (telaEquipamento.equipamentos[j] == null) continue;

                        if (telaEquipamento.equipamentos[j].Id == idEquip)
                        {
                            chamados[i].EquipamentoRelacionado = telaEquipamento.equipamentos[j];
                            break;
                        }
                    }

                    Console.Write("Nova data de abertura (dd/MM/yyyy): ");
                    chamados[i].DataAbertura = Convert.ToDateTime(Console.ReadLine());

                    Console.WriteLine("Chamado atualizado com sucesso!");
                    return;
                }
            }

            Console.WriteLine("Chamado não encontrado.");
        }
        public void ExcluirChamado()
        {
            Console.Clear();
            Console.WriteLine("Excluir Chamado");
            Console.WriteLine("--------------------------------------------");

            VisualizarChamados();

            Console.Write("Digite o ID do chamado a ser excluído: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] == null) continue;

                if (chamados[i].Id == idSelecionado)
                {
                    chamados[i] = null;
                    Console.WriteLine("Chamado excluído com sucesso!");
                    return;
                }
            }

            Console.WriteLine("Chamado não encontrado.");
        }

    }
}
