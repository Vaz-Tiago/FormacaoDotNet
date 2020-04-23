
namespace _06_ByteBank
{
    public class ContaCorrente
    {
        // Para campos que não possuem regras de implementação, basta essa linha
        // O C# vai criar todo o resto do código também por baixo dos panos
        public Cliente Titular { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }

        // Por convenção, campos privados utilizam o _
        private double _saldo = 100;
        // Definindo get e set como propriedade
        // Nomenclatura de propriedade com primeira letra maiuscula
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                // value é o nome do argumento que vem na definição
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        /*
        public double GetSaldo()
        {
            return saldo;
        }

        public void SetSaldo(double saldo)
        {
            if (saldo < 0)
                return;

            this.saldo = saldo;

        }
        */

        public bool Sacar(double valor)
        {
            if (_saldo < valor)
            {
                return false;
            }

            _saldo -= valor;
            return true;

        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (_saldo < valor)
            {
                return false;
            }

            _saldo -= valor;
            contaDestino.Depositar(valor);
            return true;

        }
    }
}