using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void UsarStreamDeEntrada()
        {
            // Fluxo não é novo pois o stream da Console já foi criado e está sendo executado
            using (var fluxoDeEntrada = Console.OpenStandardInput())
            using (var fs = new FileStream("EntradaConsole.txt", FileMode.Create))
            {
                var buffer = new byte[1024]; // 1kb
                while (true)
                {
                    var bytesLidos = fluxoDeEntrada.Read(buffer, 0, 1024);
                    fs.Write(buffer, 0, bytesLidos);
                    fs.Flush();

                    Console.WriteLine($"Bytes lidos da Console: {bytesLidos}");
                }
            }
        }
    }
}
