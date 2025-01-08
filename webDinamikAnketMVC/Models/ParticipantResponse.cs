namespace webDinamikAnketMVC.Models
{
    public class ParticipantResponse
    {
        public int ParticipantResponseID { get; set; }
        public int ParticipantID { get; set; }
        public int SurveyID { get; set; } 

        public int FieldID { get; set; }
        public string ResponseText { get; set; }

        public SurveyParticipant Participant { get; set; }
        public ParticipantField Field { get; set; }
    }




}
