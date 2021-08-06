using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Task3
{
    public class APIConnection
    {
        public static HttpClient ApiClient { get; set; }
        public APIConnection()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
