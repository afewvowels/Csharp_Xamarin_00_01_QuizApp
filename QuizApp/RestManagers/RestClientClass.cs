using Newtonsoft.Json;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.RestManagers
{
    public class RestClientClass : IRestServiceClass
    {
        HttpClient _client;

        public List<Class> Classes { get; set; }

        public RestClientClass()
        {
            _client = new HttpClient();
        }

        public async Task<ObservableCollection<Class>> RefreshDataAsync()
        {
            Classes = new List<Class>();
            ObservableCollection<Class> ClassesData = new ObservableCollection<Class>(Classes);

            var uri = new Uri(string.Format(Constants.ClassAddress, string.Empty));

            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Classes = JsonConvert.DeserializeObject<List<Class>>(content);
                    ClassesData = new ObservableCollection<Class>(Classes);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return ClassesData;
        }

        public async Task SaveClassInfoAsync(Class classObj, bool isNewItem = false)
        {
            var uri = new Uri(string.Format(Constants.ClassAddress, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(classObj);

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    response = await _client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tClass successfully saved");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteClassInfoAsync(int pk)
        {
            var uri = new Uri(string.Format(Constants.ClassAddress, string.Empty));

            try
            {
                var response = await _client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tClass successfully deleted");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        Task<List<Class>> IRestServiceClass.RefreshDataAsync()
        {
            throw new NotImplementedException();
        }
    }
}