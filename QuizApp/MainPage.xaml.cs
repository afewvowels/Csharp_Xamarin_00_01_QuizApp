using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using QuizApp.Models;

namespace QuizApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private const string url = "https://keithbsmith.me/tests/quizapp/api/students";
        private HttpClient _Client = new HttpClient();
        private ObservableCollection<Student> _student;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = await _Client.GetStringAsync(url);
            var student = JsonConvert.DeserializeObject<List<Student>>(content);
            _student = new ObservableCollection<Student>(student);
            Students_List.ItemsSource = _student;
            base.OnAppearing();
        }

        private async void OnAdd(object sender, System.EventArgs e)
        {
            var student = new Student()
            {
                qa_users_name = "appName1",
                qa_users_pass = "appPassword",
                qa_users_email = "app@appy.com",
                qa_users_score = 999
            };
            _student.Insert(0, student);
            var content = JsonConvert.SerializeObject(student);
            await _Client.PostAsync(url, new StringContent(content));
        }

        private async void OnDelete(object sender, System.EventArgs e)
        {
            var student = _student[0];
            _student.Remove(student);
            await _Client.DeleteAsync(url + "/" + student.qa_users_pk);
        }
    }
}
