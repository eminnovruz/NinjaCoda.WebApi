using FileServerRelational.WebApi.DataTransferObject.Requests;
using FileServerRelational.WebApi.DataTransferObject.Requests.Misc;

namespace FileServerRelational.WebApi.Services.Abstract;

public interface IQuestionService
{
    Task<bool> AddQuestionToSubject(AddQuestionToSubjectRequest request);
    Task<IEnumerable<QuestionViewResponse>> GetAllSubjectRelatedQuestions(string subjectId);
}
