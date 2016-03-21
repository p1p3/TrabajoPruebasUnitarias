using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoAutomatizacion.Bancos;

namespace TrabajoAutomatizacion.Clientes
{
    public class Cliente
    {
        public Cliente(string nombres, string apellidos, string cedula)
        {
            this.setNombres(nombres);
            this.setApellidos(apellidos);
            this.setCedula(cedula);
        }


        public void setNombres(string nombres)
        {
            if (string.IsNullOrWhiteSpace(nombres))
            {
                throw new Exception("Los nombres no pueden estar vacíos");
            }
            this.Nombres = nombres;
        }

        public void setApellidos(string apellidos)
        {
            if (string.IsNullOrWhiteSpace(apellidos))
            {
                throw new Exception("Los apellidos no pueden estar vacíos");
            }
            this.Apellidos = apellidos;
        }

        public void setCedula(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula))
            {
                throw new Exception("La cédula no puede estar vacía");
            }
            this.Cedula = cedula;
        }


        public void AdicionarCuenta(Cuenta cuenta)
        {
            if (this.Cuentas == null)
            {
                this.Cuentas = new List<Cuenta>();
            }

            this.Cuentas.Add(cuenta);
        }


        public string Nombres { get; private set; }
        public string Apellidos { get; private set; }
        public string Cedula { get; private set; }
        public ICollection<Cuenta> Cuentas { get; private set; }
    }
}
