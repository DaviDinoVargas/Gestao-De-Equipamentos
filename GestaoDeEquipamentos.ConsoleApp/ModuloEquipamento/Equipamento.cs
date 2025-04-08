using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento
{
    public class Equipamento
    {
        public int Id;
        public string Nome;
        public Fabricante Fabricante; // Alterado para tipo Fabricante
        public decimal PrecoAquisicao;
        public DateTime DataFabricacao;

        public Equipamento(string nome, Fabricante fabricante, decimal precoAquisicao, DateTime dataFabricacao)
        {
            Nome = nome;
            Fabricante = fabricante; // Agora recebe um objeto Fabricante
            PrecoAquisicao = precoAquisicao;
            DataFabricacao = dataFabricacao;
        }

        public string ObterNumeroSerie()
        {
            string tresPrimeirosCaracteres = Nome.Substring(0, Math.Min(3, Nome.Length)).ToUpper();
            return $"{tresPrimeirosCaracteres}-{Id}";
        }
    }
}
