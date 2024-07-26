﻿namespace FileServerRelational.WebApi.Models.Misc;

public class Question
{
    public string Title { get; set; }
    public List<string> AnswerIds { get; set; }
    public int CorrectAnswerCount { get; set; }
    public string QuestionDocsLink { get; set; }
    public string Source { get; set; }
}