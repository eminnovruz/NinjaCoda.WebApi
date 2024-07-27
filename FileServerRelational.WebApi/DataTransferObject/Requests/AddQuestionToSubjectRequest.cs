namespace FileServerRelational.WebApi.DataTransferObject.Requests;

public class AddQuestionToSubjectRequest
{
    public string SubjectName { get; set; }
    public string Title { get; set; }
    public string QuestionDocsLink { get; set; }
    public string Source { get; set; }
}
