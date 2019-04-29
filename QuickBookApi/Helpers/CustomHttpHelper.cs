using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QuickBookApi.Helpers
{
    public class CustomHttpHelper
    {
        static async Task<string> MakeHttpRequest(string type , string url , string body , string token)
        {
            // Create a New HttpClient object and dispose it when done, so the app doesn't leak resources
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("HEADERNAME", "HEADERVALUE");
                try
                {
                    if (string.Equals(type.ToLower(), "get"))
                    {
                         return await client.GetStringAsync(url);
                    }
                    else if (string.Equals(type.ToLower(), "post"))
                    {
                        var stringContent = new StringContent("", Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync(url , stringContent);
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync();
                    }
                    return "";
                }
                catch (HttpRequestException e)
                {
                    return "";
                }
            }
        }
        /// The client information used to get the OAuth Access Token from the server.
        static string clientId = "Q0TMGv2KUfZT5vfgcg0kKBiU1hDvzB3Gv6Ir4vNdDRSVru6O26";
        static string clientSecret = "MCUSCRZF8q78uDethITkr875cGEqu8on7kUb33Qa";

        // The server base address
        static string baseUrl = "https://appcenter.intuit.com/connect/oauth2";

        // this will hold the Access Token returned from the server.
        static string accessToken = null;
        public static async Task<string> GetAccessToken()
        {
            if (accessToken == null)
                using (var client = new HttpClient())
                {
                    Console.Write("Enter Email Address: ");
                    var email = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    var fgColour = Console.ForegroundColor;
                    Console.ForegroundColor = Console.BackgroundColor;
                    var password = Console.ReadLine();
                    Console.ForegroundColor = fgColour;

                    client.BaseAddress = new Uri(baseUrl);

                    // We want the response to be JSON.
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Build up the data to POST.
                    List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
                    postData.Add(new KeyValuePair<string, string>("grant_type", "password"));
                    postData.Add(new KeyValuePair<string, string>("client_id", clientId));
                    postData.Add(new KeyValuePair<string, string>("client_secret", clientSecret));
                    postData.Add(new KeyValuePair<string, string>("scope", "com.intuit.quickbooks.accounting"));
                    postData.Add(new KeyValuePair<string, string>("username", email));
                    postData.Add(new KeyValuePair<string, string>("password", password));

                    FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

                    // Post to the Server and parse the response.
                    HttpResponseMessage response = await client.PostAsync("Token", content);
                    string jsonString = await response.Content.ReadAsStringAsync();
                    object responseData = JsonConvert.DeserializeObject(jsonString);

                    // return the Access Token.
                    accessToken = ((dynamic)responseData).access_token;
                }

            return accessToken;
        }

    }
}
