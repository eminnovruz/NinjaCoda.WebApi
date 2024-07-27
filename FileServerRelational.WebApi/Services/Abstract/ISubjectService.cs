using FileServerRelational.WebApi.DataTransferObject.Requests;
using FileServerRelational.WebApi.Models.Sbj;

namespace FileServerRelational.WebApi.Services.Abstract;

public interface ISubjectService
{
    IEnumerable<Subject> GetAllSubjects();
    Task<bool> AddSubject(AddSubjectRequest dto);
    Task<bool> RemoveSubject(string id);
    Task<bool> EditSubject(Subject dto);
}
