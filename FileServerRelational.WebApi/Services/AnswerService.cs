using FileServerRelational.WebApi.ApplicationContext;
using FileServerRelational.WebApi.DataTransferObject.Requests;
using FileServerRelational.WebApi.DataTransferObject.Requests.Misc;
using FileServerRelational.WebApi.DataTransferObject.Responses;
using FileServerRelational.WebApi.Models.Misc;
using FileServerRelational.WebApi.Models.Sbj;
using FileServerRelational.WebApi.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FileServerRelational.WebApi.Services;

public class AnswerService : IAnswerService
{
    private readonly AppDbContext _context;

    public AnswerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAnswerToQuestion(AddAnswerToQuestionRequest request)
    {
        Answer newAnswer = new Answer
        {
            Id = Guid.NewGuid().ToString(),
            QuestionId = request.QuestionId,
            Text = request.Text,
        };

        Question flagQuestion = await _context.Questions
            .FirstOrDefaultAsync(sbj => sbj.Id == request.QuestionId);

        if (flagQuestion == null)
        {
            return false;
        }

        flagQuestion.AnswerIds.Add(newAnswer.Id);

        await _context.Answers.AddAsync(newAnswer);
        _context.Questions.Update(flagQuestion);

        int result = await _context.SaveChangesAsync();
        return result == 2; // 1 for Question, 1 for Subject
    }

    public IEnumerable<ViewAnswerResponse> GetAllAnswers()
    {
        return _context.Answers.Select(x => new ViewAnswerResponse
        {
            Id = x.Id,
            QuestionId = x.QuestionId,
            Text = x.Text,
        });
    }

    public IEnumerable<ViewAnswerResponse> GetQuestionRelatedAnswers(string questionId)
    {
        var answers = new List<ViewAnswerResponse>();

        foreach (var item in _context.Answers.ToList())
        {
            if (item.QuestionId == questionId)
            {
                answers.Add(new ViewAnswerResponse()
                {
                    Id = item.Id,
                    QuestionId = item.QuestionId,
                    Text = item.Text,
                });
            }
        }

        return answers;
    }

    public async Task<bool> RemoveAnswer(string answerId)
    {
        var answer = _context.Answers.FirstOrDefault(x => x.Id == answerId);

        var question = _context.Questions.FirstOrDefault(x => x.Id == answer.QuestionId);

        question.AnswerIds.Remove(answer.Id);

        _context.Answers.Remove(answer);

        _context.Update(question);

        var result = await _context.SaveChangesAsync();
        return result == 1;
    }
}
