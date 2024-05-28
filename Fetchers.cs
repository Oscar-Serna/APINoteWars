using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PruebaFetchAPI.Models;
namespace PruebaFetchAPI
{
    internal class Fetchers
    {

        private HttpClient client;

        public Fetchers()
        {
            client = new HttpClient();
        }

        public async Task<dynamic> SendRequest(string method, string url)
        {
            try
            {

                if (url == null || url.Trim() == "") throw new Exception("Debes de ingresar una URL para realizar la peticion");

                if (method != "GET") throw new Exception("El tipo de metodo tiene que ser GET");

                dynamic request =  new HttpRequestMessage(HttpMethod.Get, url);

                var response = await client.SendAsync(request);

                Console.WriteLine(response);

                if (response.StatusCode == HttpStatusCode.NotFound)
                    return new MServerError { HasServerError = false, Message = "Ruta no encontrada, esta habilitada?" };

                string responseJSON = await response.Content.ReadAsStringAsync();

                var JSONConverted = JsonConvert.DeserializeObject<dynamic>(responseJSON)[0];

                return JSONConverted;

            }
            catch (Exception exception)
            {
                Console.WriteLine("Excepcion desde el Fetchers" + exception);
                return exception.Message;
            }
        }


        public async Task<dynamic> SendRequest(string method, string url, List<MKeyValue> headers)
        {
            try
            {

                if (url == null || url.Trim() == "") throw new Exception("Debes de ingresar una URL para realizar la peticion");
                if (headers.Count == 0) throw new Exception("La lista no puede estar vacia");

                if (method != "GET" && method != "POST" && method != "PUT" && method != "DELETE") throw new Exception("El tipo de metodo tiene que ser GET, POST, PUT o DELETE");

                dynamic request = null;

                if (method == "GET") request = new HttpRequestMessage(HttpMethod.Get, url);
                if (method == "POST") request = new HttpRequestMessage(HttpMethod.Post, url);
                if (method == "PUT") request = new HttpRequestMessage(HttpMethod.Put, url);
                if (method == "DELETE") request = new HttpRequestMessage(HttpMethod.Delete, url);

                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }

                var response = await client.SendAsync(request);

                if (response.StatusCode == HttpStatusCode.NotFound)
                    return new MServerError { HasServerError = false, Message = "Ruta no encontrada, esta habilitada?" };

                string responseJSON = await response.Content.ReadAsStringAsync();

                var JSONConverted = JsonConvert.DeserializeObject<dynamic>(responseJSON)[0];

                return JSONConverted;

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public async Task<dynamic> SendRequest(string method, string url, dynamic headers, string body)
        {
            try
            {
                if (string.IsNullOrEmpty(method) && method != "GET" && method != "POST" && method != "PUT" && method != "DELETE")
                    throw new Exception("El tipo de metodo tiene que ser GET, POST, PUT o DELETE");

                if (string.IsNullOrEmpty(url)) throw new Exception("Debes de ingresar una URL para realizar la peticion");

                if (!(headers is List<MKeyValue> || headers is null)) throw new Exception("Los headers solo pueden ser del tipo List<MKeyValue> o null");

                if (string.IsNullOrEmpty(body)) throw new Exception("El campo body no puede ser nulo o estar vacio");

                dynamic request = null;

                if (method == "GET") request = new HttpRequestMessage(HttpMethod.Get, url);
                if (method == "POST") request = new HttpRequestMessage(HttpMethod.Post, url);
                if (method == "PUT") request = new HttpRequestMessage(HttpMethod.Put, url);
                if (method == "DELETE") request = new HttpRequestMessage(HttpMethod.Delete, url);

                if(headers is List<MKeyValue>)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                request.Content = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);

                if (response.StatusCode == HttpStatusCode.NotFound)
                    return new MServerError { HasServerError = false, Message = "Ruta no encontrada, esta habilitada?" };

                string responseJSON = await response.Content.ReadAsStringAsync();

                Console.WriteLine("ResponseJSON: " + responseJSON);

                var JSONConverted = JsonConvert.DeserializeObject<dynamic>(responseJSON)[0];

                return JSONConverted;

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return exception.Message;
            }
        }

    }
}

/*

    AUTHOR: OSCAR GILBERTO SERNA HERNÁNDEZ
    GITHUB: https://github.com/Oscar-Serna

*/