using FileServerRelational.WebApi.ApplicationContext;
using FileServerRelational.WebApi.DataTransferObject.Requests;
using FileServerRelational.WebApi.DataTransferObject.Responses;
using FileServerRelational.WebApi.Models.Sbj;
using FileServerRelational.WebApi.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FileServerRelational.WebApi.Services;

public class SubjectService : ISubjectService
{
    AppDbContext _context;

    public SubjectService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddSubjectAsync(AddSubjectRequest dto)
    {
        var newSubject = new Subject()
        {
            Id = Guid.NewGuid().ToString(),
            Title = dto.Title,
            Description = dto.Description,
            GeneralAbout = dto.GeneralAbout,
            DocsLink = dto.DocsLink,
            QuestionIds = new List<string>(),
            SalaryId = "key_undefined"
        };

        EntityEntry<Subject> actionResult = await _context.Subjects.AddAsync(newSubject);
        await _context.SaveChangesAsync();

        return actionResult.State == EntityState.Unchanged; // should be changed , can be uncorrect 
    }

    public Task<bool> EditSubject(Subject dto)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ViewSubjectResponse> GetAllSubjects()
    {
        List<Subject> subjects = _context.Subjects.ToList();

        return subjects.Select(sbj => new ViewSubjectResponse()
        {
            Description = sbj.Description,
            Id = sbj.Id,
            SalaryId = sbj.SalaryId,
            DocsLink = sbj.DocsLink,
            GeneralAbout = sbj.GeneralAbout,
            QuestionIds = sbj.QuestionIds,
            Title = sbj.Title,
        });
    }

    public async Task<bool> RemoveSubjectAsync(string id)
    {
        Subject delSubject = _context.Subjects.FirstOrDefault(sbj => sbj.Id == id);
        EntityEntry<Subject> result = _context.Subjects.Remove(delSubject);
        await _context.SaveChangesAsync();
        return result.State == EntityState.Deleted;
    }
}
