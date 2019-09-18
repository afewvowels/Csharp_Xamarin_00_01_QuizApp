using Newtonsoft.Json;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.RestManagers
{
	public class RestClientUser : IRestServiceUser
	{
		HttpClient _client;

		public List<User> Users { get; set; }

		public RestClientUser()
		{
			_client = new HttpClient();
		}

		public async Task<ObservableCollection<User>> RefreshDataAsync()
		{
			Users = new List<User>();
			ObservableCollection<User> UsersData = new ObservableCollection<User>(Users);

			var uri = new Uri(string.Format(Constants.UserAddress, string.Empty));
			try
			{
				var response = await _client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					Users = JsonConvert.DeserializeObject<List<User>>(content);
					UsersData = new ObservableCollection<User>(Users);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"\tERROR {0}", ex.Message);
			}

			return UsersData;
		}

		public async Task SaveUserInfoAsync(User user, bool isNewItem = false)
		{
			var uri = new Uri(string.Format(Constants.UserAddress, string.Empty));

			try
			{
				var json = JsonConvert.SerializeObject(user);

				HttpResponseMessage response = null;
				if (isNewItem)
				{
					//var temp = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(json);
					//temp.Property("qa_user_pk").Remove();
					//json = JsonConvert.SerializeObject(temp);
					var content = new StringContent(json, Encoding.UTF8, "application/json");
					//response = await _client.PostAsync(uri, content);
					response = await _client.PostAsync(uri, content);
				}
				else
				{
					var content = new StringContent(json, Encoding.UTF8, "application/json");
					response = await _client.PutAsync(uri, content);
				}

				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine(@"\tUser successfully saved");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"\tERROR {0}", ex.Message);
			}
		}

		public async Task DeleteUserInfoAsync(int pk)
		{
			var uri = new Uri(string.Format(Constants.UserAddress, string.Empty));

			try
			{
				var response = await _client.DeleteAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine(@"\tUser successfully deleted");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"\tERROR {0}", ex.Message);
			}
		}

		Task<List<User>> IRestServiceUser.RefreshDataAsync()
		{
			throw new NotImplementedException();
		}
	}
}
