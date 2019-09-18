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
    public partial class UserEntryPage : ContentPage
    {
        public UserEntryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var _newUser = new User();

            _newUser.qa_users_name = Name.Text;
            _newUser.qa_users_pass = Password.Text;
            _newUser.qa_users_email = Email.Text;
            _newUser.qa_users_score = Convert.ToInt32(Score.Text);

            var _restClient = new RestClientUser();

            await _restClient.SaveUserInfoAsync(_newUser, true);

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
