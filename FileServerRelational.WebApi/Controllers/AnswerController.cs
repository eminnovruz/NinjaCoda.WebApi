using FileServerRelational.WebApi.DataTransferObject.Requests;
using FileServerRelational.WebApi.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace FileServerRelational.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnswerController"/> class.
        /// </summary>
        /// <param name="answerService">The answer service.</param>
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        /// <summary>
        /// Retrieves all answers.
        /// </summary>
        /// <returns>An action result containing a list of all answers.</returns>
        [HttpGet("ViewAllAnswers")]
        public IActionResult ViewAllAnswers()
        {
            try
            {
                var answers = _answerService.GetAllAnswers();
                return Ok(answers);
            }
            catch (Exception exception)
            {
                // Log the exception (not shown here for brevity)
                Log.Error("exception log answer controller: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Retrieves answers related to a specific question.
        /// </summary>
        /// <param name="questionId">The ID of the question.</param>
        /// <returns>An action result containing a list of related answers.</returns>
        [HttpGet("GetQuestionAnswers")]
        public IActionResult GetQuestionAnswers(string questionId)
        {
            try
            {
                var answers = _answerService.GetQuestionRelatedAnswers(questionId);
                return Ok(answers);
            }
            catch (Exception exception)
            {
                // Log the exception (not shown here for brevity)
                Log.Error("exception log answer controller: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Adds an answer to a question.
        /// </summary>
        /// <param name="request">The request containing answer details.</param>
        /// <returns>An action result indicating success or failure.</returns>
        [HttpPost("AddAnswerToQuestion")]
        public async Task<IActionResult> AddAnswerToQuestion(AddAnswerToQuestionRequest request)
        {
            try
            {
                var result = await _answerService.AddAnswerToQuestion(request);
                return Ok(result);
            }
            catch (Exception exception)
            {
                // Log the exception (not shown here for brevity)

                Log.Error("exception log answer controller: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Removes an answer.
        /// </summary>
        /// <param name="answerId">The ID of the answer to remove.</param>
        /// <returns>An action result indicating success or failure.</returns>
        [HttpDelete("RemoveAnswer")]
        public async Task<IActionResult> RemoveAnswer(string answerId)
        {
            try
            {
                var result = await _answerService.RemoveAnswer(answerId);
                return Ok(result);
            }
            catch (Exception exception)
            {
                // Log the exception (not shown here for brevity)
                Log.Error("exception log answer controller: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
