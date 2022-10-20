using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OpenApi.Controllers
{
    /// <summary>
    /// Controller for Chuck Norris Jokes API
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ChuckController : ControllerBase
    {
        private const string baseURL = "https://api.chucknorris.io";
        private HttpClient client = new HttpClient();
        
        public ChuckController()
        {
            // Set Chuck Norris Jokes API base URL
            client.BaseAddress = new Uri(baseURL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Gets all joke categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("jokes/categories")]
        public async Task<IEnumerable<string>> GetJokeCategories()
        {
            try
            {
                List<string> categories = null;

                HttpResponseMessage response = await client.GetAsync($"{baseURL}/jokes/categories");
                if (response.IsSuccessStatusCode)
                {
                    categories = await response.Content.ReadAsAsync<List<string>>();
                }

                return categories;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// Gets jokes that matches the given joke category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("jokes/random")]
        public async Task<Joke> GetJoke(string category)
        {
            try
            {
                Joke joke = null;

                HttpResponseMessage response = await client.GetAsync($"{baseURL}/jokes/random?category={category}");

                if (response.IsSuccessStatusCode)
                {
                    joke = await response.Content.ReadAsAsync<Joke>();
                }

                return joke;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Searches for joke that matches the given search value
        /// This Controller gets Chuck Norris Jokes data directly from the official API website
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("jokes/search")]
        public async Task<JokeSearchResult> SearchJokes(string query)
        {
            try
            {
                JokeSearchResult results = null;

                HttpResponseMessage response = await client.GetAsync($"{baseURL}/jokes/search?query={query}");

                if (response.IsSuccessStatusCode)
                {
                    results = await response.Content.ReadAsAsync<JokeSearchResult>();
                }

                return results;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
