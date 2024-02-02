using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using RainfallAPI.Models;
using System.Reflection.Metadata.Ecma335;

namespace RainfallAPI.Helpers
{
    public static class Utils
    {
        public static async Task<HttpResponseMessage> ConsumeAPI(HttpClient _client)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress);

                return response;
            }
        }

        public static rainfallReadingResponse MapValues(HttpResponseMessage response)
        {
            rainfallReadingResponse rainfallReadingResponse = new rainfallReadingResponse();

            if (response.IsSuccessStatusCode)
            {
                var ObjResponse = response.Content.ReadAsStringAsync().Result;

                var jobject = (JObject)JsonConvert.DeserializeObject(ObjResponse);

                var items = (JArray)jobject["items"];

                foreach (var item in items)
                {
                    rainfallReading rainfallReading = new rainfallReading();

                    rainfallReading.amountMeasured = item["value"].Value<double>();
                    rainfallReading.dateMeasured =   item["dateTime"].Value<DateTime>();

                    rainfallReadingResponse.rainfallReadings.Add(rainfallReading);
                }
            }
            return rainfallReadingResponse;
        }
    }
}
