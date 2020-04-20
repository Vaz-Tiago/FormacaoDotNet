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
    public class ContaCorrente : IComparable
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

        /// <summary>
        /// Realiza o depósito e atualiza o valor da propriedade <see cref="Saldo" />
        /// </summary>
        /// <exception cref="ArgumentException">Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/></exception>
        /// <param name="valor">Representa o valor de depósito, deve ser maior que zero</param>
        public void Depositar(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor inválido para deposito", nameof(valor));
            }
            _saldo += valor;
        }

        /// <summary>
        /// Realiza uma transferencia entre contas. Altera a propriedade <see cref="Saldo"/> das contas envolvidas.
        /// </summary>
        /// <exception cref="ArgumentException">Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/>.</exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando o argumento <paramref name="valor"/> é maior que o <see cref="Saldo"/></exception>
        /// <param name="valor">Valor que será transferido. Deve ser maior que zero e maior que o <see cref="Saldo"/>.</param>
        /// <param name="contaDestino">Conta que receberá o valor. Deve ser um objeto <see cref="ContaCorrente"/>.</param>
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

        //Sobrescrevendo métodos virtuais da classe objeto

        public override string ToString()
        {
            return $"Número {Numero}, Agência {Agencia}, Saldo {Saldo}";
            //return "Numero " + Numero + ", Agência " + Agencia + ", Saldo " + Saldo;
        }

        public override bool Equals(object obj)
        {
            ContaCorrente outraConta = obj as ContaCorrente;

            if (outraConta == null)
                return false;

            return Numero == outraConta.Numero && Agencia == outraConta.Agencia;
        }

        // Implementado a interface de comparação
        public int CompareTo(object obj)
        {
            // Retornar n. negativo quando a instancia precede o obj(Argumento)
            // Retornar n. zero quando a instancia e o obj(Argumento) forem equivalentes
            // Retornar n. positivo != de zero quando a precedencia for de obj

            var outraConta = obj as ContaCorrente;

            if(outraConta == null)
            {
                return -1;
            }

            if (Numero < outraConta.Numero)
            {
                return -1;
            }

            if(Numero == outraConta.Numero)
            {
                return 0;
            }

            return 1;

        }
    }
}
