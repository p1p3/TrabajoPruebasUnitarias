using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Domain.Clientes;

namespace Banco.Domain.Bancos
{
    public class Cuenta
    {
        public static Cuenta CrearCuenta(Cliente cliente, decimal depositoInicial , decimal interesRetiro)
        {
            var cuenta = new Cuenta(cliente,interesRetiro);
            cuenta.RealizarDeposito(depositoInicial);
            return cuenta;
        }

        public decimal interes { get; }

        private Cuenta(Cliente cliente, decimal interesretiro)
        {
            this.Cliente = cliente;
            this.interes = interesretiro;
            this.NumeroCuenta = new Guid();
        }

        public void RealizarDeposito(decimal cantidad)
        {
            if (cantidad < 0)
            {
                throw new Exception("No puedes depositar cantidades negativas");
            }
            this.dinero += cantidad;
        }

        public void RealizarRetiro(decimal cantidad)
        {
            if (cantidad < 0)
            {
                throw new Exception("No puedes retirar cantidades negativas");
            }
            if (cantidad > dinero)
            {
                throw new Exception("Fondos insuficientes");
            }
            this.dinero -= cantidad + (cantidad * interes);
        }

        public Guid NumeroCuenta { get; private set; }
        public decimal dinero { get; private set; }
        public Cliente Cliente { get; private set; }

    }
}
