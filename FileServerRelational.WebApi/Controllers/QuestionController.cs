﻿using FileServerRelational.WebApi.DataTransferObject.Requests;
using FileServerRelational.WebApi.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileServerRelational.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }


        [HttpGet("ViewAllQuestions")]
        public IActionResult GetAllQuestions()
        {
            try
            {
                return Ok(_questionService.GetAllQuestions());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [HttpGet("GetSubjectQuestions")]
        public IActionResult GetAllSubjectQuestionsAsync(string subjectId)
        {
            try
            {
                return Ok(_questionService.GetAllSubjectRelatedQuestions(subjectId));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [HttpPost("AddQuestionToSubject")]
        public async Task<IActionResult> AddQuestionToSubject(AddQuestionToSubjectRequest request)
        {
            try
            {
                return Ok(await _questionService.AddQuestionToSubject(request));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [HttpDelete("RemoveQuestion")]
        public async Task<IActionResult> RemoveQuestion(string questionId)
        {
            try
            {
                return Ok(await _questionService.RemoveQuestion(questionId));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
