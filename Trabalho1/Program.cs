using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Trabalho1.Classes;

var dataSet = File.ReadAllText("..\\..\\..\\dataset.csv");

var listaProdutos = ProdutoParcer.ConverterLista(dataSet);

static void MaisVendidos(List<Produto> produtos)
{
    var produtosOrdenados = produtos.OrderByDescending(produto => produto.QtdVendida);

    var top5Maisvendidos = produtosOrdenados.Take(5);

    Console.WriteLine("Os 5 produtos mais vendidos são:");
    foreach (Produto produto in top5Maisvendidos)
    {
        Console.WriteLine(String.Format("Código {0} - {1} com {2} unidades vendidas", produto.Codigo, produto.Descricao, produto.QtdVendida));
    }
}
//
static void ImprimirProdutosComMaisEstoque(List<Produto> produtos, int quantidade)
{
    var produtosOrdenados = produtos.OrderByDescending(produto => produto.Estoque);

    var topProdutos = produtosOrdenados.Take(3);

    Console.WriteLine($"Os {quantidade} produtos com mais estoque são:");
    foreach (var produto in topProdutos)
    {
        Console.WriteLine($"Nome: {produto.Descricao}, Estoque: {produto.Estoque}");
    }
}

static void CategoriaMaisVendida(List<Produto> produtos)
{
    var vendasPorCategoria = produtos
        .GroupBy(produto => produto.Categoria)
        .Select(group => new { Categoria = group.Key, TotalVendido = group.Sum(produto => produto.QtdVendida) });

    var categoriaMaisVendida = vendasPorCategoria.OrderByDescending(c => c.TotalVendido).FirstOrDefault();

    if (categoriaMaisVendida != null)
    {
        Console.WriteLine("A categoria mais vendida é:");
        Console.WriteLine($"{categoriaMaisVendida.Categoria}, Total vendido: {categoriaMaisVendida.TotalVendido} unidades");
    }
    else
    {
        Console.WriteLine("Nenhuma categoria encontrada");
    }
}

static void ProdutosMenosVendidos(List<Produto> produtos)
{
    var produtosMenosVendidos = produtos.OrderBy(produto => produto.QtdVendida).Take(5);

    Console.WriteLine("Os 5 produtos menos vendidos são:");
    foreach (var produto in produtosMenosVendidos)
    {
        Console.WriteLine($"Código {produto.Codigo} - {produto.Descricao}: {produto.QtdVendida} unidades vendidas");
    }
}

static void EstoqueSeguranca(List<Produto> produtos)
{
    foreach (var produto in produtos)
    {
        decimal totalVendido = produto.QtdVendida;
        decimal estoqueMinimo = totalVendido * 0.33m;

        if (produto.Estoque < estoqueMinimo)
        {
            Console.WriteLine($"Produto com estoque de segurança: Código {produto.Codigo} - {produto.Descricao}: Estoque {produto.Estoque}");
        }
    }
}

static void ExcessoEstoque(List<Produto> produtos)
{
    foreach (var produto in produtos)
    {
        decimal tresVezesTotalVendido = produto.QtdVendida * 3;

        if (produto.Estoque >= tresVezesTotalVendido)
        {
            Console.WriteLine($"Excesso de estoque: Código {produto.Codigo} - {produto.Descricao}: Estoque {produto.Estoque}");
        }
    }
}

static void MediaPrecoPorCategoria(List<Produto> produtos)
{
    var mediaPorCategoria = produtos
        .GroupBy(produto => produto.Categoria)
        .Select(group => new { Categoria = group.Key, PrecoMedio = group.Average(produto => produto.Preco) });

    Console.WriteLine("Média de preço por categoria:");
    foreach (var media in mediaPorCategoria)
    {
        Console.WriteLine($"Categoria: {media.Categoria}, Preço médio: {media.PrecoMedio:C2}");
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
            CategoriaMaisVendida(listaProdutos);
            break;
        case "4":
            ProdutosMenosVendidos(listaProdutos);
            break;
        case "5":
            EstoqueSeguranca(listaProdutos);
            break;
        case "6":
            ExcessoEstoque(listaProdutos);
            break;
        case "7":
            MediaPrecoPorCategoria(listaProdutos);
            break;
        case "8":
            Console.WriteLine("Saindo...");
            sair = true;
            break;
        default:
            Console.WriteLine("Opção inválida, tente novamente.");
            break;
    }
}
