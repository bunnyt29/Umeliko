namespace Umeliko.Application.Rating.Votes.Commands.Common;

using Application.Common;
using Domain.Common.Models;
using Domain.Rating.Models.Votes;
using Domain.Rating.Repositories;
using FluentValidation;

public class VoteCommandValidator<TCommand> : AbstractValidator<VoteCommand<TCommand>>
    where TCommand : EntityCommand<string>
{
    public VoteCommandValidator(IVoteDomainRepository voteRepository)
    {
        this.RuleFor(v => v.VoteType)
            .Must(Enumeration.HasValue<VoteType>)
            .WithMessage("'Vote Type' is not valid.");
    }
}
