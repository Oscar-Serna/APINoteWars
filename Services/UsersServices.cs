using PruebaFetchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace PruebaFetchAPI.Services
{
    public class UsersServices
    {

        private string FetchURL = "https://localhost:7241/api";

        //VALIDAR ENTRADAS CON ASCII INVALIDOS (ñ)

        public async Task<dynamic> GetAllUserInfo(string TokenUser)
        {

            string URL = $"{FetchURL}/users/GetAllUserInfo";

            var InstanceFetchers = new Fetchers();

            var ListHeader = new List<MKeyValue> { new MKeyValue {  Key = "TokenUser", Value = TokenUser } };

            var fetchResult = await InstanceFetchers.SendRequest("GET", URL, ListHeader);

            return fetchResult;

        }


        public async Task<dynamic> GetUsername(string TokenUser)
        {

            string URL = $"{FetchURL}/users/GetUsername";

            var InstanceFetchers = new Fetchers();

            var ListHeader = new List<MKeyValue> { new MKeyValue { Key = "TokenUser", Value = TokenUser } };

            var fetchResult = await InstanceFetchers.SendRequest("GET", URL, ListHeader);

            Console.WriteLine("Usuarios: " + fetchResult);

            return fetchResult;
        }

        public async Task<dynamic> GetName(string TokenUser)
        {

            string URL = $"{FetchURL}/users/GetName";

            var InstanceFetcher = new Fetchers();

            var ListHeader = new List<MKeyValue> { new MKeyValue { Key = "TokenUser", Value = TokenUser } };

            var fetchResult = await InstanceFetcher.SendRequest("GET", URL, ListHeader);

            Console.WriteLine("Usuarios: " + fetchResult);

            return fetchResult;
        }

        public async Task<dynamic> GetEmail(string TokenUser)
        {

            string URL = $"{FetchURL}/users/GetEmail";

            var InstanceFetcher = new Fetchers();

            var ListHeader = new List<MKeyValue> { new MKeyValue { Key = "TokenUser", Value = TokenUser } };

            var fetchResult = await InstanceFetcher.SendRequest("GET", URL, ListHeader);

            Console.WriteLine("Usuarios: " + fetchResult);

            return fetchResult;
        }

        public async Task<dynamic> GetTokenUser(string Username, string Email, string Password)
        {

            string URL = $"{FetchURL}/users/GetTokenUser";

            var InstanceFetcher = new Fetchers();

            var ListHeader = new List<MKeyValue>
            {
                new MKeyValue { Key = "Username", Value = Username },
                new MKeyValue { Key = "Email", Value = Email },
                new MKeyValue { Key = "Password", Value = Password }
            };

            var fetchResult = await InstanceFetcher.SendRequest("GET", URL, ListHeader);

            Console.WriteLine("Usuarios: " + fetchResult);

            return fetchResult;

        }

        public async Task<dynamic> CreateUser(string Username, string Name, string Email, string Password)
        {

            string URL = $"{FetchURL}/users/CreateUser";

            var InstaceFetcher = new Fetchers();

            var InfoNewUser = new MCreateUser {
                Username = Username,
                Name = Name,
                Email = Email,
                Password =Password
            };

            string JSONSerialized = JsonSerializer.Serialize(InfoNewUser);

            var fetchResult = await InstaceFetcher.SendRequest("POST", URL, null, JSONSerialized);

            Console.WriteLine("Usuarios: " + fetchResult);

            return fetchResult;
        }

        public async Task<dynamic> UpdateUsername(string NewUsername, string TokenUser)
        {

            string URL = $"{FetchURL}/users/UpdateUsername";

            var InstanceFetcher = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue {Key = "TokenUser", Value = TokenUser},
                new MKeyValue {Key = "NewUsername", Value = NewUsername}
            };

            var fetchResult = await InstanceFetcher.SendRequest("PUT", URL, ListHeaders);

            Console.WriteLine("Usuarios: " + fetchResult);

            return fetchResult;
        }

        public async Task<dynamic> UpdateName(string NewName, string TokenUser)
        {

            string URL = $"{FetchURL}/users/UpdateName";

            var InstanceFetcher = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "TokenUser", Value = TokenUser },
                new MKeyValue { Key = "NewName", Value = NewName }
            };

            var fetchResult = await InstanceFetcher.SendRequest("PUT", URL, ListHeaders);

            Console.WriteLine(fetchResult);

            return fetchResult;

        }

        public async Task<dynamic> UpdateEmail(string NewEmail, string TokenUser)
        {

            string URL = $"{FetchURL}/users/UpdateEmail";

            var InstanceFetcher = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "TokenUser", Value = TokenUser },
                new MKeyValue { Key = "NewEmail", Value = NewEmail }
            };

            var fetchResult = await InstanceFetcher.SendRequest("PUT", URL, ListHeaders);

            Console.WriteLine("Usuarios: " + fetchResult);

            return fetchResult;

        }

        public async Task<dynamic> UpdatePassword(string NewPassword, string TokenUser)
        {
            string URL = $"{FetchURL}/users/UpdatePassword";

            var InstanceFetcher = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "TokenUser", Value = TokenUser },
                new MKeyValue { Key = "NewPassword", Value = NewPassword }
            };

            var fetchResult = await InstanceFetcher.SendRequest("PUT", URL, ListHeaders);

            Console.WriteLine(fetchResult);

            return fetchResult;
        }

        public async Task<dynamic> UpdateTokenUser(string OldTokenUser)
        {
            string URL = $"{FetchURL}/users/UpdateTokenUser";

            var InstanceFetcher = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "OldTokenUser", Value = OldTokenUser }
            };

            var fetchResult = await InstanceFetcher.SendRequest("PUT", URL, ListHeaders);

            Console.WriteLine(fetchResult);

            return fetchResult;
        }

        public async Task<dynamic> DeleteUser(string TokenUser)
        {
            string URL = $"{FetchURL}/users/DeleteUser";

            var InstanceFetcher = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var fetchResult = await InstanceFetcher.SendRequest("DELETE", URL, ListHeaders);

            Console.WriteLine(fetchResult);

            return fetchResult;
        }

    }
}
