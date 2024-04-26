namespace Umeliko.Application.Rating.Votes.Commands.Create;

using Common;
using Domain.Rating.Repositories;
using FluentValidation;

public class CreateVoteCommandValidator : AbstractValidator<CreateVoteCommand>
{
    public CreateVoteCommandValidator(IVoteDomainRepository voteRepository)
        => this.Include(new VoteCommandValidator<CreateVoteCommand>(voteRepository));
}
