using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_AtribuicoesDeVariaveis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 06 - Atribuições de variáveis");

            int idade = 33;
            int idadeTiago = idade;

            idade = 30;

            Console.WriteLine(idade);
            Console.WriteLine(idadeTiago);

            Console.ReadLine();
        }
    }
}
