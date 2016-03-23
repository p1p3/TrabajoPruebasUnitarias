using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrabajoAutomatizacion.Bancos;

namespace PruebasUnitarias
{
    [TestClass]
    public class BancoTest
    {
        private Banco Bancolombia;


        [TestInitialize]
        public void TestSetUp()
        {
            Bancolombia = new Banco("Bancolombia", "1234567");

        }

        [TestMethod]
        public void AbrirCuentaCliente()
        {
            decimal montoInicialFelipe = 1;
            var CuentaFelipe = Bancolombia.AbrirCuentaNuevoCliente("Felipe", "Jaramillo", "1234567", montoInicialFelipe);
            var existeCuenta = Bancolombia.Cuentas.Contains(CuentaFelipe);
            Assert.IsTrue(existeCuenta);

        }

        [TestMethod]
        public void RealizarDeposito()
        {
            decimal montoInicialFelipe = 1;
            var CuentaFelipe = Bancolombia.AbrirCuentaNuevoCliente("Felipe", "Jaramillo", "1234567", montoInicialFelipe);
            decimal depositoFelipe = 1;

            CuentaFelipe.RealizarDeposito(depositoFelipe);
            var depositoEsperado = montoInicialFelipe + depositoFelipe;
            var depositoReal = Bancolombia.TotalDineroDepositado();

            Assert.AreEqual(depositoEsperado, depositoReal);
        }

        [TestMethod]
        public void RealizarRetiro()
        {
            decimal montoInicialAlexis = 10;
            var CuentaAlexis = Bancolombia.AbrirCuentaNuevoCliente("Alexis", "Valencia", "12345688", montoInicialAlexis);
            decimal retiroAlexis = 1;

            CuentaAlexis.RealizarRetiro(retiroAlexis);
            var depositoEsperado = montoInicialAlexis - retiroAlexis;
            var depositoReal = Bancolombia.TotalDineroDepositado();

            Assert.AreEqual(depositoEsperado, depositoReal);
        }


        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void RealizarRetiroFondosInsuficientes()
        {
            decimal montoInicialAlexis = 10;
            var CuentaAlexis = Bancolombia.AbrirCuentaNuevoCliente("Alexis", "Valencia", "12345688", montoInicialAlexis);
            decimal retiroAlexis = montoInicialAlexis +1;

            CuentaAlexis.RealizarRetiro(retiroAlexis);
        }


        [TestMethod]
        public void CalcularTotalDeposito()
        {
            decimal montoInicialFelipe = 1;
            var CuentaFelipe = Bancolombia.AbrirCuentaNuevoCliente("Felipe", "Jaramillo", "1234567", montoInicialFelipe);
            decimal depositoFelipe = 1;
            CuentaFelipe.RealizarDeposito(depositoFelipe);

            decimal montoInicialAlexis = 1;
            var CuentaAlexis = Bancolombia.AbrirCuentaNuevoCliente("Alexis", "Valencia", "12345688", montoInicialAlexis);
            decimal depositoAlexis = 1;
            CuentaAlexis.RealizarDeposito(depositoAlexis);

            decimal montoEsperado = montoInicialFelipe + depositoFelipe + montoInicialAlexis + depositoAlexis;

            decimal totalDineroBancolombia = Bancolombia.TotalDineroDepositado();

            Assert.AreEqual(montoEsperado, totalDineroBancolombia);

        }


    }
}
