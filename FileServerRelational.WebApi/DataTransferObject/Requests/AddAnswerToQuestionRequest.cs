namespace FileServerRelational.WebApi.DataTransferObject.Requests;

public class AddAnswerToQuestionRequest
{
    public string QuestionId { get; set; }
    public string Text { get; set; }
}
