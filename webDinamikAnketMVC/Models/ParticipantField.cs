using System.ComponentModel.DataAnnotations;

namespace webDinamikAnketMVC.Models
{
    public class ParticipantField
    {
        public int FieldID { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }

        public ICollection<FieldOption> FieldOptions { get; set; }
        public ICollection<ParticipantResponse> ParticipantResponses { get; set; }
        public ICollection<SurveyParticipantField> SurveyParticipantFields { get; set; }
    }



}
