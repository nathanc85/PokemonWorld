using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PokemonWorld.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Create the request to the API
            WebRequest request = WebRequest.Create("https://pokeapi.co/api/v2/pokemon/1");
            // Send the request.
            WebResponse response = request.GetResponse();
            // Get back the response stream.
            Stream stream = response.GetResponseStream();
            // Make the stream reacheable/accessible.
            StreamReader reader = new StreamReader(stream);
            // Human readable response.
            string responseString = reader.ReadToEnd();

            JObject parsedString = JObject.Parse(responseString);

            return View();
        }
    }
}