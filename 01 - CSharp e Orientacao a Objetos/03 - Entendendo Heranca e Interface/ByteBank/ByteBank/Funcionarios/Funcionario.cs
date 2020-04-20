using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public abstract class Funcionario
    {
        // ----- CAMPOS ----- //
        
        public static int TotalDeFuncionarios { get; private set; }

        public string Nome { get; set; }
        public string CPF { get; private set; }
        public double Salario { get; protected set; }


        // ----- CONSTRUTOR ----- //

        public Funcionario(double salario, string cpf)
        {
            // Console.WriteLine("Construtor Funcionario");

            Salario = salario;
            CPF = cpf;

            TotalDeFuncionarios++;
        }

        // ----- METODOS ----- //

        public abstract double GetBonificacao();
        public abstract void AumentarSalario();
    }
}
