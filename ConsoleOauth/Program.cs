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
       // private static HttpClient httpClient = new HttpClient();
        static void Main(string[] args)
        {
         //   httpClient.BaseAddress = new Uri("http://localhost/hanatechalarm");
            var token = GetAccessTokenByCredentials();
           // httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",token);
           // string res =  httpClient.PostAsync("/authority/Home/List", null).Result.Content.ReadAsStringAsync().Result;
          //  Console.WriteLine(res);
            Console.ReadKey();
        }

        static string GetAccessTokenByCredentials()
        {
            //var parms = new Dictionary<string, string>();

            //parms.Add("grant_type", "client_credentials");
            //HttpClient httpClient = new HttpClient();

            //httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic",
            //    Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(
            //        $"1234:5678"
            //    )));
            //string token = httpClient.PostAsync("http://localhost/hanatechalarm/token", new FormUrlEncodedContent(parms)).Result.Content.ReadAsStringAsync().Result;
            //return JObject.Parse(token)["access_token"].Value<string>();
            var parms = new Dictionary<string, string>();
            parms.Add("client_id", "1234");
            parms.Add("client_secret", "5678");
            parms.Add("grant_type", "client_credentials");
            HttpClient httpClient = new HttpClient();
            string token = httpClient.PostAsync("http://localhost/hanatechalarm/token", new FormUrlEncodedContent(parms)).Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(token);
            return JObject.Parse(token)["access_token"].Value<string>();
        }
    }
}
