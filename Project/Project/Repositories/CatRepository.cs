using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Project.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Project.Repositories
{
    public class CatRepository
    {
        private const string _APIKEY = "live_beKvhl5Lly9uMiCYQQdGk4ITGdhOOA3VCd0mUA7UdhPbEkJp877YfhZrqgDu7hlp";

        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "application/json");
            return client;
        }

        private static string AddKey(string url)
        {
            return $"{url}?api_key={_APIKEY}";
        }

        public static async Task<List<Breed>> GetBreedsAsync()
        {
            using (HttpClient client = GetClient())
            {
                try
                {
                    string url = AddKey("https://api.thecatapi.com/v1/breeds");
                    string json = await client.GetStringAsync(url);

                    if (json != null)
                    {
                        return JsonConvert.DeserializeObject<List<Breed>>(json);
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static async Task<List<ImageClass>> GetImagesAsync()
        {
            using (HttpClient client = GetClient())
            {
                try
                {
                    string url = AddKey("https://api.thecatapi.com/v1/images/search");
                    string json = await client.GetStringAsync(url);

                    if (json != null)
                    {
                        return JsonConvert.DeserializeObject<List<ImageClass>>(json);
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string PostVoteAsync (string id, int vote)
        {
            var client = new RestClient("https://api.thecatapi.com/v1/votes");

            var request = new RestRequest(Method.POST);
            request.AddHeader("x-api-key", _APIKEY);
            request.AddHeader("content-type", "application/json");

            var body = "";
            if (vote > 0)
            {
                body = @"{" + "\n" +
                $@"    ""image_id"":""{id}""," + "\n" +
                @"    ""sub_id"":""anton-123""," + "\n" +
                @"    ""value"": ""1""" + "\n" +
                @"}";
            } else if (vote < 0)
            {
                body = @"{" + "\n" +
                $@"    ""image_id"":""{id}""," + "\n" +
                @"    ""sub_id"":""anton-123""," + "\n" +
                @"    ""value"": ""-1""" + "\n" +
                @"}";
            }

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        public static async Task<List<Favourite>> GetFavouritesAsync()
        {
            using (HttpClient client = GetClient())
            {
                try
                {
                    string url = AddKey("https://api.thecatapi.com/v1/favourites");
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        return JsonConvert.DeserializeObject<List<Favourite>>(json);
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public static string PostFavourites(string id)
        {
            var client = new RestClient("https://api.thecatapi.com/v1/favourites");
            var request = new RestRequest(Method.POST);
            request.AddHeader("x-api-key", _APIKEY);
            request.AddHeader("content-type", "application/json");
            var body = @"{" + "\n" +
            $@"    ""image_id"":""{id}""," + "\n" +
            @"    ""sub_id"": ""anton-123""" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}
