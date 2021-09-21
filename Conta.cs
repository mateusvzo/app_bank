using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video_aula_rosen
{
    class Conta: IConta
    {
        public long Numero { get; private set; }
        public decimal Saldo { get; private set; }
        public Cliente Titular { get; set; }
        public static decimal saldoGeral { get; private set; }

        public Conta(long numero, Cliente titular)
        {
            if (numero < 999)
            {
                throw new System.ArgumentException("O numero da conta deve ser superior a 999");
            }
            Numero = numero;
            Titular = titular;
        }

        public void Depositar(decimal valor) {
            this.Saldo += valor;
            saldoGeral += valor;
        }

        public bool Sacar(decimal valor) {
            if ((Saldo - valor - 0.1m) < 0)
            {
                return false;
            }

            Saldo -= (valor + 0.1m);
            saldoGeral -= valor;
            return true;
        }

        public bool Transferir(Conta contaDestino, decimal valor)
        {
            if (this.Sacar(valor))
            {
                contaDestino.Depositar(valor);
                return true;
            }

            return false;
        }

    }
}
