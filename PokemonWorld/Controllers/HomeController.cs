using Newtonsoft.Json.Linq;
using PokemonWorld.Models;
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
            // Parses the response string.
            JObject parsedString = JObject.Parse(responseString);
            // Map the parsed string to our Pokemon model.
            Pokemon pokemon = parsedString.ToObject<Pokemon>();

            return View(pokemon);
        }

        public ActionResult StarWars()
        {
            WebRequest request = WebRequest.Create("https://swapi.co/api/people/1");
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string readableResponse = reader.ReadToEnd();
            JObject parsed = JObject.Parse(readableResponse);
            SWCharacter character = parsed.ToObject<SWCharacter>();

            return View(character);
        }
    }
}