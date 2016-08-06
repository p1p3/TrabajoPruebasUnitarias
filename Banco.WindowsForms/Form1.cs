using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Banco.Domain.Bancos;
using Banco.Domain.Bancos.Excepciones;
using Banco.Services.Interfaces;

namespace Banco.WindowsForms
{
    public partial class Form1 : Form
    {

        private decimal interesRetiro = 0.07M;
        private Domain.Bancos.Banco Bancolombia;

        public Form1()
        {
            InitializeComponent();
            DependencyContainer.Container.RegisterDependencies();

            Bancolombia = new Domain.Bancos.Banco("Bancolombia", "1234567");

            Bancolombia.AbrirCuentaNuevoCliente("Felipe", "Jaramillo", "1234567", 50000, 123123, interesRetiro);
            Bancolombia.AbrirCuentaNuevoCliente("Alexis", "Valencia", "12345688", 10000, 213, interesRetiro);
            Bancolombia.AbrirCuentaNuevoCliente("Jairo", "Yate", "31312", 9000, 2311, interesRetiro);
            Bancolombia.AbrirCuentaNuevoCliente("Gustavo", "Cañas", "31312", 21310, 2311, interesRetiro);

            configurarddlCuentaOrigen(Bancolombia.Cuentas);
            configurarddlCuentaDestino(Bancolombia.Cuentas);
        }

        private void configurarddlCuentaOrigen(ICollection<Cuenta> cuentas)
        {
            ddlCuentaOrigen.DataSource = cuentas;
            ddlCuentaOrigen.DisplayMember = nameof(Cuenta.NumeroCuenta);
        }

        private void configurarddlCuentaDestino(ICollection<Cuenta> cuentas)
        {
            var selectedCuentaOrigen = getSelectedCuentaOrigen();
            if (selectedCuentaOrigen != null)
            {
                ddlCuentaDestino.DataSource =
                    (from cuenta in cuentas where cuenta.NumeroCuenta != selectedCuentaOrigen.NumeroCuenta select cuenta)
                        .ToList();
            }
            else
            {
                ddlCuentaDestino.DataSource = new Collection<Cuenta>();
            }
            ddlCuentaDestino.DisplayMember = nameof(Cuenta.NumeroCuenta);
        }

        private void cambioCuentaOrigen(object sender, EventArgs e)
        {
            var cuenta = getSelectedCuentaOrigen();

            if (cuenta != null)
            {
                pintarInformacionCuenta(cuenta);
                configurarddlCuentaDestino(Bancolombia.Cuentas);
            }
        }

        private Cuenta getSelectedCuentaOrigen()
        {
            Cuenta cuenta = null;
            if (ddlCuentaOrigen.SelectedItem != null && ddlCuentaOrigen.SelectedItem is Cuenta)
            {
                cuenta = (Cuenta)ddlCuentaOrigen.SelectedItem;
            }
            return cuenta; ;
        }

        private Cuenta getSelectedCuentaDestino()
        {
            Cuenta cuenta = null;
            if (ddlCuentaDestino.SelectedItem != null && ddlCuentaDestino.SelectedItem is Cuenta)
            {
                cuenta = (Cuenta)ddlCuentaDestino.SelectedItem;
            }
            return cuenta; ;
        }

        private void pintarInformacionCuenta(Cuenta cuenta)
        {
            txtNombre.Text = cuenta.Cliente.Nombres;
            txtApellidos.Text = cuenta.Cliente.Apellidos;
            txtCelular.Text = cuenta.Cliente.Celular.ToString(CultureInfo.InvariantCulture);
            txtTotal.Text = cuenta.dinero.ToString("C");
            txtInteres.Text = cuenta.interes.ToString("P");
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            var servicioTransferencias = DependencyContainer.Container.GetTransferenciasServices();
            var cuentaOrigen = getSelectedCuentaOrigen();
            var cuentaDestino = getSelectedCuentaDestino();
            var monto = Convert.ToDecimal(txtMontoTransferencia.Text);
            servicioTransferencias.Transferir(cuentaOrigen, cuentaDestino, monto);
            pintarInformacionCuenta(cuentaOrigen);
            txtMontoTransferencia.Text = string.Empty;
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            var cuenta = getSelectedCuentaOrigen();
            var cantidadRetiro = Convert.ToDecimal(txtMontoRetiro.Text);
            try
            {
                cuenta.RealizarRetiro(cantidadRetiro);
            }
            catch (FondosInsuficientesException)
            {
                var costoTransaccion = cuenta.interes * cantidadRetiro;
                MessageBox.Show(
                    $"Tienes fondos insuficientes para realizar el retiro, recuerda que el costo de la transacción es del {costoTransaccion}");
                throw;
            }
            pintarInformacionCuenta(cuenta);
            txtMontoRetiro.Text = string.Empty;
        }

        private void btnConsignar_Click(object sender, EventArgs e)
        {
            var cuenta = getSelectedCuentaOrigen();
            var cantidadAConsignar = Convert.ToDecimal(txtMontoConsignacion.Text);

            cuenta.RealizarDeposito(cantidadAConsignar);
            pintarInformacionCuenta(cuenta);
            txtMontoConsignacion.Text = string.Empty;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
