using FileServerRelational.WebApi.Models.Sbj;

namespace FileServerRelational.WebApi.Services.Abstract;

public interface ISubjectService
{
    IEnumerable<Subject> GetAllSubjects();
    Task<bool> AddSubject(Subject dto);
    Task<bool> RemoveSubject(string id);
    Task<bool> EditSubject(Subject dto);
}
