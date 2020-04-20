using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13D_Fatorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Desafio 13 - Fatorial");

            int fatorial = 1;
            for(int n = 1; n < 11; n++)
            {
                fatorial *= n;
                Console.WriteLine(fatorial);
            }

            Console.ReadLine();
        }
    }
}
