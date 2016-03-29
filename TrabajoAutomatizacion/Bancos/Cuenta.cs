using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoAutomatizacion.Clientes;

namespace TrabajoAutomatizacion.Bancos
{
    public class Cuenta
    {
        public static Cuenta CrearCuenta(Cliente cliente, decimal depositoInicial = 0)
        {
            var cuenta = new Cuenta(cliente);
            cuenta.RealizarDeposito(depositoInicial);
            return cuenta;
        }

        public decimal interes
        {
            get
            {
                return 0.1M;
            }
        }


        private Cuenta(Cliente cliente)
        {
            this.Cliente = cliente;
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
