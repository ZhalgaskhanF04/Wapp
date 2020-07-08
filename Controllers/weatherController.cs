using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;

namespace aspweatherapp.Controllers
{
    
         public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            
            WebRequest request = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=Almaty&appid=5232698799ee79f1d49bbee1fae2fe4b&lang=ru&units=metric");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader responseReader = new StreamReader(responseStream))
                        {
                            string json = responseReader.ReadToEnd();
                            string data = JObject.Parse(json)["name"].ToString();
                            string sys = JObject.Parse(json)["sys"].ToString();
                            string main = JObject.Parse(json)["main"].ToString();
                            string wind = JObject.Parse(json)["wind"].ToString();
                            string tempFL = JObject.Parse(json)["main"].ToString();
                            
                            //Console.WriteLine(data);
                            
                            ViewData["City"]=JObject.Parse(json)["name"].ToString();
                            ViewData["Country"]= JObject.Parse(sys)["country"].ToString();
                            ViewData["Temp"]=JObject.Parse(main)["temp"].ToString();
                            ViewData["Wind"]=JObject.Parse(wind)["speed"].ToString();
                            ViewData["TempFeelsLike"]=JObject.Parse(tempFL)["feels_like"].ToString();
                            
                        }
                    }
                }
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            //return "This is the Welcome action method...";
            return "";
        }
    }
}