using GestaoDeEquipamentos.ConsoleApp.Extensoes;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using System;
using System.Collections.Generic;

namespace GestaoDeEquipamentos.ConsoleApp.Models
{
    public abstract class FormularioEquipamentoViewModel
    {
        public string Nome { get; set; }

        public decimal PrecoAquisicao { get; set; }

        public DateTime DataFabricacao { get; set; }

        public Fabricante Fabricante { get; set; }
    }

    public class CadastrarEquipamentoViewModel : FormularioEquipamentoViewModel
    {
        public List<Fabricante> Fabricantes { get; set; }

        public int FabricanteId { get; set; }

        public CadastrarEquipamentoViewModel()
        {
            Fabricantes = new List<Fabricante>();
        }

        public CadastrarEquipamentoViewModel(string nome, Fabricante fabricante, decimal precoAquisicao, DateTime dataFabricacao)
        {
            Nome = nome;
            Fabricante = fabricante;
            PrecoAquisicao = precoAquisicao;
            DataFabricacao = dataFabricacao;
            FabricanteId = fabricante.Id;
        }
    }

    public class EditarEquipamentoViewModel : FormularioEquipamentoViewModel
    {
        public List<Fabricante> Fabricantes { get; set; }

        public int FabricanteId { get; set; }
        public int Id { get; set; }

        public EditarEquipamentoViewModel(int id, string nome, Fabricante fabricante, decimal precoAquisicao, DateTime dataFabricacao)
        {
            Id = id;
            Nome = nome;
            Fabricante = fabricante;
            PrecoAquisicao = precoAquisicao;
            DataFabricacao = dataFabricacao;
            FabricanteId = fabricante.Id;
        }
    }

    public class ExcluirEquipamentoViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public ExcluirEquipamentoViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }

    public class DetalhesEquipamentoViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public Fabricante Fabricante { get; set; }

        public decimal PrecoAquisicao { get; set; }

        public DateTime DataFabricacao { get; set; }

        public DetalhesEquipamentoViewModel(int id, string nome, Fabricante fabricante, decimal preco, DateTime data)
        {
            Id = id;
            Nome = nome;
            Fabricante = fabricante;
            PrecoAquisicao = preco;
            DataFabricacao = data;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}, Fabricante: {Fabricante.Nome}, Preço: R${PrecoAquisicao}, Data: {DataFabricacao:d}";
        }
    }

    public class VisualizarEquipamentosViewModel
    {
        public List<DetalhesEquipamentoViewModel> Registros { get; } = new List<DetalhesEquipamentoViewModel>();

        public VisualizarEquipamentosViewModel(List<Equipamento> equipamentos)
        {
            foreach (Equipamento e in equipamentos)
            {
                DetalhesEquipamentoViewModel detalhes = e.ParaDetalhesVM();
                Registros.Add(detalhes);
            }
        }
    }
}