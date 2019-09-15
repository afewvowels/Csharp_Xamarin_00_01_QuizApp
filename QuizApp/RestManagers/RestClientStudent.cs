using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QuizApp.Models;

namespace QuizApp.RestManagers
{
    public class RestClientStudent : IRestServiceStudent
    {
        HttpClient _client;

        public List<Student> Students { get; set; }

        public RestClientStudent()
        {
            _client = new HttpClient();
        }

        public async Task<List<Student>> RefreshDataAsync()
        {
            Students = new List<Student>();

            var uri = new Uri(string.Format(Constants.StudentAddress, string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Students = JsonConvert.DeserializeObject<List<Student>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Students;
        }

        public async Task SaveStudentInfoAsync(Student student, bool isNewItem = false)
        {
            var uri = new Uri(string.Format(Constants.StudentAddress, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(student);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    response = await _client.PutAsync(uri, content);
                }

                if(response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tStudent successfully saved");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteStudentInfoAsync(int pk)
        {
            var uri = new Uri(string.Format(Constants.StudentAddress, string.Empty));

            try
            {
                var response = await _client.DeleteAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tStudent successfully deleted");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        Task<List<Student>> IRestServiceStudent.RefreshDataAsync()
        {
            throw new NotImplementedException();
        }
    }
}
