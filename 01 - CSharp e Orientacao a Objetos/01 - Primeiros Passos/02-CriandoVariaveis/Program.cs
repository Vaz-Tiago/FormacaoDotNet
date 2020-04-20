using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CriandoVariaveis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando Projeto 02 - Criando Variaveis");

            int idade;
            idade = 33;

            idade = 10 + 5;
            Console.WriteLine(idade);

            idade = 10 + 5 * 2;
            Console.WriteLine(idade);

            idade = (10 + 5) * 2;
            Console.WriteLine(idade);

            Console.WriteLine("Minha idade é " + idade + " anos");

            Console.WriteLine("Programa finalizado. Tecle enter para sair!");
            Console.ReadLine();
        }
    }
}
