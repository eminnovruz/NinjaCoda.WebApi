using FileServerRelational.WebApi.ApplicationContext;
using FileServerRelational.WebApi.DataTransferObject.Requests;
using FileServerRelational.WebApi.DataTransferObject.Requests.Misc;
using FileServerRelational.WebApi.DataTransferObject.Responses;
using FileServerRelational.WebApi.Models.Misc;
using FileServerRelational.WebApi.Models.Sbj;
using FileServerRelational.WebApi.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileServerRelational.WebApi.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly AppDbContext _context;

        public QuestionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddQuestionToSubject(AddQuestionToSubjectRequest request)
        {
            Question newQuestion = new Question
            {
                Id = Guid.NewGuid().ToString(),
                Title = request.Title,
                Source = request.Source,
                QuestionDocsLink = request.QuestionDocsLink,
                CorrectAnswerCount = 0,
                AnswerIds = new List<string>(),
                SubjectId = request.SubjectId,
            };

            Subject flagSubject = await _context.Subjects
                .FirstOrDefaultAsync(sbj => sbj.Id == request.SubjectId);

            if (flagSubject == null)
            {
                return false;
            }

            flagSubject.QuestionIds.Add(newQuestion.Id);

            await _context.Questions.AddAsync(newQuestion);
            _context.Subjects.Update(flagSubject);

            int result = await _context.SaveChangesAsync();
            return result == 2; // 1 for Question, 1 for Subject
        }

        public IEnumerable<QuestionViewResponse> GetAllSubjectRelatedQuestions(string subjectId)
        {
            var questions = new List<QuestionViewResponse>();

            foreach (var item in _context.Questions.ToList())
            {
                if (item.SubjectId == subjectId)
                {
                    questions.Add(new QuestionViewResponse()
                    {
                        Id= item.Id,
                        Title = item.Title,
                        SubjectId = item.SubjectId,
                        AnswerIds = item.AnswerIds,
                        CorrectAnswerCount = item.CorrectAnswerCount,
                        QuestionDocsLink = item.QuestionDocsLink,
                        Source = item.Source,
                    });
                }
            }

            return questions;
        }
    }
}
