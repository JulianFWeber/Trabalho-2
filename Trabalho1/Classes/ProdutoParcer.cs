using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Trabalho1.Classes
{
    public class ProdutoParcer
    {

        public enum Header
        {
            Codigo = 0,
            descricao = 1,
            categoria = 2,
            preco = 3,
            estoque = 4,
            QtdVendida = 5,

        }
        public static List<Produto> ConverterLista(string arquivo)
        {
            List<Produto> produtos = new();

            var linhas = arquivo.Split('\n').ToList();

            linhas.Remove(linhas.First());
            
            foreach (var linha in linhas)
            {
                Produto produto = new()
                {
                    Codigo = Convert.ToInt32(linha.Split(';')[0]),
                    Descricao = linha.Split(';')[1],
                    Categoria = linha.Split(';')[2],
                    Preco = Convert.ToDouble(linha.Split(';')[3]),
                    Estoque = Convert.ToInt32(linha.Split(';')[4]),
                    QtdVendida = Convert.ToInt32(linha.Split(';')[5])
                    };

                produtos.Add(produto);
            }
            return produtos;
        }
    }

}
