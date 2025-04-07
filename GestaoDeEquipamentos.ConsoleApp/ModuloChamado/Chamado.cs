using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado
{
    class Chamado
    {
        public int Id;
        public string Titulo;
        public string Descricao;
        public Equipamento EquipamentoRelacionado;
        public DateTime DataAbertura;

        public Chamado(string titulo, string descricao, Equipamento equipamento, DateTime dataAbertura)
        {
            Titulo = titulo;
            Descricao = descricao;
            EquipamentoRelacionado = equipamento;
            DataAbertura = dataAbertura;
        }

        public int ObterDiasEmAberto()
        {
            return (DateTime.Now - DataAbertura).Days;
        }
    }
}
