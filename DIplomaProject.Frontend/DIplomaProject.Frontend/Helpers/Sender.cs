using DIplomaProject.Frontend.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Web;

namespace DIplomaProject.Frontend.Helpers
{
    public class Sender
    {
        private readonly string _baseUrl;
        public Sender()
        {
            _baseUrl = "https://localhost:7161/";
        }

        public async Task<IEnumerable<T>> GetAsync<T>(string endpoint)
        {
            var builder = new UriBuilder($"{_baseUrl}{endpoint}");

            var query = HttpUtility.ParseQueryString(builder.Query);

            builder.Query = query.ToString();

            using var client = new HttpClient();

            client.Timeout = TimeSpan.FromMinutes(10);

            var json = string.Empty;
            var sW = new Stopwatch();

            sW.Start();

            using var response = await client.GetAsync(builder.ToString());

            sW.Stop();

            try
            {
                response.EnsureSuccessStatusCode();

                json = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
                {
                var strJson = await response.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {

            }

            sW.Restart();

            var items = await DeserializeObjectAsync<T>(json);

            sW.Stop();

            return items;
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T obj)
        {
            var builder = new UriBuilder($"{_baseUrl}{endpoint}");

            using var client = new HttpClient();

            client.Timeout = TimeSpan.FromMinutes(10);

            var serializedObject = await SerializeObjectAsync(obj);

            var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            using var response = await client.PostAsync(builder.ToString(), content);

            response.EnsureSuccessStatusCode();

            return response;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string endpoint, IdDto dto)
        {
            var builder = new UriBuilder($"{_baseUrl}{endpoint}");

            using var client = new HttpClient();

            client.Timeout = TimeSpan.FromMinutes(10);

            var serializedObject = await SerializeObjectAsync(dto);

            var request = new HttpRequestMessage(HttpMethod.Delete, builder.ToString())
            {
                Content = new StringContent(serializedObject, Encoding.UTF8, "application/json")
            };

            using var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            return response;
        }

        public async Task<HttpResponseMessage> UpdateAsync<T>(string endpoint, T obj)
        {
            var builder = new UriBuilder($"{_baseUrl}{endpoint}");

            using var client = new HttpClient();

            client.Timeout = TimeSpan.FromMinutes(10);

            var serializedObject = await SerializeObjectAsync(obj);

            var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            using var response = await client.PutAsync(builder.ToString(), content);

            response.EnsureSuccessStatusCode();

            return response;
        }

        public async Task<HttpResponseMessage> FindByIdAsync(string endpoint, IdDto obj)
        {
            var builder = new UriBuilder($"{_baseUrl}{endpoint}");

            using var client = new HttpClient();

            client.Timeout = TimeSpan.FromMinutes(10);

            var serializedObject = await SerializeObjectAsync(obj);

            var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            using var response = await client.GetAsync(builder.ToString());

            response.EnsureSuccessStatusCode();

            return response;
        }

        private static async Task<List<T>> DeserializeObjectAsync<T>(string json)
        {
            var task = new Task<List<T>>(() => JsonConvert.DeserializeObject<List<T>>(json));

            task.Start();

            var result = await task;

            return result;
        }

        private static async Task<string> SerializeObjectAsync<T>(T obj)
        {
            var task = new Task<string>(() => JsonConvert.SerializeObject(obj));

            task.Start();

            var result = await task;

            return result;
        }
    }
}
