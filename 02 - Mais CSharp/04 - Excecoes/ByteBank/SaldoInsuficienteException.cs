using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class SaldoInsuficienteException : OperacaoFinanceiraException
    {
        // ----- | PROPRIEDADES | ----- //

        public double Saldo { get; }
        public double ValorSaque { get; }


        // ----- | CONSTRUTORES | ----- //

        public SaldoInsuficienteException() { }
        public SaldoInsuficienteException(string mensagem) : base(mensagem) { }

        // Novo construtor com complemento do construtor já existente
        public SaldoInsuficienteException(double saldo, double valorSaque)
            : this("Tentiva de saque no valor de R$" + valorSaque + " em uma conta com saldo de R$" + saldo)
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }

        // Construtor InnerException
        public SaldoInsuficienteException(string mensagem, Exception excecaoInterna) : base(mensagem, excecaoInterna) { }
    }
}
