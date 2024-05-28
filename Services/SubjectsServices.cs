using PruebaFetchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PruebaFetchAPI.Services
{
    public class SubjectsServices
    {

        private string FetchURL = "https://localhost:7241/api";

        public async Task<dynamic> GetQuantityGames(int SubjectIdentificator, string TokenUser)
        {

            string URL = $"{FetchURL}/subjects/GetQuantityGames";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "SubjectIdentificator", Value = SubjectIdentificator },
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var fetchResult = await InstanceFetchers.SendRequest("GET", URL, ListHeaders);

            Console.WriteLine("Subjects: " + fetchResult);

            return fetchResult;
        }

        public async Task<dynamic> GetSubjectSemester(int SubjectIdentificator, string TokenUser)
        {
            string URL = $"{FetchURL}/subjects/GetSubjectSemester";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "SubjectIdentificator", Value = SubjectIdentificator },
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var fetchResult = await InstanceFetchers.SendRequest("GET", URL, ListHeaders);

            Console.WriteLine("Subjects: " + fetchResult);

            return fetchResult;
        }

        public async Task<dynamic> CreateSubject(string SubjectName, int Semester, int SubjectIdentificator, string TokenUser)
        {
            string URL = $"{FetchURL}/subjects/CreateSubject";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var InfoCreateSubject = new MCreateSubject {
                SubjectName = SubjectName,
                Semester = Semester,
                SubjectIdentificator = SubjectIdentificator
            };

            string JSONSerialized = JsonSerializer.Serialize(InfoCreateSubject);

            var fetchResult = await InstanceFetchers.SendRequest("POST", URL, ListHeaders, JSONSerialized);

            Console.WriteLine("Subjects: " + fetchResult);

            return fetchResult;
        }

        public async Task<dynamic> UpdateSubjectName(int SubjectIdentificator, string NewSubjectName, string TokenUser)
        {
            string URL = $"{FetchURL}/subjects/UpdateSubjectName";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "SubjectIdentificator", Value = SubjectIdentificator },
                new MKeyValue { Key = "NewSubjectName", Value = NewSubjectName },
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var fetchResult = await InstanceFetchers.SendRequest("PUT", URL, ListHeaders);

            Console.WriteLine("Subjects: " + fetchResult);

            return fetchResult;
        }

        public async Task<dynamic> UpdateSubjectSemester(int SubjectIdentificator, int NewSubjectSemester, string TokenUser)
        {
            string URL = $"{FetchURL}/subjects/UpdateSubjectSemester";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "SubjectIdentificator", Value = SubjectIdentificator },
                new MKeyValue { Key = "NewSubjectSemester", Value = NewSubjectSemester },
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var fetchResult = await InstanceFetchers.SendRequest("PUT", URL, ListHeaders);

            Console.WriteLine("Subjects: " + fetchResult);

            return fetchResult;
        }

        public async Task<dynamic> DeleteSubject(int SubjectIdentificator, string TokenUser)
        {
            string URL = $"{FetchURL}/subjects/DeleteSubject";

            var InstanceFetchers = new Fetchers();

            var ListHeaders = new List<MKeyValue>
            {
                new MKeyValue { Key = "SubjectIdentificator", Value = SubjectIdentificator },
                new MKeyValue { Key = "TokenUser", Value = TokenUser }
            };

            var fetchResult = await InstanceFetchers.SendRequest("DELETE", URL, ListHeaders);

            Console.WriteLine("Subjects: " + fetchResult);

            return fetchResult;
        }
    }
}
