namespace Umeliko.Application.Learning.Materials.Commands.Approve;

using Application.Common;
using Creators;
using Domain.Learning.Repositories;
using MediatR;
using SendGrid;
using SendGrid.Helpers.Mail;

public class ApproveCommand : EntityCommand<string>, IRequest<Result>
{
    public class ApproveCommandHandler(
            IMaterialDomainRepository materialDomainRepository,
            IMaterialQueryRepository materialQueryRepository,
            ICreatorQueryRepository creatorQueryRepository)
        : IRequestHandler<ApproveCommand, Result>
    {
        public async Task<Result> Handle(
            ApproveCommand request,
            CancellationToken cancellationToken)
        {
            var material = await materialDomainRepository
                .Find(request.Id, cancellationToken);

            if (material == null)
            {
                return "The material is not found!";
            }

            material.ChangeState("Approved");

            var materialDetails = await materialQueryRepository
                .GetDetails(request.Id, cancellationToken);

            var client = new SendGridClient(Environment.GetEnvironmentVariable("SENDGRID_API_KEY"));
            var from = new EmailAddress("umeliko.team@gmail.com", "Екипът на Умелико");
            var creator = creatorQueryRepository.GetDetailsByMaterialId(materialDetails.Id, cancellationToken);
            var email = await creatorQueryRepository.GetEmail(creator.Result.Id, cancellationToken);
            var userName = await creatorQueryRepository.GetUserName(creator.Result.Id, cancellationToken);
            var to = new EmailAddress(email, userName);
            var subject = "Одобрен материал";
            var htmlContent = $@"
                <html>
                <body style='font-family: Oswald, sans-serif;'>
                    <p>Привет, {userName}!</p>
                    <p>Добри новини - твоят материал под заглавие <b>{materialDetails.Banner.Title}</b> е <b>одобрен</b>. Това го прави достъпен за всички!</p>
                    <p>Твоите усилия са ключът към развитието на нашата общност. Вярваме в теб и в твоя потенциала да вдъхновяваш и обогатяваш. С нетърпение очакваме още от теб! И помни, в Умелико винаги има място за твоите идеи!</p>
                    <p>С пожелание за вдъхновение, <br/> Екипът на Умелико</p>
                </body>
                </html>";

            var message = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);

            await client.SendEmailAsync(message, cancellationToken);

            await materialDomainRepository.Update(material, cancellationToken);

            return Result.Success;
        }
    }
}
