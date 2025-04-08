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

        public static int GerarIdEquipamento()
        {
            IdEquipamentos++;

            return IdEquipamentos;
        }

    }
}
