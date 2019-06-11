using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GastosApiRest.Services
{
    public class DataService
    {
        public List<Gasto> Gastos { get; private set; }

        private string Url = "https://gastos-api-rest.herokuapp.com/gasto/";

        public async Task<List<Gasto>> GetGastos()
        {
            var httpClient = new HttpClient();

            Gastos = new List<Gasto>();

            try
            {
                var json = await httpClient.GetStringAsync(Url);

                Gastos = JsonConvert.DeserializeObject<List<Gasto>>(json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Gastos;
        }

        public async Task PostGasto(Gasto gasto)
        {
            var httpClient = new HttpClient();

            try
            {
                var json = JsonConvert.SerializeObject(gasto);

                StringContent content = new StringContent(json);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = null;

                response = await httpClient.PostAsync(Url, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tGasto creado.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        } 


        public async Task PutGasto(string id, Gasto gasto)
        {
            var httpClient = new HttpClient();

            try
            {
                var json = JsonConvert.SerializeObject(gasto);

                StringContent content = new StringContent(json);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = null;

                response = await httpClient.PutAsync(Url + id, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tGasto actualizado.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteGasto(string id)
        {
            var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.DeleteAsync(Url + id);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tGasto borrado.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
