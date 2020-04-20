using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_CaracteresETexto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 05");

            char primeiraLetra = 'a';
            Console.WriteLine(primeiraLetra);

            primeiraLetra = (char)65;
            Console.WriteLine(primeiraLetra);

            primeiraLetra = (char)(primeiraLetra + 1);
            Console.WriteLine(primeiraLetra);

            string titulo = "Tiago Vaz";
            Console.WriteLine(titulo);

            string variasLinhas = @"Essa string,
                pode ser quebrada em várias linhas.
                E irá retornar na tela exatamento como está aqui
                Até com os tabs de identação";

            Console.WriteLine(variasLinhas);

            Console.ReadLine();
        }
    }
}
