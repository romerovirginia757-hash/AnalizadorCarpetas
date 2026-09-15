using System;
using System.Threading;
using System.Threading.Tasks;
using AnalizadorCarpetas.BE;
using AnalizadorCarpetas.DAL;

namespace AnalizadorCarpetas.BLL
{
    public class EscaneoService
    {
        private ArchivoRepository repository = new ArchivoRepository();

        public ResultadoEscaneo EscanearSecuencial(string ruta,IProgress<int> progreso, CancellationToken token)
        {
            ResultadoEscaneo resultado = new ResultadoEscaneo();

            DateTime inicio = DateTime.Now;

            var archivos = repository.ObtenerArchivos(ruta,progreso,token);

            resultado.Archivos = archivos;
            resultado.CantidadCarpetas =
                repository.ObtenerCantidadCarpetas(ruta);

            foreach (var archivo in archivos)
            {
                token.ThrowIfCancellationRequested();

                resultado.CantidadArchivos++;
                resultado.TamañoTotal += archivo.Tamaño;
            }

            resultado.TiempoProceso =
                DateTime.Now - inicio;

            return resultado;
        }
        public ResultadoEscaneo EscanearThread(string ruta, IProgress<int> progreso,CancellationToken token)

        {
            ResultadoEscaneo resultado = null;

            Thread hilo = new Thread(() =>
            {
                resultado = EscanearSecuencial(
                    ruta,
                    progreso,
                    token);
            });

            hilo.Start();
            hilo.Join();

            return resultado;
        }
        public async Task<ResultadoEscaneo> EscanearTask(string ruta,IProgress<int> progreso,CancellationToken token)
        {
            ResultadoEscaneo resultado = await Task.Run(() =>
            {
                return EscanearSecuencial(
                    ruta,
                    progreso,
                    token);
            }, token);

            return resultado;
        }
        public async Task<ResultadoEscaneo> EscanearAsync( string ruta,IProgress<int> progreso, CancellationToken token)
        {
            ResultadoEscaneo resultado = await Task.Run(() =>
            {
                return EscanearSecuencial(
                    ruta,
                    progreso,
                    token);
            }, token);

            return resultado;
        }
        public string CrearResumenParaIA(ResultadoEscaneo resultado)
        {
            string resumen = "";

            resumen += "Cantidad de archivos: "
                + resultado.CantidadArchivos + "\n";

            resumen += "Cantidad de carpetas: "
                + resultado.CantidadCarpetas + "\n";

            resumen += "Tamaño total en bytes: "
                + resultado.TamañoTotal + "\n";

            resumen += "\nArchivos encontrados:\n";

            foreach (var archivo in resultado.Archivos)
            {
                resumen += "- "
                    + archivo.Nombre
                    + " | Tamaño: "
                    + archivo.Tamaño
                    + " bytes\n";
            }

            return resumen;
        }
    }
}