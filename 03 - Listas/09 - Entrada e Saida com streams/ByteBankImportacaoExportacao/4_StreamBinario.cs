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

        static void EscritaBinaria()
        {
            using (var fs = new FileStream("ContaCorrente.txt", FileMode.Create))
            using (var escritor = new BinaryWriter(fs))
            {
                escritor.Write(456); // Numero agencia
                escritor.Write(45348); // Numero conta
                escritor.Write(4000.50); // saldo
                escritor.Write("Tiago Vaz"); // titular
            }
        }

        static void LeituraBinaria()
        {
            using (var fs = new FileStream("ContaCorrente.txt", FileMode.Open))
            using (var leitor = new BinaryReader(fs))
            {
                var agencia = leitor.ReadInt32();
                var numeroConta = leitor.ReadInt32();
                var saldo = leitor.ReadDouble();
                var titular = leitor.ReadString();

                Console.WriteLine($"{agencia}/{numeroConta} | {titular} | R$ {saldo}");
            }
        }
    }
}
