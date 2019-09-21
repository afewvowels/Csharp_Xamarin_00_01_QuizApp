using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.Models;

namespace QuizApp.RestManagers
{
    public interface IRestServiceClass
    {
        Task<List<Class>> RefreshDataAsync();
        Task SaveClassInfoAsync(Class classObj, bool isNewItem);
        Task DeleteClassInfoAsync(int pk);
    }
}