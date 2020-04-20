using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_ConversoesEOutrosTiposNumericos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 04 - Conversão de tipos");

            double salario;
            salario = 11200.50;

            //Casting
            int salarioInteiro;
            salarioInteiro = (int)salario;

            short quantidadeProdutos;
            quantidadeProdutos = 15000;


            Console.ReadLine();
        }
    }
}
