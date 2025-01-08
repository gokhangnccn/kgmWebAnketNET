using System.ComponentModel.DataAnnotations;

namespace webDinamikAnketMVC.Models
{
    public class SurveyResponse
    {
        public int ResponseID { get; set; } // Primary Key
        public int SurveyID { get; set; }  // Foreign Key
        public int ParticipantID { get; set; } // Foreign Key
        public int QuestionID { get; set; }
        public int? ChoiceID { get; set; }
        public string ResponseText { get; set; }

        // Navigasyon özellikleri
        public Survey Survey { get; set; }
        public SurveyParticipant Participant { get; set; }
        public Question Question { get; set; }
        public Choice Choice { get; set; }
    }



}
