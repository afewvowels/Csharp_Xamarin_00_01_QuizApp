﻿using Newtonsoft.Json;
using QuizApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using Xamarin.Forms;

namespace QuizApp
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		private const string url = "https://keithbsmith.me/tests/quizapp/api/students";
		private HttpClient _Client = new HttpClient();
		private ObservableCollection<User> _user;

		public MainPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			var content = await _Client.GetStringAsync(url);
			var user = JsonConvert.DeserializeObject<List<User>>(content);
			_user = new ObservableCollection<User>(user);
			Students_List.ItemsSource = _user;
			base.OnAppearing();
		}

		private async void OnAdd(object sender, System.EventArgs e)
		{
			var user = new User()
			{
				qa_users_name = "appName1",
				qa_users_pass = "appPassword",
				qa_users_email = "app@appy.com",
				qa_users_score = 999
			};
			_user.Insert(0, user);
			var content = JsonConvert.SerializeObject(user);
			await _Client.PostAsync(url, new StringContent(content));
		}

		private async void OnDelete(object sender, System.EventArgs e)
		{
			var user = _user[0];
			_user.Remove(user);
			await _Client.DeleteAsync(url + "/" + user.qa_users_pk);
		}
	}
}
