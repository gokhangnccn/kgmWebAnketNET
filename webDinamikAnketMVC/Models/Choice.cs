namespace webDinamikAnketMVC.Models
{
    public class Choice
    {
        public int ChoiceID { get; set; }
        public int QuestionID { get; set; }
        public string ChoiceText { get; set; }

        public Question Question { get; set; }
    }

}
