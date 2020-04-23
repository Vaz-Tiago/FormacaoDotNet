using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13D_Repeticao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Multiplos de 3");

            for (int contador = 3; contador <= 100; contador += 3)
                Console.WriteLine(contador);

            Console.ReadLine();
        }
    }
}
