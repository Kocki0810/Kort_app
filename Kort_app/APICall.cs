using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Kort_app
{
    internal class APICall
    {
        private static async Task<string> Pay(string order, string card_number, string pin)
        {
            order = order.Replace("\\", @"");
            HttpClientHandler clientHandler = new HttpClientHandler();
            HttpClient client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var parameters = new Dictionary<string, string> { { "bon", order }, { "from", card_number }, { "pin", pin } };
            var encodedContent = new FormUrlEncodedContent(parameters);
            var response = client.PostAsync("https://localhost/api/pay.php", encodedContent).ConfigureAwait(false);

            var msg = await response;
            return msg.Content.ReadAsStringAsync().Result;
        }

        private static async Task<string> Receipt(string order, string card_number, string pin)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            HttpClient client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var parameters = new Dictionary<string, string> { { "bon", order }, { "from", card_number }, { "pin", pin } };
            var encodedContent = new FormUrlEncodedContent(parameters);
            var response = client.PostAsync("https://localhost/api/pay.php", encodedContent).ConfigureAwait(false);

            var msg = await response;
            return msg.Content.ReadAsStringAsync().Result;
        }
    }
}