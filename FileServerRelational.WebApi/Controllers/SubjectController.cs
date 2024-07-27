using FileServerRelational.WebApi.DataTransferObject.Requests;
using FileServerRelational.WebApi.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileServerRelational.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost("AddNewSubject")]
        public async Task<IActionResult> AddNewSubjectAsync(AddSubjectRequest request)
        {
            try
            {
                return Ok(await _subjectService.AddSubjectAsync(request));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [HttpGet("GetAllSubjects")]
        public IActionResult GetAllSubjects()
        {
            try
            {
                return Ok(_subjectService.GetAllSubjects());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [HttpDelete("RemoveSubjectById")]
        public async Task<IActionResult> RemoveSubjectByIdAsync(string subjectId)
        {
            try
            {
                return Ok(await _subjectService.RemoveSubjectAsync(subjectId));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
