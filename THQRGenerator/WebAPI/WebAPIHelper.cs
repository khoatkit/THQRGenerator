using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace THQRGenerator.WebAPI
{
    class WebAPIHelper
    {
        public static string Error { get; private set; }
        private static readonly string baseUrl;
        private static string _username;
        private static readonly HttpClient client;
        private static string token;
        static WebAPIHelper()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
            };
            client = new HttpClient(handler);
            baseUrl = Properties.Settings.Default.WebapiUrl;
            //baseUrl = @"http://localhost:50345/api/";
        }
        public static async Task LoginAsync(string username, string password, string role)
        {
            if (!string.IsNullOrEmpty(token) && username == _username)
            {
                Error = "";
                return;
            }
            object user = new
            {
                username,
                password,
                role
            };
            _username = "";
            var tmp = await GetDataAsync<string[]>("POST", "account/token", user);
            if (tmp != null && tmp.Length > 0 && !string.IsNullOrEmpty(tmp[0]))
            {
                token = tmp[0];
                _username = username;
            }
            else
                Error = "Lỗi kết nối!";
        }
        public static async Task<T> GetDataAsync<T>(string method, string url, object body)
        {
            var bodyStr = body == null ? "" : JsonConvert.SerializeObject(body);//JsonSerializer.ToJsonString(body);
            return await GetDataAsync<T>(method, url, bodyStr);
        }
        private static async Task<T> GetDataAsync<T>(string method, string url, string body)
        {
            var result = await GetDataAsync(method, url, body);
            if (string.IsNullOrEmpty(result))
                return default;
            if (result.Length >= 6 && result.Substring(0, 6) == "ERROR:")
            {
                Error = result;
                return default;
            }
            return JsonConvert.DeserializeObject<T>(result);
        }
        private static async Task<string> GetDataAsync(string method, string url, string body)
        {
            try
            {
                Error = "";
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(baseUrl + url),
                    Method = new HttpMethod(method),
                    Headers = { { "Authorization", $"Bearer {token}" } }
                };
                if (method == "GET")
                    request.Headers.Add("AcceptEncoding", "gzip");
                else
                    request.Content = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await client.SendAsync(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var code = (int)response.StatusCode;
                    string reason;
                    reason = await response.Content.ReadAsStringAsync();
                    if (code == 500)
                        reason = JsonConvert.DeserializeObject<string>(reason);
                    throw new Exception($"{code}: {response.ReasonPhrase} \n{reason}");
                }
                else
                    return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Error = $"ERROR: {ex.Message}";
                return "";
            }
        }
    }
}