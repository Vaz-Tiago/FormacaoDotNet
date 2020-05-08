using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Mvc
{
    public class RoteamentoPadrao
    {
        public static Task TratamentoPadrao(HttpContext context)
        {
            //rota padrão: /<Classe>Logica/Metodo
            //{classe}/{metodo}

            var classe = Convert.ToString(context.GetRouteValue("classe"));
            var nomeMetodo = Convert.ToString(context.GetRouteValue("metodo"));

            var nomeCompleto = $"Alura.ListaLeitura.App.Logica.{classe}Logica";

            // Lib Reflection. Para refletir a tipagem de objetos, metodos ou o que for, dinamicamente
            // Pega o tipo da classe
            var tipo = Type.GetType(classe);
            // Procura pelo metodo na classe
            var metodo = tipo.GetMethods().Where(m => m.Name == nomeMetodo).First();

            // Criando um delegate para a request
            // Guarda a assinatura de um metodo em uma variavel mas não o executa.
            // Quando desejar executar utiliza o Invoke() e passa os argumentos
            var requestDelegate = (RequestDelegate)Delegate.CreateDelegate(typeof(RequestDelegate), metodo);

            return requestDelegate.Invoke(context);
        }
    }
}
