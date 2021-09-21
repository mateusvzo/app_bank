using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video_aula_rosen
{
    class Cliente: Pessoa
    {
        public string Email { get; set; }

        public Cliente(string nome, int anoNascimento, string cpf) : base(nome, anoNascimento, cpf)
        {
        }


    }
}
