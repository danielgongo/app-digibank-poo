using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Contratos
{
    public interface Iconta
    {
        void Deposita(double valor);
        bool Saca(double valor);
        double ConsultarSaldo();
        string GetCodigoBanco();
        string GetNumeroAgencia();
        string GetNumeroConta();


    }
}
