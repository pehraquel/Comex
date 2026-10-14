using System;
using System.Collections.Generic;
using System.Text;

namespace COMEX.Menus;

internal class Menu<T>
{
    public virtual void Executar(List<T> itens)
    {
        Console.Clear();
    }


    public void VoltarAoMenuPrincipal()
    {
        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        Console.Clear();
        ExibirMenuDeOpcoes();
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

    }
}

