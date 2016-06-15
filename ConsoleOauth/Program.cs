using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace ConsoleOauth
{
    class Program
    {
        private static HttpClient httpClient=new HttpClient();
        static void Main(string[] args)
        {
            httpClient.BaseAddress = new Uri("http://localhost/authority");
            GetAccessTokenByCredentials();
        }

        static void GetAccessTokenByCredentials()
        {
            var parms = new Dictionary<string, string>();
            parms.Add("client_id", "1234");
            parms.Add("client_secret", "5678");
            parms.Add("grant_type","client_credentials");
            Console.WriteLine(httpClient.PostAsync("/authority/token", new FormUrlEncodedContent(parms)).Result.Content.ReadAsStringAsync().Result);
            Console.ReadKey();
        }
    }
}
