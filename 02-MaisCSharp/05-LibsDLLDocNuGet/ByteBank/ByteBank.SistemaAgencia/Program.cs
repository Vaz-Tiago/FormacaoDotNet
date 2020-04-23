using ByteBank.Modelos;
using Humanizer;
using System;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dataFimPagamento = new DateTime(2020, 4, 17);
            DateTime dataCorrente = DateTime.Now;

            TimeSpan diferenca = TimeSpan.FromHours(1500); //dataFimPagamento - dataCorrente;

            //Console.WriteLine("hoje é " + dataCorrente);
            //Console.WriteLine(dataFimPagamento);

            string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);

            Console.WriteLine(mensagem);

            Console.ReadLine();
        }



    }
}
