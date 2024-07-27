﻿using FileServerRelational.WebApi.ApplicationContext;
using FileServerRelational.WebApi.DataTransferObject.Requests;
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

    public async Task<bool> AddSubject(AddSubjectRequest dto)
    {
        var newSubject = new Subject()
        {
            Id = Guid.NewGuid().ToString(),
            Title = dto.Title,
            Description = dto.Description,
            GeneralAbout = dto.GeneralAbout,
            DocsLink = dto.DocsLink,
            QuestionIds = new List<string>(),
            SalaryId = "555"
        };

        EntityEntry<Subject> actionResult = await _context.Subjects.AddAsync(newSubject);
        await _context.SaveChangesAsync();

        return actionResult.State == EntityState.Added;
    }

    public Task<bool> EditSubject(Subject dto)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Subject> GetAllSubjects()
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveSubject(string id)
    {
        throw new NotImplementedException();
    }
}
