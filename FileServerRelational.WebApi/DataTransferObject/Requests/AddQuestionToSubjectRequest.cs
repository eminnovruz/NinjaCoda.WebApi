namespace FileServerRelational.WebApi.DataTransferObject.Requests;

public class AddQuestionToSubjectRequest
{
    public string SubjectId { get; set; }
    public string Title { get; set; }
    public string QuestionLevel { get; set; }
    public string QuestionDocsLink { get; set; }
    public string Source { get; set; }
}
