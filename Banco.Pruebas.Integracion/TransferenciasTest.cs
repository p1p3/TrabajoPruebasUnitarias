using System;
using Banco.Domain.Bancos;
using Banco.Services;
using Banco.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Banco.Pruebas.Integracion
{
    [TestClass]
    public class TransferenciasTest
    {
        private ITransferencias _transferencias;
        private Domain.Bancos.Banco Bancolombia;
        private Cuenta CuentaFelipe;
        private Cuenta CuentaAlexis;
        private decimal interesRetiro = 0.1M;

        [TestInitialize]
        public void TestSetup()
        {
            var notificacionesService = new Notificaciones();
            _transferencias = new Services.Transferencias(notificacionesService);

            Bancolombia = new Domain.Bancos.Banco("Bancolombia", "1234567");
            CuentaFelipe = Bancolombia.AbrirCuentaNuevoCliente("Felipe", "Jaramillo", "1234567", 0, 123123, interesRetiro);
            CuentaAlexis = Bancolombia.AbrirCuentaNuevoCliente("Alexis", "Valencia", "12345688", 0, 123213, interesRetiro);
        }

        [TestMethod]
        public void TransferirMontoExitoso()
        {
            decimal dineroInicialFelipe = 500;
            decimal totalTransferir = dineroInicialFelipe;

            CuentaFelipe.RealizarDeposito(dineroInicialFelipe);
            _transferencias.Transferir(CuentaFelipe,CuentaAlexis, totalTransferir);

            Assert.IsTrue(CuentaFelipe.dinero == dineroInicialFelipe-totalTransferir && CuentaAlexis.dinero == totalTransferir);
        }
    }
}
