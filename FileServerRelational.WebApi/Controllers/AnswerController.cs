using FileServerRelational.WebApi.DataTransferObject.Requests;
using FileServerRelational.WebApi.Services;
using FileServerRelational.WebApi.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileServerRelational.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet("ViewAllAnswers")]
        public IActionResult ViewAllAnswers()
        {
            try
            {
                return Ok(_answerService.GetAllAnswers());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [HttpGet("GetQuestionAnswers")]
        public IActionResult GetQuestionAnswers(string questionId)
        {
            try
            {
                return Ok(_answerService.GetQuestionRelatedAnswers(questionId));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [HttpPost("AddAnswerToQuestion")]
        public async Task<IActionResult> AddAnswerToQuestion(AddAnswerToQuestionRequest request)
        {
            try
            {
                return Ok(await _answerService.AddAnswerToQuestion(request));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [HttpDelete("RemoveAnswer")]
        public async Task<IActionResult> RemoveAnswer(string answerId)
        {
            try
            {
                return Ok(await _answerService.RemoveAnswer(answerId));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
