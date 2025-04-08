using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{
    public static class Validador
    {
        public static bool ValidarFabricantesDisponiveis(RepositorioFabricante repositorio)
        {
            if (repositorio.contadorFabricantes == 0)
            {
                Console.WriteLine("\nErro: Cadastre um fabricante primeiro!");
                Console.ReadLine();
                return false;
            }
            return true;
        }

        public static bool ValidarEquipamentosDisponiveis(RepositorioEquipamento repositorio)
        {
            if (repositorio.contadorEquipamentos == 0)
            {
                Console.WriteLine("\nErro: Não há equipamentos cadastrados!");
                Console.WriteLine("Cadastre pelo menos um equipamento antes de continuar.");
                Console.ReadLine();
                return false;
            }
            return true;
        }

        public static bool ValidarIdFabricante(int id, RepositorioFabricante repositorio)
        {
            Fabricante fabricante = repositorio.SelecionarFabricantePorId(id);
            if (fabricante == null)
            {
                Console.WriteLine("\nErro: Fabricante não encontrado!");
                Console.ReadLine();
                return false;
            }
            return true;
        }

        public static bool ValidarIdEquipamento(int id, RepositorioEquipamento repositorio)
        {
            foreach (var equipamento in repositorio.equipamentos)
            {
                if (equipamento != null && equipamento.Id == id)
                    return true;
            }

            Console.WriteLine("\nErro: ID de equipamento inválido!");
            Console.ReadLine();
            return false;
        }
    }
}