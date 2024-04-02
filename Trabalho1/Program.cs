using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using Trabalho1.Classes;

var dataSet = File.ReadAllText("..\\..\\..\\dataset.csv");

var listaProdutos = ProdutoParcer.ConverterLista(dataSet);

static void MaisVendidos(List<Produto> produtos)
{
    var produtosOrdenados = produtos.OrderByDescending(p => p.QtdVendida);

    var top5Maisvendidos = produtosOrdenados.Take(5);

    Console.WriteLine("Os 5 produtos mais vendidos são:");
    foreach (Produto produto in top5Maisvendidos)
    {
        Console.WriteLine(String.Format("Código {0} - {1} com {2} unidades vendidas", produto.Codigo, produto.Descricao, produto.QtdVendida));
    }
}

static void ImprimirProdutosComMaisEstoque(List<Produto> produtos, int quantidade)
{
    var produtosOrdenados = produtos.OrderByDescending(p => p.Estoque);

    var topProdutos = produtosOrdenados.Take(3);

    Console.WriteLine($"Os {quantidade} produtos com mais estoque são:");
    foreach (var produto in topProdutos)
    {
        Console.WriteLine($"Nome: {produto.Descricao}, Estoque: {produto.Estoque}");
    }
}

bool sair = false;
while (!sair)
{
    Console.WriteLine(" ");
    Console.WriteLine("Menu de Opções:");
    Console.WriteLine("1. Produtos mais Vendidos");
    Console.WriteLine("2. Produtos com mais Estoque");
    Console.WriteLine("3. Categoria mais Vendida");
    Console.WriteLine("4. Produtos menos Vendidos");
    Console.WriteLine("5. Estoque de Segurança");
    Console.WriteLine("6. Excesso de Estoque");
    Console.WriteLine("7. Media de Preço por Caegoria");
    Console.WriteLine("8. Sair");
    Console.Write("Escolha uma opção: ");

    string escolha = Console.ReadLine();

    switch (escolha)
    {
        case "1":
            MaisVendidos(listaProdutos);
            break;
        case "2":
            ImprimirProdutosComMaisEstoque(listaProdutos, 3);            
            break;
        case "3":
        
            break;
        case "4":
        
            break;
        case "5":

            break;
        case "6":

            break;
        case "7":

            break;
        case "8":
            Console.WriteLine("Saindo...");
            sair = true;
            break;
        default:
            Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
            break;
    }
}
