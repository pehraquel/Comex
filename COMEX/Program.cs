

using System.Numerics;
using System.Security.Cryptography;

Dictionary<string, string> clientes = new();
Dictionary<string, float> produtos = new();
Dictionary<string, List<string>> carrinho = new();
clientes.Add("123", "Paulo");
clientes.Add("456", "Eduardo");
produtos.Add("produto1", 22.49f);
produtos.Add("produto2", 15.25f);
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

    if (!clientes.ContainsKey(CPF))
    {
        Console.WriteLine("Digite o nome do Cliente");
        string nome = Console.ReadLine()!;
        clientes.Add(CPF, nome);
        Console.WriteLine($"Usuário {nome} ({CPF}) cadastrado com sucesso.");
        VoltarAoMenuPrincipal();
    }

}

void CadastraProduto()
{
    // Lógica para cadastrar um cliente
    Console.Clear();
    Console.WriteLine("Digite o nome do Produto");
    string nome = Console.ReadLine()!;
    Console.WriteLine("Digite o preço do Produto");
    string precoString = Console.ReadLine()!;
    float preco = float.Parse(precoString);
    produtos.Add(nome, preco);
    Console.WriteLine($"Produto {nome} cadastrado com sucesso.");
    VoltarAoMenuPrincipal();
}

void ListaClientes()
{
    // Lógica para exibir a lista de clientes
    Console.Clear();
    Console.WriteLine("Lista de Clientes:");
    foreach (KeyValuePair<string, string> cliente in clientes)
    {
        Console.WriteLine($"Nome: {cliente.Value}, CPF: {cliente.Key}");
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
        foreach (KeyValuePair<string, float> produto in produtos)
        {
            Console.WriteLine($"Nome: {produto.Key}, Preço: {produto.Value}");
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

    if (!clientes.ContainsKey(CPF))
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
    foreach (KeyValuePair<string, List<string>> cliente in carrinho)
    {
        foreach (string produto in cliente.Value)
        {
            string nomeCliente = clientes[cliente.Key];
            Console.WriteLine($"Nome: {nomeCliente}, Produto: {produto}");
        }
           
    }
    VoltarAoMenuPrincipal();
}

void ListaProdutosDeCliente(string CPF)
{
    float total = 0;
    Console.Clear();
    string nomeCliente = clientes[CPF];
    Console.WriteLine($"Lista produtos no carrinho de {nomeCliente}");
    if (!carrinho.ContainsKey(CPF) || carrinho[CPF].Count() == 0)
    {
        Console.WriteLine("O carrinho está vazio");
    } 
    else
    {
        foreach (string p in carrinho[CPF])
        {
            float valor = produtos[p];
            total += valor;
            Console.WriteLine($"Produto: {p} Valor: {valor}");
        }

        Console.WriteLine($"Total do Carrinho: {total}");
        DadosCartaoUsuario(total);          
    }
}

void DadosCartaoUsuario(float total)
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
    if (produtos.ContainsKey(nomeProduto))
    {
        Console.WriteLine("Digite o novo preço do produto");
        string precoString = Console.ReadLine()!;
        float preco = float.Parse(precoString);
        produtos[nomeProduto] = preco;
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
    if (!clientes.ContainsKey(CPF))
    {
        Console.WriteLine($"Usuário {CPF} não cadastrado.");
    }
    else
    {
        Console.WriteLine("Digite o nome do produto que deseja adicionar");
        string nomeProduto = Console.ReadLine()!;
        if (!produtos.ContainsKey(nomeProduto))
        {
            Console.WriteLine($"Produto {nomeProduto} não cadastrado.");
        }
        else
        {
            //cria a lista do carrinho, caso não exista
            if (!carrinho.ContainsKey(CPF))
            {
                carrinho.Add(CPF, new List<string>());
            }

            carrinho[CPF].Add(nomeProduto);
            string nomeCliente = clientes[CPF];
            Console.WriteLine($"Produto {nomeProduto} de {nomeCliente} ({CPF}) adicionado com sucesso.");
        }

    }   

    VoltarAoMenuPrincipal();
}

ExibirMenuDeOpcoes();





