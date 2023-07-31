using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public abstract class Banco 
    {
        public Banco() 
        {
            this.Nomebanco = "DigiBank";
            this.CodigoBanco = "777";
        }

        public string Nomebanco { get; private set; }
        public string CodigoBanco { get; private set; }

    }
}
