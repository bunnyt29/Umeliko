namespace Umeliko.Application.Learning.Articles.Commands.Create;

using Common;
using Domain.Learning.Repositories;
using FluentValidation;

public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleCommandValidator(IArticleDomainRepository articleRepository)
        => this.Include(new ArticleCommandValidator<CreateArticleCommand>(articleRepository));
}
