using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp
{
    public class MenuPrincipal
    {
        public static string Exibir()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos e Chamados");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1 - Gestão de Equipamentos");
            Console.WriteLine("2 - Gestão de Chamados");
            Console.WriteLine("S - Sair");
            Console.WriteLine("--------------------------------------------");
            Console.Write("Escolha uma opção: ");
            return Console.ReadLine();
        }
    }
}
