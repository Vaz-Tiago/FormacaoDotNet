using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class LeitorDeArquivo : IDisposable
    {
        public string Arquivo { get; }

        public LeitorDeArquivo(string arquivo)
        {
           // throw new FileNotFoundException();
            Arquivo = arquivo;
            Console.WriteLine("Abrindo Arquivo: " + arquivo);
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo Linha . . . ");
            throw new IOException();
            return "Linha do arquivo";
        }

        //Método substituido pelo dispatch
        //public void Fechar()
        //{
        //    Console.WriteLine("Fechando Arquivo");
        //}

        public void Dispose()
        {
            Console.WriteLine("Fechando Arquivo");
        }
    }
}
