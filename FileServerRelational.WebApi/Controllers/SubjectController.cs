using FileServerRelational.WebApi.DataTransferObject.Requests;
using FileServerRelational.WebApi.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FileServerRelational.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubjectController"/> class.
        /// </summary>
        /// <param name="subjectService">The subject service.</param>
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        /// <summary>
        /// Adds a new subject.
        /// </summary>
        /// <param name="request">The request containing subject details.</param>
        /// <returns>An action result indicating success or failure.</returns>
        [HttpPost("AddNewSubject")]
        public async Task<IActionResult> AddNewSubjectAsync(AddSubjectRequest request)
        {
            try
            {
                var result = await _subjectService.AddSubjectAsync(request);
                return Ok(result);
            }
            catch (Exception exception)
            {
                // Log the exception (not shown here for brevity)
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Retrieves all subjects.
        /// </summary>
        /// <returns>An action result containing a list of all subjects.</returns>
        [HttpGet("GetAllSubjects")]
        public IActionResult GetAllSubjects()
        {
            try
            {
                var subjects = _subjectService.GetAllSubjects();
                return Ok(subjects);
            }
            catch (Exception exception)
            {
                // Log the exception (not shown here for brevity)
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Removes a subject by ID.
        /// </summary>
        /// <param name="subjectId">The ID of the subject to remove.</param>
        /// <returns>An action result indicating success or failure.</returns>
        [HttpDelete("RemoveSubjectById")]
        public async Task<IActionResult> RemoveSubjectByIdAsync(string subjectId)
        {
            try
            {
                var result = await _subjectService.RemoveSubjectAsync(subjectId);
                return Ok(result);
            }
            catch (Exception exception)
            {
                // Log the exception (not shown here for brevity)
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
