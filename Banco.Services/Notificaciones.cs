using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Domain.Clientes;
using Banco.Services.Interfaces;

namespace Banco.Services
{
    public class Notificaciones:INotificaciones
    {
        public void NotificarTransferencia(Cliente cliente, decimal monto)
        {
            // enviar notificacion
        }
    }
}
