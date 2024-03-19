using Newtonsoft.Json;
using RickAndMortyProject.App_Code.Entities;

namespace RickAndMortyProject.App_Code.Helpers
{
    public static class APIHelper
    {
        /// <summary>
        /// Create list of all characters from the Rick And Morty API.
        /// </summary>
        /// <returns>List of character objects.</returns>
        public static List<Character> GetCharacters()
        {
            List<Character> characters = [];

            string uri = "api/character";

            bool getMoreCharacters = true;

            // Repeatedly call the API until no more characters can be found
            while (getMoreCharacters == true)
            {
                CharactersResponse charactersResponse = GetAPICharactersResponse(uri);

                // Add response result (array of characters) into list of all characters
                if (charactersResponse.Results != null)
                {
                    characters.AddRange(charactersResponse.Results);
                }

                // If there is no next page to get characters from, no more characters can be found
                if (charactersResponse.Info.Next == null)
                {
                    getMoreCharacters = false;
                }
                else
                {
                    // Use the next page URI for the next API call
                    uri = charactersResponse.Info.Next;
                }
            }

            return characters;
        }

        /// <summary>
        /// Get response object from the Rick And Morty API.
        /// </summary>
        /// <param name="requestUri">Exact URI to get result for.</param>
        /// <returns>Character Response object.</returns>
        private static CharactersResponse GetAPICharactersResponse(string requestUri)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://rickandmortyapi.com/");

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync(requestUri).Result;

            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsStringAsync().Result;

                CharactersResponse? charactersResponse = JsonConvert.DeserializeObject<CharactersResponse>(dataObjects);

                if (charactersResponse != null)
                {
                    return charactersResponse;
                }
            }

            // If failed at any stage, create empty character response
            return new CharactersResponse { 
                Info = new() { }
            };
        }
    }
}
