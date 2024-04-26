namespace Umeliko.Web;

using Application.Common;
using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

[ApiController]
[Route("[controller]")]
public abstract class ApiController : ControllerBase
{
    public const string PathSeparator = "/";
    public const string Id = "{id}";
    public const string MaterialId = "{materialId}";
    public const string ArticleId = "{articleId}";
    public const string LessonId = "{lessonId}";
    public const string CourseId = "{courseId}";
    public const string CreatorId = "{creatorId}";

    public const string Administrator = "Administrator";

    private IMediator? mediator;

    protected IMediator Mediator
        => this.mediator ??= this.HttpContext
            .RequestServices
            .GetService<IMediator>();

    protected Task<ActionResult<TResult>> Send<TResult>(IRequest<TResult> request)
        => this.Mediator.Send(request).ToActionResult();

    protected Task<ActionResult> Send(IRequest<Result> request)
        => this.Mediator.Send(request).ToActionResult();

    protected Task<ActionResult<TResult>> Send<TResult>(IRequest<Result<TResult>> request)
        => this.Mediator.Send(request).ToActionResult();
}
