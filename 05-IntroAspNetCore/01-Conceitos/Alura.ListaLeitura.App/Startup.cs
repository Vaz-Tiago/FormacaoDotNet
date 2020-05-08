using Alura.ListaLeitura.App.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    // Startup agora tem a responsabilidade apenas de inicializar a aplicação.
    //Injetando o sistema de roteamento e mapeando as rotas
    public class Startup
    {
        // Método de configuração dos serviços

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        // Método de configuração da app
        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            // Criar as rotas de forma dinamica
            builder.MapRoute("{classe}/{metodo}", RoteamentoPadrao.TratamentoPadrao);

            // Construindo o roteamento pelo AspNetCore
            // Faz o que o dictionary fez;
            // Parametros: 1. Rota 2. Ação
            //builder.MapRoute("Livros/ParaLer", LivrosLogica.ParaLer);
            //builder.MapRoute("Livros/Lendo", LivrosLogica.Lendo);
            //builder.MapRoute("Livros/Lidos", LivrosLogica.Lidos);
            //builder.MapRoute("Livros/Detalhes/{id:int}", LivrosLogica.Detalhes);
            //builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", CadastroLogica.NovoLivro);
            //builder.MapRoute("Cadastro/ExibeFormulario", CadastroLogica.ExibeFormulario);
            //builder.MapRoute("Cadastro/Incluir", CadastroLogica.Incluir);

            // Constroi o builder dentro de uma variavel rotas
            var rotas = builder.Build();

            // Define o roteamento da aplicação
            app.UseRouter(rotas);

            //app.Run(Roteamento);
        }

        // Roteamento feito a mão
        //public Task Roteamento(HttpContext context)
        //{
        //    var _repo = new LivroRepositorioCSV();
        //    var caminhosAtendidos = new Dictionary<string, RequestDelegate>
        //    {
        //        {"/Livros/ParaLer", LivrosParaLer },
        //        {"/Livros/Lendo", LivrosLendo },
        //        {"/Livros/Lidos", LivrosLidos },
        //    };

        //    if (caminhosAtendidos.ContainsKey(context.Request.Path))
        //    {
        //        var metodo = caminhosAtendidos[context.Request.Path];
        //        // Retornando um método na resposta
        //        return metodo.Invoke(context);
        //        //return context.Response.WriteAsync(caminhosAtendidos[context.Request.Path]);
        //    }
        //    context.Response.StatusCode = 404;
        //    return context.Response.WriteAsync("Caminho inexistente");

        //    //return context.Response.WriteAsync(context.Request.Path); // Corta todo o dominio e mostra apenas o endeço
        //}
    }
}