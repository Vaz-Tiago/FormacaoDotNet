using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo
{
    public partial class Startup
    {
        // Criando Classe DataService para adicionar informação
        class DataService : IDataService

        {
            private readonly ApplicationContext contexto;
            private readonly IProdutoRepository produtosRepository;

            // ApplicationContext é por padrão  gerado pela injeção de dependencia, ou seja, 
            // Ao utiliza-lo já possibilita o acesso ao objeto contexto
            public DataService(ApplicationContext contexto, IProdutoRepository produtosRepository)
            {
                this.contexto = contexto;
                this.produtosRepository = produtosRepository;
            }

            public void IncializaDB()
            {
                contexto.Database.Migrate();

                List<Livro> livros = GetLivros();

                produtosRepository.SaveProdutos(livros);
                contexto.SaveChanges();
            }

            private static List<Livro> GetLivros()
            {
                var json = File.ReadAllText("livros.json");
                // Newtonsoft, biblioteca para manipulação de json
                var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
                return livros;
            }
        }
    }


}
