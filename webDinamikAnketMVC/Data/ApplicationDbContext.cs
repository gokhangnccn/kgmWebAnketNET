using Microsoft.EntityFrameworkCore;
using webDinamikAnketMVC.Models;

namespace webDinamikAnketMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<SurveyParticipant> SurveyParticipants { get; set; }
        public DbSet<SurveyResponse> SurveyResponses { get; set; }
        public DbSet<ParticipantField> ParticipantFields { get; set; }
        public DbSet<ParticipantResponse> ParticipantResponses { get; set; }
        public DbSet<FieldOption> FieldOptions { get; set; }
        public DbSet<SurveyParticipantField> SurveyParticipantFields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Survey - Question
            modelBuilder.Entity<Survey>()
                .HasMany(s => s.Questions)
                .WithOne(q => q.Survey)
                .HasForeignKey(q => q.SurveyID);

            // Question - Choice
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Choices)
                .WithOne(c => c.Question)
                .HasForeignKey(c => c.QuestionID);

            modelBuilder.Entity<SurveyParticipant>()
                .HasKey(sp => new { sp.ParticipantID, sp.SurveyID }); // Composite key tanımı


            // SurveyParticipantField - Composite Key
            modelBuilder.Entity<SurveyParticipantField>()
                .HasKey(spf => new { spf.SurveyID, spf.FieldID });

            modelBuilder.Entity<SurveyParticipantField>()
                .HasOne(spf => spf.Survey)
                .WithMany(s => s.SurveyParticipantFields)
                .HasForeignKey(spf => spf.SurveyID);

            modelBuilder.Entity<SurveyParticipantField>()
                .HasOne(spf => spf.Field)
                .WithMany(pf => pf.SurveyParticipantFields)
                .HasForeignKey(spf => spf.FieldID);

            modelBuilder.Entity<ParticipantResponse>()
                .HasOne(pr => pr.Participant)
                .WithMany()
                .HasForeignKey(pr => new { pr.ParticipantID, pr.SurveyID }) // Composite foreign key tanımlanıyor
                .HasPrincipalKey(sp => new { sp.ParticipantID, sp.SurveyID }); // SurveyParticipant bileşik anahtar


            modelBuilder.Entity<ParticipantResponse>()
                .HasOne(pr => pr.Field)
                .WithMany(pf => pf.ParticipantResponses)
                .HasForeignKey(pr => pr.FieldID);

            // FieldOption
            modelBuilder.Entity<FieldOption>()
                .HasOne(fo => fo.ParticipantField)
                .WithMany(pf => pf.FieldOptions)
                .HasForeignKey(fo => fo.FieldID);

            // SurveyResponse
            modelBuilder.Entity<SurveyResponse>()
                .HasOne(sr => sr.Survey)
                .WithMany()
                .HasForeignKey(sr => sr.SurveyID);

            modelBuilder.Entity<SurveyResponse>()
                .HasOne(sr => sr.Participant)
                .WithMany()
                .HasForeignKey(sr => new { sr.ParticipantID, sr.SurveyID }) // Composite foreign key tanımlanıyor
                .HasPrincipalKey(sp => new { sp.ParticipantID, sp.SurveyID }); // SurveyParticipant bileşik anahtar


            modelBuilder.Entity<SurveyResponse>()
                .HasOne(sr => sr.Question)
                .WithMany()
                .HasForeignKey(sr => sr.QuestionID);

            modelBuilder.Entity<SurveyResponse>()
                .HasOne(sr => sr.Choice)
                .WithMany()
                .HasForeignKey(sr => sr.ChoiceID);

            modelBuilder.Entity<ParticipantField>()
                .HasKey(pf => pf.FieldID); // FieldID'yi birincil anahtar olarak tanımlar

            modelBuilder.Entity<SurveyResponse>()
                .HasKey(sr => sr.ResponseID); // ResponseID'yi birincil anahtar yap


        }
    }
}
