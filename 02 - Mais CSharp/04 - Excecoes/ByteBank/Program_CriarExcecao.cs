//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ByteBank
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            try
//            {
//                ContaCorrente conta = new ContaCorrente(456, 4578420);
//                ContaCorrente conta2 = new ContaCorrente(524, 4324824);
//                conta2.Transferir(1000, conta);
//                conta.Depositar(-10);
//                Console.WriteLine(conta.Saldo);
//                //conta.Sacar(-500);
//            }
//            catch(ArgumentException e)
//            {
//                Console.WriteLine("ERRO! ArgumentException");
//                Console.WriteLine(e.Message);
//            }
//            catch(SaldoInsuficienteException e)
//            {
//                Console.WriteLine(e.ValorSaque);
//                Console.WriteLine(e.Saldo);

//                Console.WriteLine("ERRO! SaldoInsuficienteException");
//                Console.WriteLine(e.Message);

//                Console.WriteLine();
//                Console.WriteLine(e.StackTrace);
//            }

//            Console.WriteLine();
//            Console.WriteLine("Execução finalizada. Tecle Enter para sair");
//            Console.ReadLine();
//        }
//    }
//}
