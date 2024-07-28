using FileServerRelational.WebApi.Models.Common;

namespace FileServerRelational.WebApi.Models.Misc;

public class Question : BaseEntity
{
    public string SubjectId { get; set; }
    public string Title { get; set; }
    public List<string> AnswerIds { get; set; }
    public string QuestionLevel { get; set; }
    public int CorrectAnswerCount { get; set; }
    public string QuestionDocsLink { get; set; }
    public string Source { get; set; }
}
