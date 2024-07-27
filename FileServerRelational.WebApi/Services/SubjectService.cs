using FileServerRelational.WebApi.ApplicationContext;
using FileServerRelational.WebApi.DataTransferObject.Requests;
using FileServerRelational.WebApi.DataTransferObject.Responses;
using FileServerRelational.WebApi.Models.Sbj;
using FileServerRelational.WebApi.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileServerRelational.WebApi.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubjectService"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public SubjectService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new subject asynchronously.
        /// </summary>
        /// <param name="dto">The request containing subject details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
        public async Task<bool> AddSubjectAsync(AddSubjectRequest dto)
        {
            var newSubject = new Subject
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

            return actionResult.State == EntityState.Added; // Ensure the entity is added successfully
        }

        /// <summary>
        /// Edits an existing subject.
        /// </summary>
        /// <param name="dto">The subject details to edit.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
        public Task<bool> EditSubject(Subject dto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all subjects.
        /// </summary>
        /// <returns>An enumerable collection of subject view responses.</returns>
        public IEnumerable<ViewSubjectResponse> GetAllSubjects()
        {
            return _context.Subjects.Select(sbj => new ViewSubjectResponse
            {
                Description = sbj.Description,
                Id = sbj.Id,
                SalaryId = sbj.SalaryId,
                DocsLink = sbj.DocsLink,
                GeneralAbout = sbj.GeneralAbout,
                QuestionIds = sbj.QuestionIds,
                Title = sbj.Title,
            }).ToList();
        }

        /// <summary>
        /// Removes a subject asynchronously.
        /// </summary>
        /// <param name="id">The ID of the subject to remove.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
        public async Task<bool> RemoveSubjectAsync(string id)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(sbj => sbj.Id == id);
            if (subject == null)
            {
                return false;
            }

            var relatedQuestions = _context.Questions.Where(q => q.SubjectId == id).ToList();
            _context.Questions.RemoveRange(relatedQuestions);
            _context.Subjects.Remove(subject);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == relatedQuestions.Count + 1;
        }
    }
}
