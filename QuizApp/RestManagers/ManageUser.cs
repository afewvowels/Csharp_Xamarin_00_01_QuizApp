using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.Models;

namespace QuizApp.RestManagers
{
    public class ManageUser
    {
        IRestServiceUser restService;

        public ManageUser(IRestServiceUser service)
        {
            restService = service;
        }

        public Task<List<User>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync (User user, bool isNewItem = false)
        {
            return restService.SaveUserInfoAsync(user, isNewItem);
        }

        public Task DeleteTaskAsync (User user)
        {
            return restService.DeleteUserInfoAsync(user.qa_users_pk);
        }
    }
}
