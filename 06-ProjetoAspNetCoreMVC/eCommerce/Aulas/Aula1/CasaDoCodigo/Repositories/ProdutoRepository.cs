using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Produto> GetProdutos()
        {
            // Pega todos os registros e converte para uma lista.
            return dbSet.ToList();
        }

        public void SaveProdutos(List<Livro> livros)
        {
            // Criando loop para gravação dos livros no banco de dados
            // Adicionar ao dbset, não altera o banco de dados, as informações estão apenas em memória
            // Isso ocorre para que não seja aberta uma conexao com o banco a cada equena alteração, depois de fazer as alterações
            // Todo o conteúdo é alterado de uma vez
            foreach (var livro in livros)
            {
                if(!dbSet.Where(p=> p.Codigo == livro.Codigo).Any())
                {
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }
            }

            // Isso faz a gravação no banco de dados

        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }

}