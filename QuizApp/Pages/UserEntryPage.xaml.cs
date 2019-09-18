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
		public UserEntryPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			var _users = new RestManagers.RestClientUser();
			ObservableCollection<User> _usersCollection = new ObservableCollection<User>(await _users.RefreshDataAsync());
			Dictionary<int, string> _usersPkAndName = new Dictionary<int, string>();

			foreach (User _user in _usersCollection)
			{
				_usersPkAndName.Add(_user.qa_users_pk, _user.qa_users_name);
			}

			foreach (string _name in _usersPkAndName.Values)
			{
				UserPicker.Items.Add(_name);
			}
		}

		async void OnSaveButtonClicked(object sender, EventArgs e)
		{
			var _newUser = new User();

			if (UserPicker.SelectedIndex != 0)
			{
			}
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
