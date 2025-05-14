using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.Models;

namespace GestaoDeEquipamentos.ConsoleApp.Extensoes
{
    public static class EquipamentoExtensions
    {
        public static Equipamento ParaEntidade(this FormularioEquipamentoViewModel formulario)
        {
            return new Equipamento(
                formulario.Nome,
                formulario.PrecoAquisicao,
                formulario.DataFabricacao,
                formulario.Fabricante
            );

           
        }

        public static DetalhesEquipamentoViewModel ParaDetalhesVM(this Equipamento equipamento)
        {
            DetalhesEquipamentoViewModel detalhes = new DetalhesEquipamentoViewModel(
                equipamento.Id,
                equipamento.Nome,
                equipamento.Fabricante,
                equipamento.PrecoAquisicao,
                equipamento.DataFabricacao
            );

            return detalhes;
        }
    }
}
