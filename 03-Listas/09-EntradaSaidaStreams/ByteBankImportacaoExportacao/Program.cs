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
        static void Main(string[] args)
        {
            // Classe file Auxiliando ao ler arquivos

            File.WriteAllText("escrevendoComAClasseFile.txt", "Apenas um teste");
            Console.WriteLine("Arquivo escrevendoComAClasseFile.txt Criado");

            Console.ReadLine();


            var bytesArquivo = File.ReadAllBytes("contas.txt");

            Console.WriteLine(bytesArquivo);
            Console.ReadLine();


            var linhas = File.ReadAllLines("contas.txt");
            Console.WriteLine(linhas.Length);

            foreach (var linha in linhas)
            {
                Console.WriteLine(linha);
            }

            Console.ReadLine();



            Console.WriteLine("Digite seu nome");
            var nome = Console.ReadLine();

            Console.WriteLine("Bem vindo " + nome);

            UsarStreamDeEntrada();

            Console.WriteLine("Aplicação finalizada...");
            Console.ReadLine();
        }
    }
} 
 