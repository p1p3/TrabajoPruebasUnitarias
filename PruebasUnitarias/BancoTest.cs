using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Banco.Pruebas.Unitarias
{
    [TestClass]
    public class BancoTest
    {
        private Domain.Bancos.Banco Bancolombia;
        private decimal interesRetiro = 0.1M;

        [TestInitialize]
        public void TestSetUp()
        {
            Bancolombia = new Domain.Bancos.Banco("Bancolombia", "1234567");

        }

        [TestMethod]
        public void AbrirCuentaCliente()
        {
            decimal montoInicialFelipe = 1;
            var CuentaFelipe = Bancolombia.AbrirCuentaNuevoCliente("Felipe", "Jaramillo", "1234567", montoInicialFelipe,123123,interesRetiro);
            var existeCuenta = Bancolombia.Cuentas.Contains(CuentaFelipe);
            Assert.IsTrue(existeCuenta);

        }

        [TestMethod]
        public void RealizarDeposito()
        {
            decimal montoInicialFelipe = 1;
            var CuentaFelipe = Bancolombia.AbrirCuentaNuevoCliente("Felipe", "Jaramillo", "1234567", montoInicialFelipe,123123, interesRetiro);
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
            var CuentaAlexis = Bancolombia.AbrirCuentaNuevoCliente("Alexis", "Valencia", "12345688", montoInicialAlexis,123213, interesRetiro);
            decimal retiroAlexis = 1;

            CuentaAlexis.RealizarRetiro(retiroAlexis);
            var depositoEsperado = montoInicialAlexis - retiroAlexis - retiroAlexis*CuentaAlexis.interes;
            var depositoReal = Bancolombia.TotalDineroDepositado();

            Assert.AreEqual(depositoEsperado, depositoReal);
        }


        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void RealizarRetiroFondosInsuficientes()
        {
            decimal montoInicialAlexis = 10;
            var CuentaAlexis = Bancolombia.AbrirCuentaNuevoCliente("Alexis", "Valencia", "12345688", montoInicialAlexis,123123, interesRetiro);
            decimal retiroAlexis = montoInicialAlexis +1;

            CuentaAlexis.RealizarRetiro(retiroAlexis);
        }


        [TestMethod]
        public void CalcularTotalDeposito()
        {
            decimal montoInicialFelipe = 1;
            var CuentaFelipe = Bancolombia.AbrirCuentaNuevoCliente("Felipe", "Jaramillo", "1234567", montoInicialFelipe,3123, interesRetiro);
            decimal depositoFelipe = 1;
            CuentaFelipe.RealizarDeposito(depositoFelipe);

            decimal montoInicialAlexis = 1;
            var CuentaAlexis = Bancolombia.AbrirCuentaNuevoCliente("Alexis", "Valencia", "12345688", montoInicialAlexis,3123123, interesRetiro);
            decimal depositoAlexis = 1;
            CuentaAlexis.RealizarDeposito(depositoAlexis);

            decimal montoEsperado = montoInicialFelipe + depositoFelipe + montoInicialAlexis + depositoAlexis;

            decimal totalDineroBancolombia = Bancolombia.TotalDineroDepositado();

            Assert.AreEqual(montoEsperado, totalDineroBancolombia);

        }


    }
}
