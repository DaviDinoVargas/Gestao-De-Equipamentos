using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{
    public static class GeradorIds
    {
        public static int IdEquipamentos = 0;
        public static int IdChamados = 0;
        public static int IdFabricante = 0;

        public static int GerarIdEquipamento()
        {
            IdEquipamentos++;

            return IdEquipamentos;
        }
        public static int GerarIdChamado()
        {
            IdChamados++;

            return IdChamados;
        }public static int GerarIdFabricante()
        {
            IdFabricante++;

            return IdFabricante;
        }
    }
}
