using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class modulos05
    {

        static void TestaString()
        {
            string url = "http://pagina.com.br/conversao?moedaOrigem=real&moedaDestino=dolar&valor=1500";

            Console.WriteLine("|------------------- ---------------- ---------------- ------------------ || ");
            Console.WriteLine();

            Console.WriteLine("URL completa: ");
            Console.WriteLine("  " + url);
            Console.WriteLine();

            int indiceInterrogacao = url.IndexOf('?');
            Console.WriteLine("Posição da URL referente à interrogação: " + indiceInterrogacao);
            Console.WriteLine();

            string argumentos = url.Substring(indiceInterrogacao + 1);
            Console.WriteLine("Argumentos: ");
            Console.WriteLine("  " + argumentos);

            Console.WriteLine();
            Console.WriteLine("|------------------- ---------------- ---------------- ------------------ || ");
            Console.WriteLine();

            Console.WriteLine("Recebendo os valores de cada argumento: ");
            Console.WriteLine();

            Console.WriteLine("Tamanho da string: " + argumentos.Length);

            string nomeArgumento = "moedaDestino=";

            int indiceMoedaDestino = argumentos.IndexOf(nomeArgumento);
            Console.WriteLine("Indice do argumento moedaDestino: " + indiceMoedaDestino);
            string argumentoMoedaDestino = argumentos.Substring(indiceMoedaDestino + nomeArgumento.Length);
            Console.WriteLine("Argumento MoedaDestino: " + argumentoMoedaDestino);

            Console.WriteLine();
            Console.WriteLine("|------------------- ---------------- ---------------- ------------------ || ");
            Console.WriteLine();

            Console.WriteLine("Teste de remoção, remover tudo da string após o &");
            Console.WriteLine();

            string testeRemocao = "primeiraParte&parteRemover";
            int indiceEComercial = testeRemocao.IndexOf('&');

            Console.WriteLine("String completa: " + testeRemocao);
            Console.WriteLine("Após o .Remove() " + testeRemocao.Remove(indiceEComercial));

            Console.WriteLine();
            Console.WriteLine("|------------------- ---------------- ---------------- ------------------ || ");
            Console.WriteLine();

            Console.WriteLine("Extraindo os argumentos da url com a classe ExtratorValorDeArgumentosURL");
            Console.WriteLine();

            ExtratorValorDeArgumentosURL extratorDeValores = new ExtratorValorDeArgumentosURL(url);
            string valorDestino = extratorDeValores.GetValor("moedaDestino");
            Console.WriteLine("Valor da moedaDestino: " + valorDestino);
            Console.WriteLine();
            string valorOrigem = extratorDeValores.GetValor("moedaOrigem");
            Console.WriteLine("Valor da moedaOrigem: " + valorOrigem);
            Console.WriteLine();
            string valorQuantia = extratorDeValores.GetValor("valor");
            Console.WriteLine("Quantia a ser convertida: " + valorQuantia);

            Console.WriteLine();
            Console.WriteLine("|------------------- ---------------- ---------------- ------------------ || ");
            Console.WriteLine();

            Console.ReadLine();
        }
        static void TestaRegex()
        {
            //string padraoTelefone = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            //string padraoTelefone = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            //string padraoTelefone = "[0-9]{4}[-][0-9]{4}";
            //string padraoTelefone = "[0-9]{4,5}[-][0-9]{4}";
            //string padraoTelefone = "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            //string padraoTelefone = "[0-9]{4,5}-{0,1}[0-9]{4}";
            string padraoTelefone = "[0-9]{4,5}-?[0-9]{4}";

            string textoDeTeste = "Olá, meu nome é Tiago e meu telefone é 54585-3458";
            Console.WriteLine("Padrão: " + padraoTelefone);
            Console.WriteLine("Texto: " + textoDeTeste);
            Console.WriteLine();

            Console.WriteLine("Método IsMatch: " + Regex.IsMatch(textoDeTeste, padraoTelefone));

            Match retuldado = Regex.Match(textoDeTeste, padraoTelefone);
            Console.WriteLine("Objeto Match: " + retuldado.Value);

            Console.ReadLine();
        }
        static void OverrideMetodosStringEquals()
        {
            ContaCorrente conta = new ContaCorrente(1452, 25364);
            Console.WriteLine("Resultado: " + conta.ToString());

            Console.WriteLine();
            Console.WriteLine("|------------------- ---------------- ---------------- ------------------ || ");
            Console.WriteLine();

            Cliente cliente1 = new Cliente();
            cliente1.Nome = "Joao";
            cliente1.CPF = "111.222.333-44";
            cliente1.Profissao = "Professor";

            Cliente cliente2 = new Cliente();
            cliente2.Nome = "Joao";
            cliente2.CPF = "111.222.333-44";
            cliente2.Profissao = "Professor";

            if (cliente1.Equals(conta))
            {
                Console.WriteLine("São Iguais");
            }
            else
            {
                Console.WriteLine("Não são iguais");
            }

        }
    }
}
