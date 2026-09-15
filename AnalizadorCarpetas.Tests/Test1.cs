using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnalizadorCarpetas.BLL;
using AnalizadorCarpetas.BE;
using System;
using System.IO;
using System.Threading;

namespace AnalizadorCarpetas.Tests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void EscanearSecuencial_CuentaCorrectamenteLosArchivos()
        {
            // Arrange
            string carpeta = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString());

            Directory.CreateDirectory(carpeta);

            File.WriteAllText(
                Path.Combine(carpeta, "archivo1.txt"),
                "Hola");

            File.WriteAllText(
                Path.Combine(carpeta, "archivo2.txt"),
                "Mundo");

            EscaneoService servicio = new EscaneoService();

            CancellationTokenSource cancelacion =
                new CancellationTokenSource();

            // Act
            ResultadoEscaneo resultado =
                servicio.EscanearSecuencial(
                    carpeta,
                    null,
                    cancelacion.Token);

            // Assert
            Assert.AreEqual(2, resultado.CantidadArchivos);

            // Cleanup
            Directory.Delete(carpeta, true);
        }

        [TestMethod]
        public void EscanearSecuencial_CuentaCorrectamenteLasCarpetas()
        {
            // Arrange
            string carpeta = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString());

            Directory.CreateDirectory(carpeta);

            string subcarpeta = Path.Combine(carpeta, "Subcarpeta");
            Directory.CreateDirectory(subcarpeta);

            File.WriteAllText(
                Path.Combine(carpeta, "archivo1.txt"),
                "Hola");

            File.WriteAllText(
                Path.Combine(subcarpeta, "archivo2.txt"),
                "Mundo");

            EscaneoService servicio = new EscaneoService();

            CancellationTokenSource cancelacion =
                new CancellationTokenSource();

            // Act
            ResultadoEscaneo resultado =
                servicio.EscanearSecuencial(
                    carpeta,
                    null,
                    cancelacion.Token);

            // Assert
            Assert.AreEqual(2, resultado.CantidadCarpetas);

            // Cleanup
            Directory.Delete(carpeta, true);
        }
        [TestMethod]
        public void EscanearSecuencial_CalculaCorrectamenteElTamañoTotal()
        {
            // Arrange
            string carpeta = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString());

            Directory.CreateDirectory(carpeta);

            string archivo1 = Path.Combine(carpeta, "archivo1.txt");
            string archivo2 = Path.Combine(carpeta, "archivo2.txt");

            File.WriteAllText(archivo1, "12345");
            File.WriteAllText(archivo2, "1234567890");

            long tamañoEsperado =
                new FileInfo(archivo1).Length +
                new FileInfo(archivo2).Length;

            EscaneoService servicio = new EscaneoService();

            CancellationTokenSource cancelacion =
                new CancellationTokenSource();

            // Act
            ResultadoEscaneo resultado =
                servicio.EscanearSecuencial(
                    carpeta,
                    null,
                    cancelacion.Token);

            // Assert
            Assert.AreEqual(
                tamañoEsperado,
                resultado.TamañoTotal);

            // Cleanup
            Directory.Delete(carpeta, true);
        }
        [TestMethod]
        public void EscanearThread_CuentaCorrectamenteLosArchivos()
        {
            // Arrange
            string carpeta = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString());

            Directory.CreateDirectory(carpeta);

            File.WriteAllText(
                Path.Combine(carpeta, "archivo1.txt"),
                "Hola");

            File.WriteAllText(
                Path.Combine(carpeta, "archivo2.txt"),
                "Mundo");

            File.WriteAllText(
                Path.Combine(carpeta, "archivo3.txt"),
                "Prueba");

            EscaneoService servicio = new EscaneoService();

            CancellationTokenSource cancelacion =
                new CancellationTokenSource();

            // Act
            ResultadoEscaneo resultado =
                servicio.EscanearThread(
                    carpeta,
                    null,
                    cancelacion.Token);

            // Assert
            Assert.AreEqual(3, resultado.CantidadArchivos);

            // Cleanup
            Directory.Delete(carpeta, true);
        }
        [TestMethod]
        public async Task EscanearTask_CuentaCorrectamenteLosArchivos()
        {
            // Arrange
            string carpeta = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString());

            Directory.CreateDirectory(carpeta);

            File.WriteAllText(
                Path.Combine(carpeta, "archivo1.txt"),
                "Hola");

            File.WriteAllText(
                Path.Combine(carpeta, "archivo2.txt"),
                "Mundo");

            File.WriteAllText(
                Path.Combine(carpeta, "archivo3.txt"),
                "Prueba");

            EscaneoService servicio = new EscaneoService();

            CancellationTokenSource cancelacion =
                new CancellationTokenSource();

            // Act
            ResultadoEscaneo resultado =
                await servicio.EscanearTask(
                    carpeta,
                    null,
                    cancelacion.Token);

            // Assert
            Assert.AreEqual(3, resultado.CantidadArchivos);

            // Cleanup
            Directory.Delete(carpeta, true);
        }
        [TestMethod]
        public async Task EscanearAsync_CuentaCorrectamenteLosArchivos()
        {
            // Arrange
            string carpeta = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString());

            Directory.CreateDirectory(carpeta);

            File.WriteAllText(
                Path.Combine(carpeta, "archivo1.txt"),
                "Hola");

            File.WriteAllText(
                Path.Combine(carpeta, "archivo2.txt"),
                "Mundo");

            File.WriteAllText(
                Path.Combine(carpeta, "archivo3.txt"),
                "Prueba");

            EscaneoService servicio = new EscaneoService();

            CancellationTokenSource cancelacion =
                new CancellationTokenSource();

            // Act
            ResultadoEscaneo resultado =
                await servicio.EscanearAsync(
                    carpeta,
                    null,
                    cancelacion.Token);

            // Assert
            Assert.AreEqual(3, resultado.CantidadArchivos);

            // Cleanup
            Directory.Delete(carpeta, true);
        }
        [TestMethod]
        public void EscanearSecuencial_CancelacionLanzaExcepcion()
        {
            // Arrange
            string carpeta = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString());

            Directory.CreateDirectory(carpeta);

            File.WriteAllText(
                Path.Combine(carpeta, "archivo1.txt"),
                "Hola");

            File.WriteAllText(
                Path.Combine(carpeta, "archivo2.txt"),
                "Mundo");

            CancellationTokenSource cancelacion =
                new CancellationTokenSource();

            cancelacion.Cancel();

            EscaneoService servicio = new EscaneoService();

            // Act + Assert
            Assert.ThrowsException<OperationCanceledException>(() =>
            {
                servicio.EscanearSecuencial(
                    carpeta,
                    null,
                    cancelacion.Token);
            });

            // Cleanup
            Directory.Delete(carpeta, true);
        }
    }
}