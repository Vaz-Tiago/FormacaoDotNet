using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Alura.ListaLeitura.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var _repo = new LivroRepositorioCSV();

            //Habilitando projeto para receber requisições web
            IWebHost host = new WebHostBuilder()
                .UseKestrel() // Indica Qual servidor deve ser utilizado
                .UseStartup<Startup>() // Aponta para a classe responsável pela configuração de inicialização do server
                .Build(); // Constroi o servidor
            host.Run();

            //ImprimeLista(_repo.ParaLer);
            //ImprimeLista(_repo.Lendo);
            //ImprimeLista(_repo.Lidos);
        }

        static void ImprimeLista(ListaDeLeitura lista)
        {
            Console.WriteLine(lista);
        }
    }
}
