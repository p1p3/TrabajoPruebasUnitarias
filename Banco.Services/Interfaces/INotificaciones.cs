using Banco.Domain.Clientes;

namespace Banco.Services.Interfaces
{
    public interface INotificaciones
    {
        void NotificarTransferencia(Cliente cliente, decimal monto);
    }
}
