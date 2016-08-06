using System;
using Banco.Domain.Bancos;
using Banco.Services.Interfaces;

namespace Banco.Services
{
    public class Transferencias:ITransferencias
    {
        private readonly INotificaciones _notificaciones;

        public Transferencias(INotificaciones notificaciones)
        {
            _notificaciones = notificaciones;
        }

        public void Transferir(Cuenta fuente, Cuenta destino, decimal monto)
        {
            fuente.RealizarRetiro(monto);
            destino.RealizarDeposito(monto);
            
            _notificaciones.NotificarTransferencia(fuente.Cliente, monto);
        }
    }
}
