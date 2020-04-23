using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Condicionais
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 07 - Condicionais");
            bool promovido = true;
            if (promovido)
            {
                int salario = 5;
            }
            else
            {
                int salario = 2;
            }

            Console.WriteLine(salario);

            Console.ReadLine();
        }
    }
}
