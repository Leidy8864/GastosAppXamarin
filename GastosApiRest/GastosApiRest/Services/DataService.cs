using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GastosApiRest.Services
{
    public class DataService
    {
        private string Url = "https://gastos-api-rest.herokuapp.com/gasto/";

        public async Task<List<Gasto>> GetGastos()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(Url);

            var gastos = JsonConvert.DeserializeObject<List<Gasto>>(json);

            return gastos;
        }

        public async Task PostGasto(Gasto gasto)
        {
            var httpClient = new HttpClient();

            try
            {
                var json = JsonConvert.SerializeObject(gasto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await httpClient.PostAsync(Url, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            } catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        } 


        public async Task PutGasto(string id, Gasto gasto)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(gasto);

            StringContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(Url + id, content);
        }

        public async Task DeleteGasto(string id)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(Url + id);
        }
    }
}
