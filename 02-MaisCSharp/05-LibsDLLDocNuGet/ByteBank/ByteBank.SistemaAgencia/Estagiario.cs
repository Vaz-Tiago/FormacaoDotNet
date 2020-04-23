using ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class Estagiario : Funcionario
    {
        // Deriva de uma classe abstrata que contem um metodo internal protected

        public Estagiario(double salario, string cpf) : base(salario, cpf) { }
        public override void AumentarSalario()
        {
            // Qualquer código
        }

        protected override double GetBonificacao()
        {
            // Qualquer código
            return 0;
        }
    }
}
