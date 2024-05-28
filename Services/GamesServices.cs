using PruebaFetchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PruebaFetchAPI.Services
{
    public class GamesServices
    {

        private string FetchURL = "https://localhost:7241/api";

        public async Task<dynamic> GetGameName( int GameIdentificator, string TokenUser)
        {
            string URL = $"{FetchURL}/games/GetGameName";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "GameIdentificator", Value = GameIdentificator },
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var fetchResult = await InstanceFetchers.SendRequest("GET", URL, ListHeaders);

            Console.WriteLine("Games: " + fetchResult);

            return fetchResult;
        }
        public async Task<dynamic> GetGameCategory(int GameIdentificator, string TokenUser)
        {
            string URL = $"{FetchURL}/games/GetGameCategory";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "GameIdentificator", Value = GameIdentificator },
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var fetchResult = await InstanceFetchers.SendRequest("GET", URL, ListHeaders);

            Console.WriteLine("Games: " + fetchResult);

            return fetchResult;
        }
        public async Task<dynamic> GetGameMaxScore(int GameIdentificator, string TokenUser)
        {
            string URL = $"{FetchURL}/games/GetGameMaxScore";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "GameIdentificator", Value = GameIdentificator },
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var fetchResult = await InstanceFetchers.SendRequest("GET", URL, ListHeaders);

            Console.WriteLine("Games: " + fetchResult);

            return fetchResult;
        }
        public async Task<dynamic> CreateGame(string GameName, string Category, float MaxScore, int SubjectIdentificator, int GameIdentificator, string TokenUser)
        {

            string URL = $"{FetchURL}/games/CreateGame";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var InfoCreateGame = new MCreateGame {
                GameName = GameName,
                Category = Category,
                MaxScore = MaxScore,
                SubjectIdentificator = SubjectIdentificator,
                GameIdentificator = GameIdentificator
            };

            string JSONSerialized = JsonSerializer.Serialize(InfoCreateGame);

            var fetchResult = await InstanceFetchers.SendRequest("POST", URL, ListHeaders, JSONSerialized);

            Console.WriteLine("Games: " + fetchResult);

            return fetchResult;

        }
        public async Task<dynamic> UpdateGameName(int GameIdentificator, string NewGameName, string TokenUser)
        {

            string URL = $"{FetchURL}/games/UpdateGameName";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "GameIdentificator", Value = GameIdentificator },
                new MKeyValue { Key = "NewGameName", Value = NewGameName },
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var fetchResult = await InstanceFetchers.SendRequest("PUT", URL, ListHeaders);

            Console.WriteLine("Games: " + fetchResult);

            return fetchResult;

        }
        public async Task<dynamic> UpdateGameCategory(int GameIdentificator, string NewGameCategory, string TokenUser)
        {

            string URL = $"{FetchURL}/games/UpdateGameCategory";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "GameIdentificator", Value = GameIdentificator },
                new MKeyValue { Key = "NewGameCategory", Value = NewGameCategory },
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var fetchResult = await InstanceFetchers.SendRequest("PUT", URL, ListHeaders);

            Console.WriteLine("Games: " + fetchResult);

            return fetchResult;

        }
        public async Task<dynamic> UpdateGameMaxScore(int GameIdentificator, float NewMaxScore, string TokenUser)
        {

            string URL = $"{FetchURL}/games/UpdateGameMaxScore";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "GameIdentificator", Value = GameIdentificator },
                new MKeyValue { Key = "NewMaxScore", Value = NewMaxScore },
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var fetchResult = await InstanceFetchers.SendRequest("PUT", URL, ListHeaders);

            Console.WriteLine("Games: " + fetchResult);

            return fetchResult;

        }
        public async Task<dynamic> DeleteGame(int GameIdentificator, string TokenUser)
        {

            string URL = $"{FetchURL}/games/DeleteGame";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "GameIdentificator", Value = GameIdentificator },
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var fetchResult = await InstanceFetchers.SendRequest("DELETE", URL, ListHeaders);

            Console.WriteLine("Games: " + fetchResult);

            return fetchResult;

        }
    }
}
