using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using QuizApp.Models;

using Xamarin.Forms;

namespace QuizApp.Pages
{
    public partial class UsersDetailsPage : ContentPage
    {

        public UsersDetailsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var _users = new RestManagers.RestClientUser();

            UsersDetailsList.ItemsSource = await _users.RefreshDataAsync();
        }

        async void OnAddStudentClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserEntryPage());
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }
    }
}
