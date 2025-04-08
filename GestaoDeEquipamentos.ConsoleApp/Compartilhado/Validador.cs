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
                Console.WriteLine("\nErro: Não há fabricantes cadastrados!");
                Console.WriteLine("Cadastre pelo menos um fabricante antes de continuar.");
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
            foreach (var fabricante in repositorio.fabricantes)
            {
                if (fabricante != null && fabricante.Id == id)
                    return true;
            }

            Console.WriteLine("\nErro: ID de fabricante inválido!");
            Console.ReadLine();
            return false;
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