using System;
using System.Collections.Generic;
using System.Net.Http;

namespace VTLP1J_ADT_23_1_V2.Client
{
    internal class RestService
    {
        HttpClient client;

        public RestService(string URL)
        {
            Init(URL);
        }

        private  void Init(string URL)
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                client.GetAsync("").GetAwaiter().GetResult();
            }
            catch (HttpRequestException e)
            {
                throw new ArgumentException("Endpoint not found");
            }
        }
        
        public List<T> Get<T>(string endpoint)
        {
            List<T> items = new List<T>();
            HttpResponseMessage message = client.GetAsync(endpoint).GetAwaiter().GetResult();

            message.EnsureSuccessStatusCode();
            items = message.Content.ReadAsAsync<List<T>>().GetAwaiter().GetResult();
            return items;
        }   
        
        public T Get<T>(string endpoint, int id)
        {
            T item = default(T);
            HttpResponseMessage message = client.GetAsync(endpoint + "/" + id).GetAwaiter().GetResult();

            message.EnsureSuccessStatusCode();
            
            item = message.Content.ReadAsAsync<T>().GetAwaiter().GetResult();
            return item;
        }
        
        public void Post<T>(string endpoint, T item)
        {
            HttpResponseMessage message = client.PostAsJsonAsync(endpoint, item).GetAwaiter().GetResult();

            message.EnsureSuccessStatusCode();
        }
        
        public void Put<T>(string endpoint, T item)
        {
            HttpResponseMessage message = client.PutAsJsonAsync(endpoint, item).GetAwaiter().GetResult();

            message.EnsureSuccessStatusCode();
        }
       
        public void Delete(string endpoint, int id)
        {
            HttpResponseMessage message = client.DeleteAsync(endpoint + "/" + id).GetAwaiter().GetResult();

            message.EnsureSuccessStatusCode();
        }

    }
}