using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_CriandoVariaveisPontoFlutuante
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando o Projeto 03 - Variaveis de ponto flutuante");

            double salario;
            salario = 1200.70;

            Console.WriteLine(salario);

            Console.WriteLine("Idade é double");

            double idade;
            idade = 5 / 3;
            Console.WriteLine("5 / 3 = " + idade);

            idade = 5.0 / 3;
            Console.WriteLine("5.0 / 3 = " + idade);



            Console.WriteLine("A execução acabou!");
            Console.ReadLine();
        }
    }
}
