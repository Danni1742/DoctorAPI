using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Models;
using Models.SymptomeAPI;
using BLL.Interfaces;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace BLL.Services
{
    public class SymptomCheckerApiRepository : ISymptomCheckerApiRepository
    {
        private readonly HttpClient _httpClient;
        private readonly DiagnosisClient _diagnosisClient;
        private readonly string _username;
        private readonly string _password;
        private readonly string _authUrl;
        private readonly string _language;
        private readonly string _healthUrl;
        public SymptomCheckerApiRepository(IConfiguration config, HttpClient httpClient)
        {
            _username = config.GetSection("SymptomCheckerApiOptions")["apiusername"];
            _password = config.GetSection("SymptomCheckerApiOptions")["apipassword"];
            _authUrl = config.GetSection("SymptomCheckerApiOptions")["priaid_authservice_url"];
            _language = config.GetSection("SymptomCheckerApiOptions")["language"];
            _healthUrl = config.GetSection("SymptomCheckerApiOptions")["priaid_healthservice_url"];
            //_diagnosisClient = new DiagnosisClient(_username, _password, _authUrl, _language, _healthUrl);
            _httpClient = httpClient;
        }

        public async Task<List<HealthItem>> GetAllSymptoms()
        {

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://priaid-symptom-checker-v1.p.rapidapi.com/symptoms?language=en-gb&format=json"),
                Headers =
            {
                { "x-rapidapi-host", "priaid-symptom-checker-v1.p.rapidapi.com" },
                { "x-rapidapi-key", "c09359bd64msh59fff5c1f1cabf3p143d77jsn342309eb42f0" },
            },
            };
            List<HealthItem> healthItems = new List<HealthItem>();
            //return await _httpClient.SendAsync(request)
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                JArray jsonArray = JArray.Parse(body);
                JObject data;
                foreach (var n in jsonArray)
                {
                    data = JObject.Parse(n.ToString());
                    healthItems.Add(data.ToObject<HealthItem>());
                }
                //dynamic data = JObject.Parse(jsonArray[0].ToString());
                //var Jobject = JObject.Parse(body);
                //healthItems = Jobject["healthitem"].ToObject<List<HealthItem>>();
                
            }
            return (healthItems);

        }
        public async Task<List<HealthItem>> GetSpecialisationBySymptoms(List<int> selectedSymptoms, Gender gender, int yearOfBirth)
        {
            if (selectedSymptoms == null || selectedSymptoms.Count == 0)
                throw new ArgumentNullException("selectedSymptoms  Can not be null or empty");

            //string serializedSymptoms = this._serializer.Serialize(selectedSymptoms);
            var serializedSymptoms = new JObject(selectedSymptoms);

            string action = string.Format("diagnosis/specialisations?symptoms={0}&gender={1}&year_of_birth={2}", serializedSymptoms, gender.ToString(), yearOfBirth);
            string url = "https://priaid-symptom-checker-v1.p.rapidapi.com/" + action  + "&language=en-gb&format=json";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
            {
                { "x-rapidapi-host", "priaid-symptom-checker-v1.p.rapidapi.com" },
                { "x-rapidapi-key", "c09359bd64msh59fff5c1f1cabf3p143d77jsn342309eb42f0" },
            },
            };
            List<HealthItem> healthItems = new List<HealthItem>();
            //return await _httpClient.SendAsync(request)
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                JArray jsonArray = JArray.Parse(body);
                JObject data;
                foreach (var n in jsonArray)
                {
                    data = JObject.Parse(n.ToString());
                    healthItems.Add(data.ToObject<HealthItem>());
                }
                //dynamic data = JObject.Parse(jsonArray[0].ToString());
                //var Jobject = JObject.Parse(body);
                //healthItems = Jobject["healthitem"].ToObject<List<HealthItem>>();

            }
            return (healthItems);

        }



        //public  List<HealthItem> Symptomes()
        //        {
        //            return _diagnosisClient.LoadSymptoms();
        //        }

        //        //public HealthItem Symptome(int id)
        //        //{
        //        //    return _diagnosisClient.LoadSymptoms().Find(id => this.ID);
        //        //}

        //        public List<HealthItem> Issues()
        //        {
        //            return _diagnosisClient.LoadIssues();
        //        }

        //        public HealthIssueInfo Issue(int id)
        //        {
        //            return _diagnosisClient.LoadIssueInfo(id);
        //        }
    }
}
