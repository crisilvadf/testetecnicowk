using Newtonsoft.Json;
using Prateleira.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models.Request;

namespace WebApplication.Configuration
{
    public class APIConnection
    {
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:45475/");
            return Client;
        }

        public async Task<HttpResponseMessage> ResponseGet(APIConnection _api, string route)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.GetAsync(route);
         
            return response;
        }

        public async Task<HttpResponseMessage> ResponsePost(APIConnection _api, string route, object parametros)
        {
            HttpClient client = _api.Initial();
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(parametros), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync(route, httpContent);

            return response;
        }
    }
}
