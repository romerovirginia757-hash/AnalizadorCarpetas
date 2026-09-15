using System;
using System.Collections.Generic;

namespace AnalizadorCarpetas.BE
{
    public class ResultadoEscaneo
    {
        public int CantidadArchivos { get; set; }

        public int CantidadCarpetas { get; set; }

        public long TamañoTotal { get; set; }

        public TimeSpan TiempoProceso { get; set; }

        public List<ArchivoInfo> Archivos { get; set; }
    }
}