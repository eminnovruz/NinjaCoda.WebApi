namespace FileServerRelational.WebApi.DataTransferObject.Requests;

public class AddAnswerToQuestion
{
    public string QuestionId { get; set; }
    public string Text { get; set; }
}
