using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            //GravarUsandoEntity();
            //RecuperarProdutos();
            //ExcluirProdutos();
            //Console.WriteLine("Depois de deletar");
            AtualizarProduto();
            //RecuperarProdutos();


        }

        private static void AtualizarProduto()
        {
            // Incluir produto
            GravarUsandoEntity();
            RecuperarProdutos();

            // Atualizar produto
            using (var repo = new ProdutoDAOEntity())
            {
                var primeiroProduto = repo.Produtos().First();
                primeiroProduto.Nome = "Cassino Royale";
                repo.Atualizar(primeiroProduto);
            }
            RecuperarProdutos();
        }

        private static void ExcluirProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                var produtos = repo.Produtos();
                foreach (var item in produtos)
                {
                    repo.Remover(item);
                }
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            // Criando a instancia de Contexto (Abrindo a conexão)
            using (var contexto = new ProdutoDAOEntity())
            {
                // Adicionando a instancia de produto dentro do contexto
                contexto.Adicionar(p);
            }
        }

        private static void RecuperarProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                var produtos = repo.Produtos();
                Console.WriteLine($"Foram encontrados {produtos.Count} produto(s)");
                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
