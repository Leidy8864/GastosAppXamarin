using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GastosApiRest.Models;

namespace GastosApiRest.Services
{
    public class DataService
    {
        private string Url = "localhost:3000/gasto/";

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

            var json = JsonConvert.SerializeObject(gasto);

            StringContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(Url, content);
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
