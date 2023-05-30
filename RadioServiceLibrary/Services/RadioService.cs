using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RadioServiceLibrary.RadioApiModels;
using RadioServiceLibrary.Services.Interfaces;
using System.Xml.Serialization;

namespace RadioServiceLibrary.Services
{
    public class RadioService : IRadioService
    {
       
        public RadioService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private readonly HttpClient _httpClient;

        public async Task<List<RadioProgram>> GetProgramsFromChannelIdAsync(string channelId)
        {//164 = p3
            string apiUrl = $"https://api.sr.se/api/v2/programs/index?channelid=164&programcategoryid=133";
            //string apiUrl = $"https://api.sr.se/api/v2/programs/index?channelid={channelId}&programcategoryid=133";

            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var programResponse = JsonConvert.DeserializeObject<ProgramResponse>(json);
                return programResponse?.Programs;
            }

            // If the API call fails, handle the error accordingly
            return null;
        }
        public async Task<List<RadioProgram>> GetJsonRadioPrograms()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.sr.se/api/v2");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(
                $"/programs/index?channelid=164&programcategoryid=133");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                try
                {
                    var radioResponse = JsonConvert.DeserializeObject<ProgramResponse>(responseBody);
                    var programs = radioResponse?.Programs;

                    if (radioResponse != null)
                    {

                    }
                    else
                    {
                        Console.WriteLine("No programs found in the API response.");
                    }
                }
                catch (JsonReaderException)
                {
                    Console.WriteLine("Something went wrong while deserializing the response.");
                }
            }
            else
            {
                Console.WriteLine("API request failed with status code: " + response.StatusCode);
            }
            return null;
        }

    }
}
