namespace Umeliko.Application.Rating.Comments.Commands.Create;

public class CreateCommentOutputModel(int commentId)
{
    public int CommentId { get; } = commentId;
}
