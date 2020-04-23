using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
            using (var contexto = new LojaContext())
            {
                //Configurando um logger que retorna o sql gerado pelo entity
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());


                var produtos = contexto.Produtos.ToList();
                ExibirEntries(contexto.ChangeTracker.Entries());

                var novoProduto = new Produto()
                {
                    Nome = "Sabão em pó",
                    Categoria = "Limpeza",
                    Preco = 8.40
                };
                contexto.Produtos.Add(novoProduto);
                contexto.Produtos.Remove(novoProduto);

                var p1 = produtos.First();
                contexto.Produtos.Remove(p1);

                ExibirEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();
                ExibirEntries(contexto.ChangeTracker.Entries());

                var entry = contexto.Entry(novoProduto);
                Console.WriteLine($"/n/n {entry.Entity.ToString()} - {entry.State}");

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
    }
}
