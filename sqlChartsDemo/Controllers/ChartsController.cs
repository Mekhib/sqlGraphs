using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sqlChartsDemo.Models;
using System.Text.Json;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;



namespace sqlChartsDemo.Controllers
{
    public class ChartsController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        [Route("Charts/InternetSales/{chart}")]
        public IActionResult InternetSales(string chart)
        {

            Console.WriteLine("fileName" + chart);

            string dataString = System.IO.File.ReadAllText($"Utils/{chart}");

            var data = JArray.Parse(dataString).Cast<JObject>();

            Dictionary<string, string>? fieldsDic = JsonConvert.DeserializeObject<Dictionary<string, string>>(data.First().ToString()).ToDictionary(x => x.Key, x => x.Value.ToString());


            ViewBag.data = data;
            ViewBag.headers = fieldsDic;
            ViewBag.fileName = chart;

            return View();
        }

        [HttpGet]
        [Route("Charts/InternetSalesBarGraph/{charts}")]
        public IActionResult InternetSalesBarGraph(string charts)

        {

            string data = System.IO.File.ReadAllText($"Utils/{charts}");
            JArray dataObj = JArray.Parse(data);
            var dictionaryValues = InternetSalesModel.FormatData(dataObj);

            ViewBag.fileName = charts;

            return View(dictionaryValues);
        }

      
        public IActionResult AllCharts()
        {
           
            string[] fileArray = Directory.GetFiles("Utils");

            ViewBag.files = fileArray;

            return View();
        }


    }
}

