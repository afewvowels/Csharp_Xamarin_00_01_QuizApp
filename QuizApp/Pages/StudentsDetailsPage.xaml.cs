using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using QuizApp.Models;

using Xamarin.Forms;

namespace QuizApp.Pages
{
    public partial class StudentsDetailsPage : ContentPage
    {

        public StudentsDetailsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var _students = new RestManagers.RestClientStudent();

            ListView.ItemsSource = await _students.RefreshDataAsync();
        }

        async void OnAddStudentClicked(object sender, EventArgs e)
        {
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }
    }
}
