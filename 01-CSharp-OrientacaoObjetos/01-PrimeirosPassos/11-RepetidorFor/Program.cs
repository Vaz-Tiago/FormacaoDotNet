using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_RepetidorFor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 11 - FOR");

            double valorInvestido = 1000;

            for (int contadorMes = 1;  contadorMes <= 12; contadorMes++)
            {
                string msg = contadorMes == 1 ? " mês, você terá R$ " : " meses, você terá R$ ";
                // valorInvestido = valorInvestido + valorInvestido * 0.0036;
                valorInvestido *= 1.0036; 
                Console.WriteLine("Após " + contadorMes + msg + valorInvestido);
            }

            Console.ReadLine();
        }
    }
}
