namespace webDinamikAnketMVC.Models
{
    public class SurveyParticipant
    {
        public int ParticipantID { get; set; }
        public int SurveyID { get; set; }

        public Survey Survey { get; set; }
    }


}
