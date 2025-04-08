using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class RepositorioFabricante
    {
        public Fabricante[] fabricantes = new Fabricante[100];
        public int contadorFabricantes = 0;

        public void CadastrarFabricante(Fabricante novoFabricante)
        {
            novoFabricante.Id = GeradorIds.GerarIdFabricante();
            fabricantes[contadorFabricantes++] = novoFabricante;
        }

        public bool EditarFabricante(int id, Fabricante fabricanteEditado)
        {
            for (int i = 0; i < fabricantes.Length; i++)
            {
                if (fabricantes[i] != null && fabricantes[i].Id == id)
                {
                    fabricantes[i].Nome = fabricanteEditado.Nome;
                    fabricantes[i].Email = fabricanteEditado.Email;
                    fabricantes[i].Telefone = fabricanteEditado.Telefone;
                    return true;
                }
            }
            return false;
        }
        public bool ExcluirFabricante(int id)
        {
            for (int i = 0; i < fabricantes.Length; i++)
            {
                if (fabricantes[i] != null && fabricantes[i].Id == id)
                {
                    fabricantes[i] = null;
                    return true;
                }
            }
            return false;
        }

        public Fabricante[] SelecionarFabricantes()
        {
            return fabricantes;
        }

        public Fabricante SelecionarFabricantePorId(int id)
        {
            foreach (var fabricante in fabricantes)
            {
                if (fabricante != null && fabricante.Id == id)
                    return fabricante;
            }
            return null;
        }
    }
}