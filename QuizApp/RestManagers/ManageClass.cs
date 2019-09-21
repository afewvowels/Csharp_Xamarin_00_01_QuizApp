using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.Models;

namespace QuizApp.RestManagers
{
    public class ManageClass
    {
        IRestServiceClass restService;

        public ManageClass(IRestServiceClass service)
        {
            restService = service;
        }

        public Task<List<Class>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync (Class classObj, bool isNewItem = false)
        {
            return restService.SaveClassInfoAsync(classObj, isNewItem);
        }

        public Task DeleteTaskAsync (Class classObj)
        {
            return restService.DeleteClassInfoAsync(classObj.qa_class_pk);
        }
    }
}