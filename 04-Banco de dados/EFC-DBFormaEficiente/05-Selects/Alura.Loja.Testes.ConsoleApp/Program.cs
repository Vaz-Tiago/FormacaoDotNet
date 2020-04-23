using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var cliente = contexto
                    .Clientes
                    .Include(c => c.EnderecoDeEntrega)
                    .FirstOrDefault();

                Console.WriteLine($"Endereço de entrega {cliente.EnderecoDeEntrega.Logradouro}");

                var produto = contexto
                    .Produtos
                    .Where(p => p.Id == 3002)
                    .FirstOrDefault();

                // Fazendo where dentro do include
                // Necessário dois selects
                contexto.Entry(produto) // Argumento o primeiro select
                    .Collection(p => p.Compras) // Define que o select vai ser dentro de Compras
                    .Query() // Diz que vai fazer uma nova query
                    .Where(c => c.Preco > 10) // Passa as condições da query
                    .Load(); // Carrega essa query para dentro de produtos
                
                Console.WriteLine($"Mostrando as compras do produto {produto.Nome}");
                foreach (var item in produto.Compras)
                {
                    Console.WriteLine($"Foram comprados {item.Quantidade} {item.Produto.Nome}");
                }
            }
        }

        // joins
        private static void SelectProdutosPromocaoMtM()
        {
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                // Select Many to Many
                var promocao = contexto
                    .Promocoes
                    .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)
                    .FirstOrDefault();
                Console.WriteLine("Mostrando os produtos da promoção");

                foreach (var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }
        }
        private static void IncluirPromocao()
        {
            using (var contexto = new LojaContext())
            {

                var promocao = new Promocao();
                promocao.Descricao = "Queima de abril";
                promocao.DataInicio = new DateTime(2020, 4, 1);
                promocao.DataTermino = new DateTime(2020, 4, 30);

                var produtos = contexto
                    .Produtos
                    .Where(p => p.Categoria == "Bebidas")
                    .ToList();

                foreach (var item in produtos)
                {
                    promocao.IncluirProduto(item);
                }

                contexto.Promocoes.Add(promocao);
                contexto.SaveChanges();
            }
        }
        private static void IncluirBebidas(LojaContext contexto)
        {
            var vinho = new Produto() { Nome = "Vinho", Categoria = "Bebidas", PrecoUnitario = 47.30, Unidade = "Litro" };
            var breja = new Produto() { Nome = "Cerveja", Categoria = "Bebidas", PrecoUnitario = 3.30, Unidade = "ml" };

            contexto.Produtos.Add(vinho);
            contexto.Produtos.Add(breja);

            contexto.SaveChanges();
        }

        // Relacionamentos
        private static void AddClienteEnderecoOtM()
        {
            var fulano = new Cliente();
            fulano.Nome = "Fulaninho de Tal";
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 12,
                Logradouro = "Rua Nenhuma",
                Complemento = "Sobrado",
                Bairro = "Centro",
                Cidade = "Iventada"
            };

            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                contexto.Clientes.Add(fulano);
                contexto.SaveChanges();
            }
        }
        private static void ExibirEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("---------------------");

            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " | " + e.State);
            }
        }
        private static void AddPromocaoPascoaMtM()
        {
            var p1 = new Produto() { Nome = "Suco de laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Litros" };
            var p2 = new Produto() { Nome = "Café", Categoria = "Bebidas", PrecoUnitario = 12.49, Unidade = "Gramas" };
            var p3 = new Produto() { Nome = "Macarrão", Categoria = "Alimentos", PrecoUnitario = 4.23, Unidade = "Gramas" };

            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Pascoa de Quarentena";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);
            promocaoDePascoa.IncluirProduto(p1);
            promocaoDePascoa.IncluirProduto(p2);
            promocaoDePascoa.IncluirProduto(p3);

            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                //contexto.Promocoes.Add(promocaoDePascoa);
                //ExibirEntries(contexto.ChangeTracker.Entries());

                // Remover a promocao
                var promocao = contexto.Promocoes.Find(1);
                contexto.Promocoes.Remove(promocao);
                contexto.SaveChanges();

            }
        }
        static void ComprarPao(int quantidade)
        {
            // compra de pao
            var paoFrances = new Produto();
            paoFrances.Nome = "Pão Frances";
            paoFrances.PrecoUnitario = 0.40;
            paoFrances.Unidade = "Unidades";
            paoFrances.Categoria = "Padaria";

            var compra = new Compra();
            compra.Quantidade = quantidade;
            compra.Produto = paoFrances;
            compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

            using (var contexto = new LojaContext())
            {
                // Ao adicionar uma compra que se refere a um objeto que não existe no banco de dados
                // O entity percebe que essa referencia não existe e adiciona a instancia de produto também no banco
                contexto.Compras.Add(compra);
                contexto.SaveChanges();
            }
        }
    }
}
