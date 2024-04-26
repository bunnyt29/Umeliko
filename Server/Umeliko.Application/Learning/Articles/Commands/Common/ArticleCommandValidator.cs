namespace Umeliko.Application.Learning.Articles.Commands.Common;

using Application.Common;
using Domain.Learning.Repositories;
using FluentValidation;

public class ArticleCommandValidator<TCommand> : AbstractValidator<ArticleCommand<TCommand>>
    where TCommand : EntityCommand<string>
{
    public ArticleCommandValidator(IArticleDomainRepository articleRepository)
    {

    }
}
