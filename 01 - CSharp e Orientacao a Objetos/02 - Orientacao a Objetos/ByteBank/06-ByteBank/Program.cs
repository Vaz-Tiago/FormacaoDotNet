using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente();
            // Getters e Setters como propriedade
            conta.Saldo = 500;
            Console.WriteLine(conta.Saldo);

            Cliente cliente = new Cliente();
            cliente.Nome = "Tiago";
            cliente.CPF = "111.222.333.44";
            cliente.Profissao = "Desenvolvedor";

            conta.Titular = cliente;
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(conta.Titular.Nome);


            /*
             * Como métodos:
             * conta.SetSaldo(500);
             * 
             * Console.WriteLine(conta.GetSaldo());
            */

            Console.ReadLine();
        }
    }
}
