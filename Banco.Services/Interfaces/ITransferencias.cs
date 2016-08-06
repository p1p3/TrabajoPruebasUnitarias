using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Domain.Bancos;

namespace Banco.Services.Interfaces
{
    public interface ITransferencias
    {
        void Transferir(Cuenta fuente, Cuenta destino, decimal monto);
    }
}
