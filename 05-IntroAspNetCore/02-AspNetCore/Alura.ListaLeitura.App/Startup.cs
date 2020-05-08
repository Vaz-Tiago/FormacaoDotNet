using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Adicionando o AspNetCore
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app)
        {
            // Mostra os erros no navegador
            app.UseDeveloperExceptionPage();
            // Utiliza o sistema padrao de roteamento do framework
            app.UseMvcWithDefaultRoute();
 
        }
    }
}