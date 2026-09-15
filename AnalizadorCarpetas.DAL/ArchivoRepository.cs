using AnalizadorCarpetas.BE;
using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;

namespace AnalizadorCarpetas.DAL
{
    public class ArchivoRepository
    {
        public List<ArchivoInfo> ObtenerArchivos(string ruta, IProgress<int> progreso, CancellationToken token)
        {
            List<ArchivoInfo> archivos = new List<ArchivoInfo>();
            List<string> rutasArchivos = new List<string>();

            // Método seguro para recolectar archivos omitiendo subcarpetas sin permisos
            ObtenerArchivosRecursivo(ruta, rutasArchivos, token);

            int totalArchivos = rutasArchivos.Count;
            int archivosProcesados = 0;

            foreach (string rutaArchivo in rutasArchivos)
            {
                token.ThrowIfCancellationRequested();

                try
                {
                    FileInfo informacionArchivo = new FileInfo(rutaArchivo);

                    ArchivoInfo archivo = new ArchivoInfo
                    {
                        Nombre = informacionArchivo.Name,
                        Ruta = informacionArchivo.FullName,
                        Tamaño = informacionArchivo.Length
                    };

                    archivos.Add(archivo);
                }
                catch (Exception)
                {
                    // Ignoramos archivos individuales bloqueados o inaccesibles
                }

                archivosProcesados++;

                int porcentaje = 0;
                if (totalArchivos > 0)
                {
                    porcentaje = archivosProcesados * 100 / totalArchivos;
                }

                progreso?.Report(porcentaje);
            }

            return archivos;
        }

        private void ObtenerArchivosRecursivo(string dirActual, List<string> listaArchivos, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            try
            {
                // Agregamos los archivos de la carpeta actual
                string[] archivosLocal = Directory.GetFiles(dirActual);
                listaArchivos.AddRange(archivosLocal);

                // Obtenemos las subcarpetas e intentamos entrar a cada una
                string[] subDirs = Directory.GetDirectories(dirActual);
                foreach (string subDir in subDirs)
                {
                    ObtenerArchivosRecursivo(subDir, listaArchivos, token);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Si Windows nos niega el acceso a esta subcarpeta, la ignoramos y continuamos con las demás
            }
            catch (DirectoryNotFoundException)
            {
                // Si la carpeta ya no existe o hay problemas de ruta, la ignoramos
            }
        }

        public int ObtenerCantidadCarpetas(string ruta)
        {
            List<string> carpetas = new List<string>();
            ObtenerCarpetasRecursivo(ruta, carpetas);
            return carpetas.Count + 1; // +1 para incluir la carpeta raíz
        }

        private void ObtenerCarpetasRecursivo(string dirActual, List<string> listaCarpetas)
        {
            try
            {
                string[] subDirs = Directory.GetDirectories(dirActual);
                foreach (string subDir in subDirs)
                {
                    listaCarpetas.Add(subDir);
                    ObtenerCarpetasRecursivo(subDir, listaCarpetas);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Ignoramos carpetas sin permisos de lectura
            }
            catch (DirectoryNotFoundException)
            {
                // Ignoramos directorios no encontrados
            }
        }
    }
}