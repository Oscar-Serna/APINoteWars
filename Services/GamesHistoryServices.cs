using PruebaFetchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PruebaFetchAPI.Services
{
    public class GamesHistoryServices
    {

        private string FetchURL = "https://localhost:7241/api";

        public async Task<dynamic> GetUserScore(int GameIdentificator, string TokenUser)
        {

            string URL = $"{FetchURL}/gamesHistory/GetUserScore";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue> {
                new MKeyValue { Key = "GameIdentificator", Value = GameIdentificator },
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var fetchResult = await InstanceFetchers.SendRequest("GET", URL, ListHeaders);

            Console.WriteLine("GamesH: " + fetchResult);

            return fetchResult;
        }

        public async Task<dynamic> CreateGameHistory(float UserScore, int GameIdentificator, string TokenUser)
        {
            string URL = $"{FetchURL}/gamesHistory/CreateGameHistory";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue> {
                new MKeyValue { Key = "TokenUser", Value = TokenUser },
            };

            var infoCreateGameHistory = new MCreateGameHistory {
                UserScore = UserScore,
                GameIdentificator = GameIdentificator
            };

            string JSONSerialized = JsonSerializer.Serialize(infoCreateGameHistory);

            var fetchResult = await InstanceFetchers.SendRequest("POST", URL, ListHeaders, JSONSerialized);

            Console.WriteLine("GamesH: " + fetchResult);

            return fetchResult;
        }
        public async Task<dynamic> UpdateUserScore(float NewUserScore, int GameIdentificator, string TokenUser)
        {
            string URL = $"{FetchURL}/gamesHistory/UpdateUserScore";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue> {
                new MKeyValue { Key = "NewUserScore", Value = NewUserScore },
                new MKeyValue { Key = "GameIdentificator", Value = GameIdentificator },
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var fetchResult = await InstanceFetchers.SendRequest("PUT", URL, ListHeaders);

            Console.WriteLine("GamesH: " + fetchResult);

            return fetchResult;
        }
        public async Task<dynamic> DeleteGameHistory(int GameIdentificator, string TokenUser)
        {
            string URL = $"{FetchURL}/gamesHistory/DeleteGameHistory";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue> {
                new MKeyValue { Key = "GameIdentificator", Value = GameIdentificator },
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var fetchResult = await InstanceFetchers.SendRequest("DELETE", URL, ListHeaders);

            Console.WriteLine("GamesH: " + fetchResult);

            return fetchResult;
        }

    }
}
