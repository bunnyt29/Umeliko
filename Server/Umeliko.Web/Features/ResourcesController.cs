namespace Umeliko.Web.Features;

using Application.Learning.Resources.Commands.Create;
using Application.Learning.Resources.Commands.Delete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class ResourcesController : ApiController
{
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CreateResourceOutputModel>> Create(
        CreateArticleResourceCommand command)
        => await this.Send(command);

    [HttpDelete]
    [Authorize]
    [Route(nameof(ToArticle) + PathSeparator + ArticleId + PathSeparator + Id)]
    public async Task<ActionResult> ToArticle(
        [FromRoute] DeleteArticleResourceCommand command)
        => await this.Send(command);

    [HttpDelete]
    [Authorize]
    [Route(nameof(ToLesson) + PathSeparator + LessonId + PathSeparator + Id)]
    public async Task<ActionResult> ToLesson(
        [FromRoute] DeleteLessonResourceCommand command)
        => await this.Send(command);

    [HttpDelete]
    [Authorize]
    [Route(nameof(ToCourse) + PathSeparator + CourseId + PathSeparator + Id)]
    public async Task<ActionResult> ToCourse(
        [FromRoute] DeleteCourseResourceCommand command)
        => await this.Send(command);
}
