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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionController"/> class.
        /// </summary>
        /// <param name="questionService">The question service.</param>
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        /// <summary>
        /// Retrieves all questions.
        /// </summary>
        /// <returns>An action result containing a list of all questions.</returns>
        [HttpGet("ViewAllQuestions")]
        public IActionResult GetAllQuestions()
        {
            try
            {
                var questions = _questionService.GetAllQuestions();
                return Ok(questions);
            }
            catch (Exception exception)
            {
                // Log the exception (not shown here for brevity)
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Retrieves questions related to a specific subject.
        /// </summary>
        /// <param name="subjectId">The ID of the subject.</param>
        /// <returns>An action result containing a list of related questions.</returns>
        [HttpGet("GetSubjectQuestions")]
        public IActionResult GetAllSubjectQuestionsAsync(string subjectId)
        {
            try
            {
                var questions = _questionService.GetAllSubjectRelatedQuestions(subjectId);
                return Ok(questions);
            }
            catch (Exception exception)
            {
                // Log the exception (not shown here for brevity)
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Adds a question to a subject.
        /// </summary>
        /// <param name="request">The request containing question details.</param>
        /// <returns>An action result indicating success or failure.</returns>
        [HttpPost("AddQuestionToSubject")]
        public async Task<IActionResult> AddQuestionToSubject(AddQuestionToSubjectRequest request)
        {
            try
            {
                var result = await _questionService.AddQuestionToSubject(request);
                return Ok(result);
            }
            catch (Exception exception)
            {
                // Log the exception (not shown here for brevity)
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Removes a question.
        /// </summary>
        /// <param name="questionId">The ID of the question to remove.</param>
        /// <returns>An action result indicating success or failure.</returns>
        [HttpDelete("RemoveQuestion")]
        public async Task<IActionResult> RemoveQuestion(string questionId)
        {
            try
            {
                var result = await _questionService.RemoveQuestion(questionId);
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
