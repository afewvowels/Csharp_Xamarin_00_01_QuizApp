using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.Models;

namespace QuizApp.RestManagers
{
    public interface IRestServiceUser
    {
        Task<List<User>> RefreshDataAsync();
        Task SaveUserInfoAsync(User user, bool isNewItem);
        Task DeleteUserInfoAsync(int pk);
    }
}