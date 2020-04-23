using ByteBank.Modelos;
using Humanizer;
using System;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Lista<int> idades = new Lista<int>();

            idades.Adicionar(32);
            idades.AdicionarVarios(25, 36, 27);

            for(int i = 0; i < idades.Tamanho; i++)
            {
                int idadeAtual = idades[i];
            }

            Console.ReadLine();
        }

        static void TestaListaDeobject()
        {
            ListaDeObjetc listaDeIdades = new ListaDeObjetc();

            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar("Texto");
            listaDeIdades.Adicionar(5);
            listaDeIdades.AdicionarVarios(17, 26, 38, 45);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                Console.WriteLine(listaDeIdades[i]);
            }
        }
        static void TestaParametrosDinamicosParams()
        {
            ContaCorrente contaVaz = new ContaCorrente(222, 10000000);
            ListaDeContaCorrentes lista = new ListaDeContaCorrentes();
            lista.Adicionar(contaVaz);

            contaVaz.Depositar(1500);

            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(111, 87103824),
                new ContaCorrente(111, 65498132),
                new ContaCorrente(111, 32482843),
                new ContaCorrente(111, 15646645),
                new ContaCorrente(111, 78616846),
                new ContaCorrente(111, 16885385)
            };

            lista.AdicionarVarios(contas);

            contaVaz.Transferir(350.71, lista[5]);
            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i}: {itemAtual}");
            }

        }
        static void TestaArrayDeContaCorrente()
        {
            //ContaCorrente[] contas = new ContaCorrente[3];
            //contas[0] = new ContaCorrente(123, 111222);
            //contas[1] = new ContaCorrente(123, 333444);
            //contas[2] = new ContaCorrente(123, 555666);

            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(123, 111222),
                new ContaCorrente(123, 333444),
                new ContaCorrente(123, 555666)
            };

            for (int indice = 0; indice < contas.Length; indice++)
            {
                ContaCorrente contaAtual = contas[indice];
                Console.WriteLine($"Conta {indice} {contaAtual.Numero}");
            }

            Console.ReadLine();

        }
        static void TestaArryInt()
        {
            // Array de inteiros com 5 posições
            int[] idades = new int[6];
            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;
            idades[3] = 50;
            idades[4] = 28;
            idades[5] = 60;

            int acumulador = 0;

            for (int indice = 0; indice < idades.Length; indice++)
            {
                int idade = idades[indice];
                acumulador += idade;
                Console.WriteLine($"idades[{indice}] - Valor {idade}");
            }

            int media = acumulador / idades.Length;

            Console.WriteLine($"Quantidade de idades: {idades.Length}");
            Console.WriteLine($"Soma de idades: {acumulador}");
            Console.WriteLine($"Média de idades: {media}");

            Console.ReadLine();
        }

    }
}
