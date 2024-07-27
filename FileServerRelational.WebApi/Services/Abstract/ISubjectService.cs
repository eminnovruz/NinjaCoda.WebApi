using FileServerRelational.WebApi.DataTransferObject.Requests;
using FileServerRelational.WebApi.DataTransferObject.Responses;
using FileServerRelational.WebApi.Models.Sbj;

namespace FileServerRelational.WebApi.Services.Abstract;

public interface ISubjectService
{
    IEnumerable<ViewSubjectResponse> GetAllSubjects();
    Task<bool> AddSubjectAsync(AddSubjectRequest dto);
    Task<bool> RemoveSubjectAsync(string id);
    Task<bool> EditSubject(Subject dto);
}
