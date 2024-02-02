using Microsoft.AspNetCore.Mvc;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RainfallAPI.Models;
using RainfallAPI.Helpers;
using System;
using System.Net;

namespace RainfallAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RainfallController : ControllerBase
    {
        private readonly HttpClient _client;
        string uri = "https://environment.data.gov.uk/flood-monitoring/id/stations/{0}/readings";

        public RainfallController()
        {
            _client = new HttpClient();
        }

        [HttpGet(Name = "get-rainfall")]
        [HttpGet("{stationId}")]
        [ProducesResponseType(typeof(rainfallReadingResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public rainfallReadingResponse GetReadings(int stationId)
        {
            rainfallReadingResponse _rainfallReadingResponse = new rainfallReadingResponse();

            _client.BaseAddress = new Uri(string.Format(uri, stationId));
            
            var response = Utils.ConsumeAPI(_client);
            _rainfallReadingResponse = Utils.MapValues(response.Result);

            return _rainfallReadingResponse;
        }
    }
}