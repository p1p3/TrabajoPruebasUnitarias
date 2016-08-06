using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Domain.Bancos.Excepciones;
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
            this.NumeroCuenta = Guid.NewGuid();
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
            var cantidadTotalConIntereses = cantidad + deducirIntereses(cantidad, interes);
            if (cantidad < 0)
            {
                throw new Exception("No puedes retirar cantidades negativas");
            }
            if (cantidadTotalConIntereses > dinero )
            {
                throw new FondosInsuficientesException();
            }
            this.dinero -= cantidadTotalConIntereses;
        }

        private decimal deducirIntereses(decimal cantidad, decimal interes)
        {
            return (cantidad*interes);
        }

        public Guid NumeroCuenta { get; private set; }
        public decimal dinero { get; private set; }
        public Cliente Cliente { get; private set; }

    }
}
