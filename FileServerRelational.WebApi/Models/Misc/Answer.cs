using FileServerRelational.WebApi.Models.Common;

namespace FileServerRelational.WebApi.Models.Misc;

public class Answer : BaseEntity 
{
    public string Text { get; set; }
    public string QuestionId { get; set; }
}
