namespace FileServerRelational.WebApi.DataTransferObject.Requests;

public class AddSubjectRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string GeneralAbout { get; set; }
    public string DocsLink { get; set; }
}
