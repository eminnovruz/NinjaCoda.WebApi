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

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionService"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public QuestionService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all questions.
        /// </summary>
        /// <returns>An enumerable collection of question view responses.</returns>
        public IEnumerable<QuestionViewResponse> GetAllQuestions()
        {
            return _context.Questions.Select(x => new QuestionViewResponse
            {
                Source = x.Source,
                SubjectId = x.SubjectId,
                AnswerIds = x.AnswerIds,
                CorrectAnswerCount = x.CorrectAnswerCount,
                Id = x.Id,
                QuestionDocsLink = x.QuestionDocsLink,
                Title = x.Title,
                Level = x.QuestionLevel
            }).ToList();
        }

        /// <summary>
        /// Adds a new question to a subject.
        /// </summary>
        /// <param name="request">The request containing question details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
        public async Task<bool> AddQuestionToSubject(AddQuestionToSubjectRequest request)
        {
            var newQuestion = new Question
            {
                Id = Guid.NewGuid().ToString(),
                QuestionLevel = request.QuestionLevel,
                Title = request.Title,
                Source = request.Source,
                QuestionDocsLink = request.QuestionDocsLink,
                CorrectAnswerCount = 0,
                AnswerIds = new List<string>(),
                SubjectId = request.SubjectId,
            };

            var flagSubject = await _context.Subjects
                .FirstOrDefaultAsync(sbj => sbj.Id == request.SubjectId);

            if (flagSubject == null)
            {
                return false;
            }

            flagSubject.QuestionIds.Add(newQuestion.Id);

            await _context.Questions.AddAsync(newQuestion);
            _context.Subjects.Update(flagSubject);

            var result = await _context.SaveChangesAsync();
            return result == 2; // 1 for Question, 1 for Subject
        }

        /// <summary>
        /// Gets all questions related to a specific subject.
        /// </summary>
        /// <param name="subjectId">The ID of the subject.</param>
        /// <returns>An enumerable collection of question view responses.</returns>
        public IEnumerable<QuestionViewResponse> GetAllSubjectRelatedQuestions(string subjectId)
        {
            return _context.Questions
                .Where(x => x.SubjectId == subjectId)
                .Select(x => new QuestionViewResponse
                {
                    Id = x.Id,
                    Title = x.Title,
                    SubjectId = x.SubjectId,
                    AnswerIds = x.AnswerIds,
                    CorrectAnswerCount = x.CorrectAnswerCount,
                    QuestionDocsLink = x.QuestionDocsLink,
                    Source = x.Source,
                    Level = x.QuestionLevel,
                }).ToList();
        }

        /// <summary>
        /// Removes a question.
        /// </summary>
        /// <param name="questionId">The ID of the question to remove.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
        public async Task<bool> RemoveQuestion(string questionId)
        {
            var question = await _context.Questions
                .FirstOrDefaultAsync(x => x.Id == questionId);

            if (question == null)
            {
                return false;
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(x => x.Id == question.SubjectId);

            if (subject == null)
            {
                return false;
            }

            subject.QuestionIds.Remove(question.Id);
            _context.Questions.Remove(question);
            _context.Subjects.Update(subject);

            var result = await _context.SaveChangesAsync();
            return result == 1;
        }

        public IEnumerable<QuestionViewResponse> GetAllLevelRelatedQuestions(string level)
        {
            return _context.Questions.Where(question => question.QuestionLevel == level).Select(question => new QuestionViewResponse()
            {
                Source = question.Source,
                SubjectId = question.SubjectId,
                AnswerIds = question.AnswerIds,
                CorrectAnswerCount = question.CorrectAnswerCount,
                Id = question.Id,
                QuestionDocsLink = question.QuestionDocsLink,
                Title = question.Title,
            });
        }
    }
}
