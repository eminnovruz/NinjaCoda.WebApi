using FileServerRelational.WebApi.DataTransferObject.Requests;
using FileServerRelational.WebApi.DataTransferObject.Requests.Misc;

namespace FileServerRelational.WebApi.Services.Abstract;

public interface IQuestionService
{
    Task<bool> AddQuestionToSubject(AddQuestionToSubjectRequest request);
    IEnumerable<QuestionViewResponse> GetAllSubjectRelatedQuestions(string subjectId);
    IEnumerable<QuestionViewResponse> GetAllQuestions();
    Task<bool> RemoveQuestion(string questionId);
    IEnumerable<QuestionViewResponse> GetAllLevelRelatedQuestions(string level);
}
