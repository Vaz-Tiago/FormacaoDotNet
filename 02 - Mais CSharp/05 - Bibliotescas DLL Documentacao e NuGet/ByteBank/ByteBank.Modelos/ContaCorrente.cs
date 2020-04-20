using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    /// <summary>
    /// Essa classe define uma conta corrente do banco ByteBank
    /// </summary>
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

        /// <summary>
        /// Cria uma instância de ContaCorrente com os argumentos utilizados
        /// </summary>
        /// <param name="agencia">Representa o valor da propriedade <see cref="Agencia"/> e deve possuir o valor maior que zero</param>
        /// <param name="numero">Representa o valor da propriedade <see cref="Numero"/> e deve possuir o valor maior que zero</param>
        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0)
            {
                ArgumentException excecao = new ArgumentException("O Argumento " + nameof(agencia) + " deve ser maior que zero.", nameof(agencia));
                throw excecao;
            }
            if (numero <= 0)
            {
                ArgumentException excecao = new ArgumentException("O Argumento " + nameof(numero) + " deve ser maior que zero.", nameof(numero));
                throw excecao;
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;

            TaxaOperacao = 30 / TotalDeContasCriadas;

        }

        // ----- | METODOS | ----- //

        /// <summary>
        /// Realiza o saque e atualiza o valor da propriedade <see cref="Saldo"/>
        /// </summary>
        /// <exception cref="ArgumentException">Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/>.</exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando o argumento <paramref name="valor"/> é maior do que a propriedade <see cref="Saldo"/>.</exception>
        /// <param name="valor"> Representa o valor do saque, deve ser maior que zero e menor que o <see cref="Saldo"/></param>
        public bool Sacar(double valor)
        {
            if (valor < 0)
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
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada", ex);
            }
            contaDestino.Depositar(valor);
        }
    }
}
