using System;
using System.Collections.Generic;
using Banco.Domain.Bancos;

namespace Banco.Domain.Clientes
{
    public class Cliente
    {
        public Cliente(string nombres, string apellidos, string cedula, double celular)
        {
            this.SetNombres(nombres);
            this.SetApellidos(apellidos);
            this.SetCedula(cedula);
            this.SetCelular(celular);
        }


        public void SetNombres(string nombres)
        {
            if (string.IsNullOrWhiteSpace(nombres))
            {
                throw new Exception("Los nombres no pueden estar vacíos");
            }
            this.Nombres = nombres;
        }

        public void SetApellidos(string apellidos)
        {
            if (string.IsNullOrWhiteSpace(apellidos))
            {
                throw new Exception("Los apellidos no pueden estar vacíos");
            }
            this.Apellidos = apellidos;
        }

        public void SetCedula(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula))
            {
                throw new Exception("La cédula no puede estar vacía");
            }
            this.Cedula = cedula;
        }


        public void SetCelular(double celular)
        {
            this.Celular = celular;
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
        public double Celular { get; private set; }

        public ICollection<Cuenta> Cuentas { get; private set; }
    }
}
