using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace ConsoleOauth
{
    class Program
    {
        private static HttpClient httpClient = new HttpClient();
        static void Main(string[] args)
        {
            httpClient.BaseAddress = new Uri("http://localhost/authority");
            var token = GetAccessTokenByCredentials();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",token);
            string res =  httpClient.PostAsync("/authority/Home/List", null).Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(res);
            Console.ReadKey();
        }

        static string GetAccessTokenByCredentials()
        {
           
            var parms = new Dictionary<string, string>();
            parms.Add("client_id", "1234");
            parms.Add("client_secret", "5678");
            parms.Add("grant_type", "client_credentials");
            string token = httpClient.PostAsync("/authority/token", new FormUrlEncodedContent(parms)).Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(token);
            return JObject.Parse(token)["access_token"].Value<string>();
        }
    }
}
