using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp
{
    class TelaEquipamento
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
            Console.WriteLine("--------------------------------------------");

            Console.Write("Digite um opção válida: ");
            string opcaoEscolhida = Console.ReadLine();

            return opcaoEscolhida;
        }
    }
}
