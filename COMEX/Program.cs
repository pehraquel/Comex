using COMEX;
using COMEX.Modelos;


List<Cliente> clientes = new();     List<Produto> produtos = new();
List<Carrinho> carrinhos = new();
clientes.Add(new Cliente("Paulo", "123"));
clientes.Add(new Cliente("Eduardo", "456"));
produtos.Add(new Produto("produto1") { PrecoUnitario = 10.0 });
produtos.Add(new Produto("produto2") { PrecoUnitario = 20.0 });
/*carrinho.Add("123", new List<string>());
carrinho["123"].Add("produto1");
carrinho["123"].Add("produto2");
*/

void CadastraCliente()
{
    // Lógica para cadastrar um cliente
    Console.Clear();
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
    VoltarAoMenuPrincipal();
}

void CadastraProduto()
{
    // Lógica para cadastrar um cliente
    Console.Clear();
    Console.WriteLine("Digite o nome do Produto");
    string nome = Console.ReadLine()!;
    Console.WriteLine("Digite o preço do Produto");
    string precoString = Console.ReadLine()!;
    double preco = double.Parse(precoString);
    if (!produtos.Any(p => p.Nome.Equals(nome)))
    {
        produtos.Add(new Produto(nome) { PrecoUnitario = preco }        );
    }
    else
    {
        Console.WriteLine($"Produto {nome} já cadastrado.");
    }
  
    VoltarAoMenuPrincipal();
}

void ListaClientes()
{
    // Lógica para exibir a lista de clientes
    Console.Clear();
    Console.WriteLine("Lista de Clientes:");
    foreach (Cliente cliente in clientes)
    {
        Console.WriteLine($"Nome: {cliente.Nome}, CPF: {cliente.CPF}");
    }
    VoltarAoMenuPrincipal();
}

void ListaProdutos()
{
    // Lógica para exibir a lista de produtos
    Console.Clear();
    Console.WriteLine("Lista de Produtos:");
    if (produtos.Count == 0)
    {
        Console.WriteLine("Não existe nenhum carrinho cadastrado");
    }
    else
    {
        foreach (Produto produto in produtos)
        {
            Console.WriteLine($"Nome: {produto.Nome}, Preço: {produto.PrecoUnitario}");
        }
    }
    VoltarAoMenuPrincipal();
}

void ExibirMenuDeOpcoes()
{
    Console.WriteLine("\n----Projeto Comex----");
    Console.WriteLine("Digite 1 para cadastrar Cliente");
    Console.WriteLine("Digite 2 para listar Clientes");
    Console.WriteLine("Digite 3 para cadastrar Produto");
    Console.WriteLine("Digite 4 para listar Produtos");
    Console.WriteLine("Digite 5 para ajustar preço do produto");
    Console.WriteLine("Digite 6 para adicionar produto no carrinho");
    Console.WriteLine("Digite 7 para listar produtos no carrinho");
    Console.WriteLine("Digite 8 para fechar as compras do carrinho");
    Console.WriteLine("Digite -1 para sair");

    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            CadastraCliente();
            break;
        case 2:
            ListaClientes();
            break;
        case 3:
            CadastraProduto();
            break;
        case 4:
            ListaProdutos();
            break;
        case 5:
            AjustarPrecoDeProduto();
            break;
        case 6:
            AdicionaProdutoNoCarrinho();
            break;
        case 7:
            ListaProdutosNoCarrinho();
            break;
        case 8:
            FechaCompra();
            break;
        case -1:
            Console.WriteLine("COMEX FINALIZADO!");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;

    }
}

void FechaCompra()
{
    Console.Clear();
    Console.WriteLine("Digite o CPF do Cliente");
    string CPF = Console.ReadLine()!;

    if (!clientes.Any(c => c.CPF.Equals(CPF)))
    {
        Console.WriteLine("Cliente não cadastrado");
    }
    else
    {
        ListaProdutosDeCliente(CPF);
    }
    VoltarAoMenuPrincipal();
}

