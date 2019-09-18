using System;
using System.Collections.Generic;
using QuizApp.Models;

using Xamarin.Forms;

namespace QuizApp.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            List<User> _users = new RestManagers.RestClientUser().RefreshDataAsync().Wait;

            var _user = new User();

            _user.qa_users_name = UserName.Text;
            _user.qa_users_pass = UserPassword.Text;

            bool _isFound = false;

            foreach(User user in _users)
            {
                if (_user.qa_users_name == user.qa_users_name &&
                    _user.qa_users_pass == user.qa_users_pass)
                {
                    _isFound = true;
                    break;
                }
            }


        }
    }
}
