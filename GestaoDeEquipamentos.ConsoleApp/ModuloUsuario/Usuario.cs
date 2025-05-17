using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloUsuario;

public class Usuario : EntidadeBase<Usuario>
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Documento { get; set; }
    public TipoDocumento TipoDocumento { get; set; }

    public Usuario() { }

    public Usuario(string nome, string email, string telefone, string documento, TipoDocumento tipoDocumento)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Documento = documento;
        TipoDocumento = tipoDocumento;
    }

    public override void AtualizarRegistro(Usuario usuarioAtualizado)
    {
        Nome = usuarioAtualizado.Nome;
        Email = usuarioAtualizado.Email;
        Telefone = usuarioAtualizado.Telefone;
        Documento = usuarioAtualizado.Documento;
        TipoDocumento = usuarioAtualizado.TipoDocumento;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo 'Nome' é obrigatório.\n";

        if (string.IsNullOrWhiteSpace(Email))
            erros += "O campo 'Email' é obrigatório.\n";

        if (string.IsNullOrWhiteSpace(Telefone))
            erros += "O campo 'Telefone' é obrigatório.\n";

        if (string.IsNullOrWhiteSpace(Documento))
            erros += "O campo 'Documento' é obrigatório.\n";
        else
        {
            if (TipoDocumento == TipoDocumento.CPF && !ValidarCpf(Documento))
                erros += "CPF inválido.\n";

            if (TipoDocumento == TipoDocumento.CNPJ && !ValidarCnpj(Documento))
                erros += "CNPJ inválido.\n";
        }

        return erros;
    }

    private bool ValidarCpf(string cpf)
    {
        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        if (cpf.Length != 11)
            return false;

        if (cpf.Distinct().Count() == 1)
            return false;

        int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf.Substring(0, 9);
        int soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

        int resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;

        string digito = resto.ToString();
        tempCpf += digito;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

        resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;

        digito += resto.ToString();

        return cpf.EndsWith(digito);
    }

    private bool ValidarCnpj(string cnpj)
    {
        cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

        if (cnpj.Length != 14)
            return false;

        if (cnpj.Distinct().Count() == 1)
            return false;

        int[] multiplicadores1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicadores2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCnpj = cnpj.Substring(0, 12);
        int soma = 0;

        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicadores1[i];

        int resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;

        string digito = resto.ToString();
        tempCnpj += digito;

        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicadores2[i];

        resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;

        digito += resto.ToString();

        return cnpj.EndsWith(digito);
    }
}

public enum TipoDocumento
{
    CPF,
    CNPJ
}