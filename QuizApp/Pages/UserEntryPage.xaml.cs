using QuizApp.Models;
using QuizApp.RestManagers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace QuizApp.Pages
{
	public partial class UserEntryPage : ContentPage
    {
        ObservableCollection<User> _usersCollection;
        ObservableCollection<Class> _classesCollection;
        Dictionary<string, int> _usersPkAndName = new Dictionary<string, int>();
        Dictionary<string, int> _classesPkAndName = new Dictionary<string, int>();

        public UserEntryPage()
		{
			InitializeComponent();

        }

		protected override async void OnAppearing()
		{
			base.OnAppearing();

            var _users = new RestManagers.RestClientUser();
            var _classes = new RestManagers.RestClientClass();
            _usersCollection = new ObservableCollection<User>(await _users.RefreshDataAsync());
            _classesCollection = new ObservableCollection<Class>(await _classes.RefreshDataAsync());

            foreach (User _user in _usersCollection)
			{
				_usersPkAndName.Add(_user.qa_users_login, _user.qa_users_pk);
			}

            foreach (Class _class in _classesCollection)
            {
                _classesPkAndName.Add(_class.qa_class_title, _class.qa_class_pk);
            }

            UserPicker.Items.Add("New User");

            foreach (string _login in _usersPkAndName.Keys)
			{
                UserPicker.Items.Add(_login);
			}

            foreach (string _name in _classesPkAndName.Keys)
            {
                ClassPicker.Items.Add(_name);
            }
		}

        async void OnUserSelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedUserLogin;
            User selectedUser;

            selectedUserLogin = (string)UserPicker.SelectedItem;

            foreach(User _user in _usersCollection)
            {
                if (_user.qa_users_login == selectedUserLogin)
                {
                    selectedUser = _user;

                    PrimaryKey.Text = Convert.ToString(selectedUser.qa_users_pk);
                    ClassKey.Text = Convert.ToString(selectedUser.qa_users_class_key);
                    Name.Text = selectedUser.qa_users_name;
                    Login.Text = selectedUser.qa_users_login;
                    Password.Text = selectedUser.qa_users_pass;
                    Email.Text = selectedUser.qa_users_email;
                    Score.Text = Convert.ToString(selectedUser.qa_users_score);
                    AnswersCorrect.Text = Convert.ToString(selectedUser.qa_users_correct);
                    AnswersIncorrect.Text = Convert.ToString(selectedUser.qa_users_incorrect);
                    isAdmin.IsChecked = selectedUser.qa_users_isadmin;

                    break;
                }
            }

        }

        async void OnClassSelectedIndexChanged(object sender, EventArgs e)
        {
            string temp = (string)ClassPicker.SelectedItem;
            int key;

            _classesPkAndName.TryGetValue(temp, out key);

            ClassKey.Text = Convert.ToString(key);
        }

		async void OnSaveButtonClicked(object sender, EventArgs e)
		{
			var _newUser = new User();

            _newUser.qa_users_pk = Convert.ToInt32(string.Empty);
			_newUser.qa_users_class_key = Convert.ToInt32(ClassKey.Text);
			_newUser.qa_users_name = Name.Text;
			_newUser.qa_users_pass = Password.Text;
            _newUser.qa_users_login = Login.Text;
			_newUser.qa_users_email = Email.Text;
			_newUser.qa_users_score = Convert.ToInt32(Score.Text);
            _newUser.qa_users_correct = Convert.ToInt32(AnswersCorrect.Text);
            _newUser.qa_users_incorrect = Convert.ToInt32(AnswersIncorrect.Text);
            _newUser.qa_users_isadmin = isAdmin.IsChecked;

            if ((string)UserPicker.SelectedItem != "New User")
            {
                _newUser.qa_users_pk = Convert.ToInt32(PrimaryKey.Text);
            }

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
