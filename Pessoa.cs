using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video_aula_rosen
{
    class Pessoa
    {
        public string Nome { get; private set; }
        public int AnoNascimento { get; private set; }
        public string Cpf { get; private set; }

        public Pessoa (string nome, int anoNascimento, string cpf)
        {
            if ((Int32.Parse(DateTime.Now.ToString("yyyy")) - anoNascimento) < 18)
            {
                throw new System.ArgumentException("O cliente deve ter mais de 18 anos");
            }
            if (cpf.Length != 11)
            {
                throw new System.ArgumentException("O CPF deve possuir 11 digitos!");
            }
            Nome = nome;
            AnoNascimento = anoNascimento;
            Cpf = cpf;
        }
    }
}
