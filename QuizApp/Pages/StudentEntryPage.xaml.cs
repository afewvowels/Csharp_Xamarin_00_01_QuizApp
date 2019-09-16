using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using QuizApp.Models;
using QuizApp.RestManagers;

using Xamarin.Forms;
using System.Diagnostics;
using System.Text;

namespace QuizApp.Pages
{
    public partial class StudentEntryPage : ContentPage
    {

        public StudentEntryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var _newStudent = new Student;
            _newStudent = (Student)BindingContext;
            var _restClient = new RestClientStudent();
            await _restClient.SaveStudentInfoAsync(_newStudent, true);
            Debug.WriteLine(_newStudent.qa_users_name);
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
