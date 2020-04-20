using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarregarContas();
            }
            catch (Exception)
            {
                Console.WriteLine("CATCH NO METODO MAIN");
            }

            Console.WriteLine();
            Console.WriteLine("Programa Finalizado");
            Console.ReadLine();
        }

        private static void CarregarContas()
        {

            using(LeitorDeArquivo leitor = new LeitorDeArquivo("texte.txt"))
            {
                leitor.LerProximaLinha();
            }

            //----- | Try / Catch / Finally | ----- \\
            //LeitorDeArquivo leitor = null;
            //try
            //{
            //    leitor = new LeitorDeArquivo("contas.txt");
            //    leitor.LerProximaLinha();
            //}
            //catch (IOException)
            //{
            //    Console.WriteLine("Exceção do tipo IOException capturada e tratada");
            //}
            //finally
            //{
            //    if (leitor != null)
            //        leitor.Fechar();
            //}
        }

        private static void TestaInnerException()
        {
            try
            {
                ContaCorrente conta = new ContaCorrente(456, 4578420);
                ContaCorrente conta2 = new ContaCorrente(524, 4324824);
                //conta2.Transferir(1000, conta);
                //conta.Depositar(-10);
                conta.Sacar(-500);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ERRO! ArgumentException");
                Console.WriteLine(e.Message);
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                //Console.WriteLine(e.InnerException);
            }

            Console.WriteLine();
            Console.WriteLine("Execução finalizada. Tecle Enter para sair");
            Console.ReadLine();
        }
    }
}
