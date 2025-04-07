using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp
{
    class Equipamento
    {
        public int Id;
        public string Nome;
        public string Fabricante;
        public decimal PrecoAquisicao;
        public DateTime DataFabricacao;

        public Equipamento(string nome, string fabricante, decimal precoAquisicao, DateTime dataFabricacao)
        {
            Nome = nome;
            Fabricante = fabricante;
            PrecoAquisicao = precoAquisicao;
            DataFabricacao = dataFabricacao;
        }
    }
}
