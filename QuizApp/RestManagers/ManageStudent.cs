using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.Models;

namespace QuizApp.RestManagers
{
    public class ManageStudent
    {
        IRestServiceStudent restService;

        public ManageStudent(IRestServiceStudent service)
        {
            restService = service;
        }

        public Task<List<Student>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync (Student student, bool isNewItem = false)
        {
            return restService.SaveStudentInfoAsync(student, isNewItem);
        }

        public Task DeleteTaskAsync (Student student)
        {
            return restService.DeleteStudentInfoAsync(student.qa_users_pk);
        }
    }
}
