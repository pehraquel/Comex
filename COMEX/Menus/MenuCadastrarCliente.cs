using COMEX.Menus;
using COMEX.Modelos;

internal class MenuCadastrarCliente: Menu<Cliente>
{
    public override void Executar(List<Cliente> clientes)
    {
        base.Executar(clientes);
        Console.WriteLine("Digite o CPF do Cliente");
        string CPF = Console.ReadLine()!;

        if (!clientes.Any(c => c.CPF.Equals(CPF)))
        {
            Console.WriteLine("Digite o nome do Cliente");
            string nome = Console.ReadLine()!;
            Cliente cliente = new Cliente(nome, CPF);
            clientes.Add(cliente);
            Console.WriteLine($"Usuário {nome} ({CPF}) cadastrado com sucesso.");

        }
        else
        {
            Console.WriteLine($"Usuário {CPF} já cadastrado.");
        }
        base.VoltarAoMenuPrincipal();
    }
    
}

