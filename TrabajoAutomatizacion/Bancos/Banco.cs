using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoAutomatizacion.Clientes;

namespace TrabajoAutomatizacion.Bancos
{
    public class Banco
    {
        public Banco(string nombre, string NIT)
        {
            this.setNombre(nombre);
            this.setNIT(NIT);
        }

        public Cuenta AbrirCuentaNuevoCliente(string nombreCliente, string apellidosCliente, string cedula, decimal montoInicial)
        {
            var cliente = new Cliente(nombreCliente, apellidosCliente, cedula);
            var cuenta = this.AbrirCuentaClienteExistente(cliente, montoInicial);
            return cuenta;

        }

        public Cuenta AbrirCuentaClienteExistente(Cliente cliente, decimal montoInicial)
        {
            var cuenta = Cuenta.CrearCuenta(cliente, montoInicial);
            cliente.AdicionarCuenta(cuenta);
            this.AdicionarCuenta(cuenta);
            return cuenta;
        }

        private void AdicionarCuenta(Cuenta cuenta)
        {
            if (this.Cuentas == null)
            {
                this.Cuentas = new List<Cuenta>();
            }
            Cuentas.Add(cuenta);
        }

        public void setNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("El nombre no puede estar vacío");
            }
            this.Nombre = nombre;
        }

        public void setNIT(string NIT)
        {
            if (string.IsNullOrWhiteSpace(NIT))
            {
                throw new Exception("El NIT no puede estar vacío");
            }
            this.NIT = NIT;
        }

        public decimal TotalDineroDepositado()
        {
            decimal dineroTotal = 0;
            if (Cuentas != null && Cuentas.Count() > 0)
            {
                dineroTotal = Cuentas.Sum(cuenta => cuenta.dinero);
            }

            return dineroTotal;
        }

        public string Nombre { get; private set; }
        public string NIT { get; private set; }
        public ICollection<Cuenta> Cuentas { get; private set; }
    }
}
