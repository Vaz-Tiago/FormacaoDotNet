using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Total contas criadas: " + ContaCorrente.TotalDeContasCriadas);
            Console.WriteLine();

            ContaCorrente conta = new ContaCorrente(867, 86712540);

            Console.WriteLine(conta.Agencia);
            Console.WriteLine(conta.Numero);
            Console.WriteLine("Total contas criadas: " + ContaCorrente.TotalDeContasCriadas);
            Console.WriteLine();

            ContaCorrente contaDaGabriela = new ContaCorrente(867, 86745820);
            Console.WriteLine(contaDaGabriela.Agencia);
            Console.WriteLine(contaDaGabriela.Numero);
            Console.WriteLine("Total contas criadas: " + ContaCorrente.TotalDeContasCriadas);


            Console.ReadLine();
        }
    }
}
