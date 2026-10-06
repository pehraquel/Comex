using System.Runtime.CompilerServices;

internal class Cliente
{
    public string Nome { get; set; }

    public string CPF { get; set; }

    public Cliente(string nome, string cpf)
    {
        Nome = nome;
        CPF = cpf;
    }
}