using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json;
using Weather_test.Models;

namespace Weather_test.Controllers
{
    public class WeatherController : Controller
    {       
        public async Task<IActionResult> ShowData3()
        {
            string URI = "https://opendata.cwb.gov.tw/api/v1/rest/datastore/F-D0047-007?Authorization=CWB-CF4E5738-53AF-46F7-82C7-A0529BB204B8&format=JSON&elementName=MaxCI&sort=time";
            HttpClient CL = new HttpClient();
            var response = await CL.GetStringAsync(URI);
            var collection = JsonConvert.DeserializeObject<IEnumerable<Weather>>("["+response+"]");
            
            return View(collection);
        }

    }
}
