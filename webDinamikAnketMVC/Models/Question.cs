using webDinamikAnketMVC.Models;

namespace webDinamikAnketMVC.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public int SurveyID { get; set; }
        public string QuestionText { get; set; }
        public string AnswerType { get; set; }

        public Survey Survey { get; set; }
        public ICollection<Choice> Choices { get; set; }
    }

}