void ListaProdutosNoCarrinho()
{
    Console.Clear();
    Console.WriteLine("Lista produtos no carrinho");
    foreach (Carrinho carrinho in carrinhos)
    {
        foreach (Produto produto in carrinho.produtos)
        {
            string nomeCliente = carrinho.cliente.Nome;
            Console.WriteLine($"Nome: {nomeCliente}, Produto: {produto.Nome}");
        }
           
    }
    VoltarAoMenuPrincipal();
}

void ListaProdutosDeCliente(string CPF)
{
    double total = 0;
    Console.Clear();
    Cliente cliente = clientes.First(a => a.CPF.Equals(CPF));
    string nomeCliente = cliente.Nome;
    Console.WriteLine($"Lista produtos no carrinho de {nomeCliente}");
    if (!carrinhos.Any(c => c.cliente.CPF.Equals(CPF)))
    {
        Console.WriteLine("O carrinho está vazio");
    } 
    else
    {
        List<Produto> produtosCarrinho = carrinhos.First(c => c.cliente.CPF.Equals(CPF)).produtos;
        foreach (Produto p in produtosCarrinho)
        {
            double valor = p.PrecoUnitario;
            total += valor;
            Console.WriteLine($"Produto: {p.Nome} Valor: {valor}");
        }

        Console.WriteLine($"Total do Carrinho: {total}");
        DadosCartaoUsuario(total);          
    }
}

void DadosCartaoUsuario(double total)
{
    // Lógica para cadastrar um cliente
    if (total > 0)
    {
        Console.WriteLine("Digite o Cartão do Cliente");
        string NumeroCartao = Console.ReadLine()!;
        Console.WriteLine($"Realizando pagamento de R$ {total} no cartão {NumeroCartao}");
    }
    VoltarAoMenuPrincipal();
}

void AjustarPrecoDeProduto()
{
    Console.Clear();
    Console.WriteLine("Qual produto você deseja ajustar o preço?");
    string nomeProduto = Console.ReadLine()!;
    if (produtos.Any(p => p.Nome.Equals(nomeProduto)))
    {
        Produto p = produtos.First(p => p.Nome.Equals(nomeProduto));
        Console.WriteLine("Digite o novo preço do produto");
        string precoString = Console.ReadLine()!;
        double preco = double.Parse(precoString);
        p.PrecoUnitario = preco;
        Console.WriteLine($"Preço do produto {nomeProduto} ajustado para {preco}.");
    }
    else
    {
        Console.WriteLine($"Produto {nomeProduto} não encontrado.");
    }

    VoltarAoMenuPrincipal();

}
void VoltarAoMenuPrincipal()
{
    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
    ExibirMenuDeOpcoes();
}

void AdicionaProdutoNoCarrinho()
{
    Console.Clear();
    Console.WriteLine("Qual CPF do cliente que está comprando?");
    string CPF = Console.ReadLine()!;
    if (!clientes.Any(c => c.CPF.Equals(CPF)))
    {
        Console.WriteLine($"Usuário {CPF} não cadastrado.");
    }
    else
    {
        Console.WriteLine("Digite o nome do produto que deseja adicionar");
        string nomeProduto = Console.ReadLine()!;
        if (!produtos.Any(p => p.Nome.Equals(nomeProduto)))
        {
            Console.WriteLine($"Produto {nomeProduto} não cadastrado.");
        }
        else
        {
            //cria a lista do carrinho, caso não exista
            if (!carrinhos.Any(c => c.cliente.CPF.Equals(CPF)))
            {
                carrinhos.Add(new Carrinho { cliente = clientes.First(c => c.CPF.Equals(CPF)), produtos = new List<Produto>() });
            }

            carrinhos.First(c => c.cliente.CPF.Equals(CPF)).produtos.Add(produtos.First(p => p.Nome.Equals(nomeProduto)));
            string nomeCliente = clientes.First(c => c.CPF.Equals(CPF)).Nome;
            Console.WriteLine($"Produto {nomeProduto} de {nomeCliente} ({CPF}) adicionado com sucesso.");
        }

    }   

    VoltarAoMenuPrincipal();
}

ExibirMenuDeOpcoes();



















