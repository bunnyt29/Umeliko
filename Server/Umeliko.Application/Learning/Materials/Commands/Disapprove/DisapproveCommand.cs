namespace Umeliko.Application.Learning.Materials.Commands.Disapprove;

using Application.Common;
using Domain.Learning.Repositories;
using MediatR;
using SendGrid;
using SendGrid.Helpers.Mail;
using Umeliko.Application.Learning.Creators;

public class DisapproveCommand : EntityCommand<string>, IRequest<Result>
{
    public string? StateReason { get; set; } = default!;

    public class DisapproveCommandHandler(
            IMaterialDomainRepository materialDomainRepository,
            IMaterialQueryRepository materialQueryRepository,
            ICreatorQueryRepository creatorQueryRepository)
        : IRequestHandler<DisapproveCommand, Result>
    {
        public async Task<Result> Handle(
            DisapproveCommand request,
            CancellationToken cancellationToken)
        {
            var material = await materialDomainRepository
                .Find(request.Id, cancellationToken);

            if (material == null)
            {
                return "The material is not found!";
            }

            material.ChangeState("Disapproved");
            material.StateReason = request.StateReason;

            var materialDetails = await materialQueryRepository
                .GetDetails(request.Id, cancellationToken);

            var client = new SendGridClient(Environment.GetEnvironmentVariable("SENDGRID_API_KEY"));
            var from = new EmailAddress("umeliko.team@gmail.com", "Екипът на Умелико");
            var creator = creatorQueryRepository.GetDetailsByMaterialId(materialDetails.Id, cancellationToken);
            var email = await creatorQueryRepository.GetEmail(creator.Result.Id, cancellationToken);
            var userName = await creatorQueryRepository.GetUserName(creator.Result.Id, cancellationToken);
            var to = new EmailAddress(email, userName);
            var subject = "Неодобрен материал";
            var htmlContent = $@"
                <html>
                <body>
                    <p>Привет, {userName}!</p>
                    <p>За съжаление, твоят материал под заглавие <i>{materialDetails.Banner.Title}</i>, <b>не е одобрен</b>. Той остава видим единствено за теб.</p>
                    <p>Прични за отказ на публикация са:</p>
                    <p>{request.StateReason}</p>
                    <p>Твоите усилия далеч не са били напразно, не се оберазкожавай. Помисли върху решаване на засегнатите поблеми и опитай отново. Очакваме те!</p>
                    <p>Успех, <br/> Екипът на Умелико</p>
                </body>
                </html>";

            var message = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);

            await client.SendEmailAsync(message, cancellationToken);

            await materialDomainRepository.Update(material, cancellationToken);

            return Result.Success;
        }
    }
}
