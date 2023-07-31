using DigiBank.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public abstract class Conta : Banco, Iconta
    {

        public Conta()
        {
            this.NumeroAgencia = "0001";
            Conta.NumeroContaSequencial++;
        }

        public double Saldo { get; protected set; }
        public string NumeroAgencia { get; private set; }
        public string NumeroConta { get; protected set; }
        public static int NumeroContaSequencial { get; private set; }

        public double ConsultarSaldo()
        {
            return this.Saldo;
        }

        public void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        public bool Saca(double valor)
        {
            if (valor > this.ConsultarSaldo())
                return false;

            this.Saldo -= valor;
            return true;
        }   

        public string GetCodigoBanco()
        {
            return this.CodigoBanco;
        }

        public string GetNumeroAgencia()
        {
            return this.NumeroAgencia;
        }

        public string GetNumeroConta()
        {
            return this.NumeroConta;
        }
    }
}
