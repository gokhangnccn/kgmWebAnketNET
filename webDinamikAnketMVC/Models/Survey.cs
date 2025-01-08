using webDinamikAnketMVC.Models;
namespace webDinamikAnketMVC.Models
{
    public class Survey
    {
        public int SurveyID { get; set; }
        public string SurveyName { get; set; }
        public string ConductedBy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ExpectedParticipants { get; set; }
        public int AktifMi { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<SurveyParticipantField> SurveyParticipantFields { get; set; }
        public ICollection<SurveyParticipant> SurveyParticipants { get; set; }
    }

}
