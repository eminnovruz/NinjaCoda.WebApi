using FileServerRelational.WebApi.ApplicationContext;
using FileServerRelational.WebApi.DataTransferObject.Requests;
using FileServerRelational.WebApi.DataTransferObject.Requests.Misc;
using FileServerRelational.WebApi.DataTransferObject.Responses;
using FileServerRelational.WebApi.Models.Misc;
using FileServerRelational.WebApi.Models.Sbj;
using FileServerRelational.WebApi.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FileServerRelational.WebApi.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnswerService"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public AnswerService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new answer to a question.
        /// </summary>
        /// <param name="request">The request containing answer details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
        public async Task<bool> AddAnswerToQuestion(AddAnswerToQuestionRequest request)
        {
            var newAnswer = new Answer
            {
                Id = Guid.NewGuid().ToString(),
                QuestionId = request.QuestionId,
                Text = request.Text,
            };

            var flagQuestion = await _context.Questions
                .FirstOrDefaultAsync(sbj => sbj.Id == request.QuestionId);

            if (flagQuestion == null)
            {
                return false;
            }

            flagQuestion.AnswerIds.Add(newAnswer.Id);

            await _context.Answers.AddAsync(newAnswer);
            _context.Questions.Update(flagQuestion);

            var result = await _context.SaveChangesAsync();
            return result == 2; // 1 for Question, 1 for Answer
        }

        /// <summary>
        /// Gets all answers.
        /// </summary>
        /// <returns>An enumerable collection of answer responses.</returns>
        public IEnumerable<ViewAnswerResponse> GetAllAnswers()
        {
            return _context.Answers.Select(x => new ViewAnswerResponse
            {
                Id = x.Id,
                QuestionId = x.QuestionId,
                Text = x.Text,
            }).ToList();
        }

        /// <summary>
        /// Gets answers related to a specific question.
        /// </summary>
        /// <param name="questionId">The ID of the question.</param>
        /// <returns>An enumerable collection of answer responses.</returns>
        public IEnumerable<ViewAnswerResponse> GetQuestionRelatedAnswers(string questionId)
        {
            return _context.Answers
                .Where(x => x.QuestionId == questionId)
                .Select(x => new ViewAnswerResponse
                {
                    Id = x.Id,
                    QuestionId = x.QuestionId,
                    Text = x.Text,
                }).ToList();
        }

        /// <summary>
        /// Removes an answer.
        /// </summary>
        /// <param name="answerId">The ID of the answer to remove.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
        public async Task<bool> RemoveAnswer(string answerId)
        {
            var answer = await _context.Answers
                .FirstOrDefaultAsync(x => x.Id == answerId);

            if (answer == null)
            {
                return false;
            }

            var question = await _context.Questions
                .FirstOrDefaultAsync(x => x.Id == answer.QuestionId);

            if (question == null)
            {
                return false;
            }

            question.AnswerIds.Remove(answer.Id);
            _context.Answers.Remove(answer);
            _context.Questions.Update(question);

            var result = await _context.SaveChangesAsync();
            return result == 1;
        }
    }
}
