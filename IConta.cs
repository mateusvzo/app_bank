using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video_aula_rosen
{
    interface IConta
    {
        public void Depositar(decimal valor);

        public bool Sacar(decimal valor);

        public bool Transferir(Conta contaDestino, decimal valor);
    }
}
