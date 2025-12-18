using System;
using System.IO;
using System.Net;

namespace Laboratorio_192
{
    public class Class1
    {
        // Obtener un item por ID
        public string GetItem(int id)
        {
            var url = $"http://localhost:44365/item/{id}";
            return CallApi(url);
        }

        // Obtener todos los items
        public string GetItems()
        {
            var url = "http://localhost:44365/item";
            return CallApi(url);
        }

        // Función genérica para llamar API
        private string CallApi(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd(); // 🔥 Aquí devolvemos el JSON
                }
            }
            catch (WebException ex)
            {
                return "Error al consumir API: " + ex.Message;
            }
        }
    }
}
