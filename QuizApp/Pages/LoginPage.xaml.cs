using QuizApp.Models;
using System;
using System.Collections.ObjectModel;
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
			var _restClient = new RestManagers.RestClientUser();
			ObservableCollection<User> _users = new ObservableCollection<User>(await _restClient.RefreshDataAsync());

			var _user = new User();

			_user.qa_users_name = UserName.Text;
			_user.qa_users_pass = UserPassword.Text;

			bool _isFound = false;

			foreach (User user in _users)
			{
				if (_user.qa_users_name == user.qa_users_name &&
						_user.qa_users_pass == user.qa_users_pass)
				{
					_isFound = true;
					break;
				}
			}
		}

		async void OnBackButtonClicked(object sender, EventArgs e)
		{

		}
	}
}
