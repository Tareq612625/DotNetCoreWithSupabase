using DotNetCoreWithSuperbase.Interface;
using DotNetCoreWithSuperbase.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace DotNetCoreWithSuperbase
{
    public class SuperbaseService : ISuperbaseService
    {
        private readonly HttpClient _httpClient;
        private readonly SuperbaseConfig _superbaseConfig;

        public SuperbaseService(HttpClient httpClient, IOptions<SuperbaseConfig> superbaseConfig)
        {
            _httpClient = httpClient;
            _superbaseConfig = superbaseConfig.Value;
        }
        public async Task<List<Student>> GetStudentsAsync()
        {
            string endpoint = "/rest/v1/Student?select=*";
            string url = $"{_superbaseConfig.BaseUrl}{endpoint}";

            // Set the API key in the request headers
            _httpClient.DefaultRequestHeaders.Add("apikey", _superbaseConfig.ApiKey);

            // Make the GET request
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the content and deserialize it into a list of Student objects
                var content = await response.Content.ReadAsStringAsync();
                var students = JsonSerializer.Deserialize<List<Student>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Use this option to ignore case when deserializing
                });

                return students;
            }
            else
            {
                // Handle error cases (throw an exception, log the error, etc.)
                // For simplicity, return an empty list here
                return new List<Student>();
            }
        }

    }
}
