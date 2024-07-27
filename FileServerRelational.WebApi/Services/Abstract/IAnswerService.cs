using FileServerRelational.WebApi.DataTransferObject.Requests;
using FileServerRelational.WebApi.DataTransferObject.Responses;

namespace FileServerRelational.WebApi.Services.Abstract;

public interface IAnswerService
{
    IEnumerable<ViewAnswerResponse> GetAllAnswers();
    IEnumerable<ViewAnswerResponse> GetQuestionRelatedAnswers(string questionId);
    Task<bool> RemoveAnswer(string answerId);
    Task<bool> AddAnswerToQuestion(AddAnswerToQuestionRequest request);
}
