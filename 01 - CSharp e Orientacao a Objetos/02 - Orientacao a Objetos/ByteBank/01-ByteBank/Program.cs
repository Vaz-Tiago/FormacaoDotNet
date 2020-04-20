using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaDaGrabriela = new ContaCorrente();

            contaDaGrabriela.titular = "Gabriela";
            contaDaGrabriela.agencia = 863;
            contaDaGrabriela.numero = 863452;
            contaDaGrabriela.saldo = 100;

            contaDaGrabriela.saldo += 200;

            Console.WriteLine("Titular: " + contaDaGrabriela.titular);
            Console.WriteLine("Agência: " + contaDaGrabriela.agencia);
            Console.WriteLine("Conta: " + contaDaGrabriela.numero);
            Console.WriteLine("Saldo: " + contaDaGrabriela.saldo);

            Console.ReadLine();
        }
    }
}
