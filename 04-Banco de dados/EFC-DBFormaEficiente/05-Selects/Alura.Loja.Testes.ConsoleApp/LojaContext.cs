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
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PK Composta
            modelBuilder
                .Entity<PromocaoProduto>()
                .HasKey(pp => new { pp.PromocaoId, pp.ProdutoId });

            // Nomeando tabela Fora do DbSet
            modelBuilder
                .Entity<Endereco>()
                .ToTable("Enderecos");

            // Shadow Property
            // Quando existe um campo na tabela que não precisa ser transferido para a classe
            modelBuilder
                .Entity<Endereco>()
                .Property<int>("ClienteId");
            // Como é Shadow a PK deve ser criada no builder
            modelBuilder
                .Entity<Endereco>()
                .HasKey("ClienteId");

            base.OnModelCreating(modelBuilder);
        }

        // Para configurar a conexao com o banco de dados é nescessário sobrescrever o método da classe SbContext OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Recebe a string de conexão
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
        }
    }
}