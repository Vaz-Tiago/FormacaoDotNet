using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_EncadeandoFor02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 13  - Encadeando FOR - Utilizando Break");

            for(int contadorLinha = 1; contadorLinha < 10; contadorLinha++)
            {
                for(int contadorColuna = 1; contadorColuna <= contadorLinha; contadorColuna++)
                    Console.Write("*");
                    /* break para a repetição do for imediatamente acima dele se a condição for satisfeita
                        if (contadorColuna >= contadorLinha)
                            break;
                    */

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
