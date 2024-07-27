using FileServerRelational.WebApi.Models.Common;
using FileServerRelational.WebApi.Models.Misc;

namespace FileServerRelational.WebApi.Models.Sbj;

public class Subject : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string GeneralAbout { get; set; }
    public string SalaryId { get; set; }
    public string DocsLink { get; set; }
    public List<string> QuestionIds { get; set; }
}
