using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AnalizadorCarpetas.BLL
{
    public class AnalizadorIA
    {
        private readonly string apiKey;
        private readonly HttpClient cliente;

        public AnalizadorIA()
        {
            apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY");

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new Exception(
                    "No se encontró la clave GEMINI_API_KEY."
                );
            }

            cliente = new HttpClient();
        }

        public async Task<string> AnalizarAsync(string informacion)
        {
            string prompt =
                "Sos un asistente de análisis de carpetas. " +
                "Analizá la siguiente información obtenida por un programa " +
                "que escanea una carpeta. " +
                "Explicá de forma clara qué se puede observar y brindá " +
                "recomendaciones para organizar mejor los archivos. " +
                "No inventes información que no esté presente en los datos.\n\n" +
                "Información del escaneo:\n" +
                informacion;

            string url = "https://generativelanguage.googleapis.com/v1beta/models/" + "gemini-2.0-flash:generateContent";
            

            var cuerpo = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new
                            {
                                text = prompt
                            }
                        }
                    }
                }
            };

            JavaScriptSerializer serializer =
                new JavaScriptSerializer();

            string json = serializer.Serialize(cuerpo);

            using (HttpRequestMessage solicitud =
                new HttpRequestMessage(HttpMethod.Post, url))
            {
                solicitud.Headers.Add(
                    "x-goog-api-key",
                    apiKey
                );

                solicitud.Content =
                    new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json"
                    );

                HttpResponseMessage respuesta =
                    await cliente.SendAsync(solicitud);

                string contenido =
                    await respuesta.Content.ReadAsStringAsync();

                if (!respuesta.IsSuccessStatusCode)
                {
                    throw new Exception(
                        "Error de Gemini: "
                        + respuesta.StatusCode
                        + "\n\n"
                        + contenido
                    );
                }

                Dictionary<string, object> datos =
                    serializer.Deserialize<Dictionary<string, object>>(
                        contenido
                    );

                ArrayList candidatos = (ArrayList)datos["candidates"];

                Dictionary<string, object> candidato =
                    (Dictionary<string, object>)candidatos[0];

                Dictionary<string, object> contenidoRespuesta =
                    (Dictionary<string, object>)
                    candidato["content"];

                ArrayList partes = (ArrayList)contenidoRespuesta["parts"];

                Dictionary<string, object> parte =
                    (Dictionary<string, object>)partes[0];

                return parte["text"].ToString();
            }
        }
    }
}