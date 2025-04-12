namespace backend.GraphQL.Comments
{
    public record EditCommentInput(
        string CommentId,
        string? Content);
}