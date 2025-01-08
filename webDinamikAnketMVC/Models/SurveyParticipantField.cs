namespace webDinamikAnketMVC.Models
{
    public class SurveyParticipantField
    {
        public int SurveyID { get; set; }
        public int FieldID { get; set; }

        public Survey Survey { get; set; }
        public ParticipantField Field { get; set; }
    }


}
