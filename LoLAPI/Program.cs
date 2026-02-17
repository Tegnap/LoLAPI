using System;
using System.Text.Json;
using LoLAPI;

namespace MyApp
{
    internal class Program
    {
        static string version = "1.0";
        static List<Champion> champions = new List<Champion>();
        static async Task Main(string[] args)
        {

            await LoadChampions();
        }

        public static async Task LoadVersion()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //client.Timeout = new TimeSpan(30);

                    string url = "https://ddragon.leagueoflegends.com/api/versions.json";

                    var responseAPI = await client.GetStringAsync(url);

                    var response = JsonSerializer.Deserialize<string[]>(responseAPI);

                    version = response[0];
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Hívási hiba: {httpEx.Message}");
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Átalakítási hiba: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }
        }

        public static async Task LoadChampions()
        {

            try
            {
                await LoadVersion();
                using (HttpClient client = new HttpClient())
                {
                    //client.Timeout = new TimeSpan(30);

                    string url = $"https://ddragon.leagueoflegends.com/cdn/{version}/data/hu_HU/champion.json";

                    var responseAPI = await client.GetStringAsync(url);

                    var response = JsonSerializer.Deserialize<ChampionDatas>(responseAPI);

                    champions = response.Data.Values.ToList();
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Hívási hiba: {httpEx.Message}");
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Átalakítási hiba: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }
        }
    }
}