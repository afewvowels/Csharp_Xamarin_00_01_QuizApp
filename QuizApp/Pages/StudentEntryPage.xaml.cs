using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using QuizApp.Models;

using Xamarin.Forms;

namespace QuizApp.Pages
{
    public partial class StudentEntryPage : ContentPage
    {
        private const string url = "https://keithbsmith.me/tests/quizapp/api/students";
        private HttpClient _Client = new HttpClient();
        private ObservableCollection<Student> _student;

        public StudentEntryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = await _Client.GetStringAsync(url);
            var student = JsonConvert.DeserializeObject<List<Student>>(content);
            _student = new ObservableCollection<Student>(student);
            base.OnAppearing();
        }

        async void OnSaveButtonClicked(object sender, System.EventArgs e)
        {
            var _newStudent = (Student)BindingContext;

            var student = new Student()
            {
                qa_users_name = _newStudent.qa_users_name,
                qa_users_pass = _newStudent.qa_users_email,
                qa_users_email = "app@appy.com",
                qa_users_score = 999
            };
            _student.Insert(0, student);
            var content = JsonConvert.SerializeObject(student);
            await _Client.PostAsync(url, new StringContent(content));
        }

        async void OnDeleteButtonClicked(object sender, System.EventArgs e)
        {
            var student = _student[0];
            _student.Remove(student);
            await _Client.DeleteAsync(url + "/" + student.qa_users_pk);
        }
    }
}
