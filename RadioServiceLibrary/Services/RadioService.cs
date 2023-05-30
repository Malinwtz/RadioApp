using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RadioServiceLibrary.ProgramApiModels;
using RadioServiceLibrary.Services.Interfaces;


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

        public async Task<List<RadioProgram>> GetAllProgramsAsync()
        {
            // string apiUrl = $"https://api.sr.se/api/v2/programs/index?channelid={channelId}&programcategoryid=133&format=json";
          //  string apiUrl = $"https://api.sr.se/api/v2/programs/index?programcategoryid=133&format=json";
            string apiUrl = $"https://api.sr.se/api/v2/programs/index?programcategoryid=133&format=json&pagination=false";

            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                try
                {
                    var programResponse = JsonConvert.DeserializeObject<ProgramResponse>(json);
                    return programResponse?.Programs;
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
