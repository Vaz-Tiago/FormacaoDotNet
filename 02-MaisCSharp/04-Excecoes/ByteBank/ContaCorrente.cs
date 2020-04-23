using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class ContaCorrente
    {
        // ----- | PROPRIEDADES | ----- //

        public static double TaxaOperacao { get; private set; }
        public Cliente Titular { get; set; }

        // Setar apenas o get torna a propriedade somente leitura (readonly)
        // Isso permite que ela seja setada apenas no construtor

        public int Numero { get; } 
        public int Agencia { get; }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }
        
        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        // Particularidades da classe

        public static int TotalDeContasCriadas { get; private set; }

        // ----- | CONSTRUTOR | ----- //


        public ContaCorrente(int numeroAgencia, int numeroConta)
        {
            if (numeroAgencia <= 0 )
            {
                ArgumentException excecao = new ArgumentException("O Argumento " + nameof(numeroAgencia) + " deve ser maior que zero.", nameof(numeroAgencia));
                throw excecao;
            }
            if (numeroConta <= 0)
            {
                ArgumentException excecao = new ArgumentException("O Argumento " + nameof(numeroConta) + " deve ser maior que zero.", nameof(numeroConta));
                throw excecao;
            }

            Agencia = numeroAgencia;
            Numero = numeroConta;

            TotalDeContasCriadas++;

            TaxaOperacao = 30 / TotalDeContasCriadas;

        }

        // ----- | METODOS | ----- //


        public bool Sacar(double valor)
        {
            if(valor < 0)
            {
                throw new ArgumentException("Valor inválido para saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(_saldo, valor);
            }

            _saldo -= valor;
            return true;
        }


        public void Depositar(double valor)
        {
            if (valor <= 0) 
            {
                throw new ArgumentException("Valor inválido para deposito", nameof(valor));
            }
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor inválido para transferência", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch(SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada", ex);
            }
            contaDestino.Depositar(valor);
        }
    }
}
