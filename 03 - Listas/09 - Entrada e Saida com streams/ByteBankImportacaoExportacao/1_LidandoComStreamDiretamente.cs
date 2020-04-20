using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO; // Input Output

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            // Existe uma implmentação para cuidar do tipo encode de caracteres no .net
            var utf8 = new UTF8Encoding();

            var texto = utf8.GetString(buffer, 0, bytesLidos);

            Console.Write(texto);

            //foreach (var meuByte in buffer)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }

        // Aulas Anteriors
        static void TesteModulo01()
        {
            var fs = new FileStream("teste01.txt", FileMode.Open);

            var buffer01 = new byte[1024];
            var encoding = Encoding.ASCII;

            var bytesLidos = fs.Read(buffer01, 0, 1024);
            var conteudoArquivo = encoding.GetString(buffer01, 0, bytesLidos);


            Console.Write(conteudoArquivo);
        }
        static void LidandoComStreamDiretamente()
        {
            var enderecoDoArquivo = "contas.txt";

            // Abre o arquivo

            // Roda o bloco enquanto o arquivo estiver sendo utilizado
            // Libera o arquivo após a finalização ou lançamento de alguma exceção
            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                // buffer e a quantidade de memória disponibilizada pelo aplicativo para a leitura do arquivo externo.
                // A cada kbyte lido ele faz uma nova leitura e segue assim até chegar ao final do arquivo
                // Quando chega no final, ele retorna 0, pois não há mais nada para ser lido.
                var buffer = new byte[1024]; //1kb
                var numeroDeBytesLidos = -1;

                while (numeroDeBytesLidos != 0)
                {
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    Console.WriteLine($"Bytes Lisdos: {numeroDeBytesLidos}");
                    EscreverBuffer(buffer, numeroDeBytesLidos);

                }
            }
        }

    }
}
