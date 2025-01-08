namespace webDinamikAnketMVC.Models
{
    public class FieldOption
    {
        public int FieldOptionID { get; set; }
        public int FieldID { get; set; }
        public string OptionText { get; set; }

        public ParticipantField ParticipantField { get; set; }
    }



}
