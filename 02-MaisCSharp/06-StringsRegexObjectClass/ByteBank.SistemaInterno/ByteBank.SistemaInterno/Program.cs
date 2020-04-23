using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaInterno
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(456, 1234658);
            ContaCorrente conta2 = new ContaCorrente(456, 254358);
            conta.Sacar(-10);
            Console.WriteLine(conta.Saldo);

            Console.ReadLine();
        }
    }
}
