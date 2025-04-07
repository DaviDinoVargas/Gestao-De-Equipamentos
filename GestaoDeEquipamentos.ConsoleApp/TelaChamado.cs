using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp
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
            Console.WriteLine("--------------------------------------------");
            Console.Write("Escolha uma opção: ");
            return Console.ReadLine();
        }

    }
}
