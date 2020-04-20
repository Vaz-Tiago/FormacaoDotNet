using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaDaGrabriela = new ContaCorrente();
            contaDaGrabriela.titular = "Gabriela";
            contaDaGrabriela.agencia = 863;
            contaDaGrabriela.numero = 863452;

            ContaCorrente contaGabrielaCosta = new ContaCorrente();
            contaGabrielaCosta.titular = "Gabriela";
            contaGabrielaCosta.agencia = 863;
            contaGabrielaCosta.numero = 863452;

            Console.WriteLine("Igualdade de tipo de referência: " + (contaDaGrabriela == contaGabrielaCosta));

            int idade1 = 10;
            int idade2 = 10;

            Console.WriteLine("Igualdade de tipo de valor: " + (idade1 == idade2));

            contaDaGrabriela = contaGabrielaCosta;
            Console.WriteLine(contaDaGrabriela == contaGabrielaCosta);

            contaDaGrabriela.saldo = 300;
            Console.WriteLine(contaDaGrabriela.saldo);
            Console.WriteLine(contaGabrielaCosta.saldo);
            Console.ReadLine();

        }
    }
}
