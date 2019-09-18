using System;
namespace QuizApp.Models
{
    public class User
    {
        public int qa_users_pk { get; set; }
        public int qa_users_class_key { get; set; }
        public string qa_users_name { get; set; }
        public string qa_users_login { get; set; }
        public string qa_users_pass { get; set; }
        public string qa_users_email { get; set; }
        public int qa_users_score { get; set; }
        public int qa_users_correct { get; set; }
        public int qa_users_incorrect { get; set; }
        public bool qa_users_isadmin { get; set; }
    }
}
