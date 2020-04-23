using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    // Representa o banco de dados
    internal class LojaContext : DbContext
    {
        // Cada propriedade desta classe representa uma tabela
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }

        // Para configurar a conexao com o banco de dados é nescessário sobrescrever o método da classe SbContext OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Recebe a string de conexão
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
        }
    }
}