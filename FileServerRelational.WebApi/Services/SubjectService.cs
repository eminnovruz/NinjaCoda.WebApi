﻿using FileServerRelational.WebApi.ApplicationContext;
using FileServerRelational.WebApi.Models.Sbj;
using FileServerRelational.WebApi.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FileServerRelational.WebApi.Services;

public class SubjectService : ISubjectService
{
    AppDbContext _context;

    public SubjectService(AppDbContext context)
    {
        _context = context;
    }

    public Task<bool> AddSubject(Subject dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> EditSubject(Subject dto)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Subject> GetAllSubjects()
    {
        return _context.MainSubjects.ToList();
    }

    public Task<bool> RemoveSubject(string id)
    {
        throw new NotImplementedException();
    }
}
