using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class Fabricante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Fabricante(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
        public string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 3)
                erros += "O campo 'Nome' é obrigatório e precisa conter ao menos 3 caracteres.\n";

            if (string.IsNullOrWhiteSpace(Email))
                erros += "O campo 'Email é obrigatório.\n";

            else if (!MailAddress.TryCreate(Email, out _))
                erros += "O campo 'Email' está em um formato inválido.\n";

            if (string.IsNullOrWhiteSpace(Telefone))
                erros += "O campo 'Telefone' é obrigatório.";

            return erros;
        }
    }
}