using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webDinamikAnketMVC.Data;
using webDinamikAnketMVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace webDinamikAnketMVC.Controllers
{
    public class SurveysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SurveysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Aktif Anketleri Listele
        public async Task<IActionResult> Index()
        {
            var surveys = await _context.Surveys
                .Include(s => s.Questions)
                .ThenInclude(q => q.Choices)
                .Where(s => s.AktifMi == 1) // int değer kontrolü
                .ToListAsync();
            return View(surveys);
        }

        public async Task<IActionResult> SilinmisAnketler()
        {
            var surveys = await _context.Surveys
                .Include(s => s.Questions)
                .ThenInclude(q => q.Choices)
                .Where(s => s.AktifMi == 0) // int değer kontrolü
                .ToListAsync();
            return View(surveys);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var survey = await _context.Surveys.FindAsync(id);
            if (survey != null)
            {
                if (survey.AktifMi == 1)
                {
                    survey.AktifMi = 0;
                    _context.Surveys.Update(survey);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction(nameof(SilinmisAnketler));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Survey survey)
        {
            if (ModelState.IsValid)
            {
                // Soruların Survey ile ilişkilendirilmesi
                if (survey.Questions != null && survey.Questions.Any())
                {
                    foreach (var question in survey.Questions)
                    {
                        // SurveyID'nin atanması
                        question.SurveyID = survey.SurveyID;

                        if (question.Choices != null && question.Choices.Any())
                        {
                            foreach (var choice in question.Choices)
                            {
                                // Seçeneklerin ilgili soru ile ilişkilendirilmesi
                                choice.QuestionID = question.QuestionID;
                            }
                        }
                    }
                }

                // Survey'in veritabanına eklenmesi
                _context.Surveys.Add(survey);

                // Değişikliklerin veritabanına kaydedilmesi
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // Model doğrulama hatalarını göstermek için view'e geri dön
            return View(survey);
        }




        public async Task<IActionResult> Details(int id)
        {
            // Retrieve the survey with the specified ID, including its related questions and choices
            var survey = await _context.Surveys
                .Include(s => s.Questions)
                .ThenInclude(q => q.Choices)
                .FirstOrDefaultAsync(s => s.SurveyID == id && s.AktifMi == 1);

            if (survey == null)
            {
                return NotFound(); // Return 404 if the survey is not found or not active
            }

            return View(survey); // Pass the survey to the view
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YenidenAktiflestir(int id)
        {
            var survey = await _context.Surveys.FindAsync(id);
            if (survey != null && survey.AktifMi == 0) // int değer kontrolü
            {
                survey.AktifMi = 1; // Yeniden aktifleştir
                _context.Surveys.Update(survey);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(SilinmisAnketler));
        }

    }
}
