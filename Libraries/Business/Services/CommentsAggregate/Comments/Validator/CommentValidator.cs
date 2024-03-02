using Entities.Concrete.CommentsAggregate;
using FluentValidation;
namespace Business.Services.CommentsAggregate.Comments.Validator
{
    public class CreateCommentValidator : AbstractValidator<Comment>
    {
        public CreateCommentValidator()
        {
            RuleFor(x => x.CommentTitle).NotEmpty();
            RuleFor(x => x.CommentText).NotEmpty();
            RuleFor(x => x.Productid).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.IsApproved).NotEmpty();
            RuleFor(x => x.CreatedOnUtc).NotEmpty();
            RuleFor(x => x.Rating).NotEmpty();
        }
    }
    public class UpdateCommentValidator : AbstractValidator<Comment>
    {
        public UpdateCommentValidator()
        {
            RuleFor(x => x.CommentTitle).NotEmpty();
            RuleFor(x => x.CommentText).NotEmpty();
            RuleFor(x => x.Productid).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.IsApproved).NotEmpty();
            RuleFor(x => x.CreatedOnUtc).NotEmpty();
            RuleFor(x => x.Rating).NotEmpty();
        }
    }
}