using ByteBank.Modelos;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 245),
                new ContaCorrente(342, 999),
                null,
                new ContaCorrente(342, 4),
                new ContaCorrente(342, 1),
                null,
                null,
                new ContaCorrente(343, 10),
                new ContaCorrente(290, 35),
            };

            /*
            var listaSemNulos = new List<ContaCorrente>();

            foreach (var conta in contas)
            {
                if (conta != null)
                    listaSemNulos.Add(conta);
            }
            */
            
            // var contasNaoNulas = contas.Where(conta => conta != null); // Equivalente ao comentado acima

            // Equivalente a todo o código acima
            var contasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero );

            foreach (var conta in contasOrdenadas)
            {
                Console.WriteLine($"Ag: {conta.Agencia}, Cc: {conta.Numero}");
            }


            Console.ReadLine();
        }

        static void TestaSort()
        {
            var nomes = new List<string>() { "Tiago", "Cibele", "Maria" };

            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }

            var idades = new List<int>();

            idades.Add(32);
            idades.Add(26);
            idades.Add(19);
            idades.AdicionarVarios(250, 450, 650);

            idades.Sort();

            for (int i = 0; i < idades.Count; i++)
            {
                int idadeAtual = idades[i];
                Console.WriteLine(idadeAtual);
            }
        }
        static void TesteExpressaoLambdaSimples()
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 245),
                new ContaCorrente(342, 999),
                null,
                new ContaCorrente(342, 4),
                new ContaCorrente(342, 1),
                null,
                null,
                new ContaCorrente(343, 10),
                new ContaCorrente(290, 35),
            };

            // contas.Sort(); -> Chama a implementação dadda em IComparable
            // contas.Sort(new ComparadorContaCorrentePorAgencia());

            IOrderedEnumerable<ContaCorrente> contasOrdenadas =
                contas.OrderBy(conta => {
                    if (conta == null)
                    {
                        return int.MaxValue;
                    }
                    return conta.Numero;
                });

            foreach (var conta in contasOrdenadas)
            {
                if (conta != null)
                {
                    Console.WriteLine($"Ag: {conta.Agencia}, Cc: {conta.Numero}");
                }
            }
        }

    }

}
