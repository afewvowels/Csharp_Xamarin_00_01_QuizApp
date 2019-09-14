using System;
namespace QuizApp.Models
{
    public class Question
    {
        public int qa_questions_pk { get; set; }
        public int qa_questions_class_key { get; set; }
        public int qa_questions_lesson_key { get; set; }
        public string qa_questions_question { get; set; }
        public string qa_questions_answer_1 { get; set; }
        public string qa_questions_answer_2 { get; set; }
        public string qa_questions_answer_3 { get; set; }
        public string qa_questions_answer_4 { get; set; }
        public string qa_questions_answer_5 { get; set; }
        public int qa_questions_correct { get; set; }
        public int qa_questions_incorrect { get; set; }
    }
}
