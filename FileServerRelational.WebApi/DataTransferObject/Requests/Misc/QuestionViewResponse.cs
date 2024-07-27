namespace FileServerRelational.WebApi.DataTransferObject.Requests.Misc;

public class QuestionViewResponse
{
    public string Id { get; set; }
    public string SubjectId { get; set; }
    public string Title { get; set; }
    public List<string> AnswerIds { get; set; }
    public int CorrectAnswerCount { get; set; }
    public string QuestionDocsLink { get; set; }
    public string Source { get; set; }
}
