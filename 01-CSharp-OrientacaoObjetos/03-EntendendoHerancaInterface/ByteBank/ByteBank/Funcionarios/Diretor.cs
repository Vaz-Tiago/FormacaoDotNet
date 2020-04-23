using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    // Não há herança multipla de classes, há uma herança de classe e uma implementaçao de interface
    public class Diretor : FuncionarioAutenticavel
    {
        // ----- CAMPOS ----- //
        //Herdados de funcionário


        // ----- CONSTRUTOR ----- //
        public Diretor(string cpf) : base(5000, cpf)
        {
            //Console.WriteLine("Construtor Diretor");
        }


        // ----- METODOS ----- //

        public override double GetBonificacao()
        {
            // Para chamar o método original, basta adicionar o base.
            return Salario * 0.5;
        }

        public override void AumentarSalario()
        {
            Salario *= 1.15;
        }
    }
}
