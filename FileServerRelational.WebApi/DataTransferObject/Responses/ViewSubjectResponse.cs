namespace FileServerRelational.WebApi.DataTransferObject.Responses;

public class ViewSubjectResponse
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string GeneralAbout { get; set; }
    public string SalaryId { get; set; }
    public string DocsLink { get; set; }
    public List<string> QuestionIds { get; set; }
}
