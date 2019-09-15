using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.Models;

namespace QuizApp.RestManagers
{
    public interface IRestServiceStudent
    {
        Task<List<Student>> RefreshDataAsync();
        Task SaveStudentInfoAsync(Student student, bool isNewItem);
        Task DeleteStudentInfoAsync(int pk);
    }
}