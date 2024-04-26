namespace Umeliko.Web.Features;

using Application.Learning.Lessons.Commands.Create;
using Application.Learning.Lessons.Commands.Delete;
using Application.Learning.Lessons.Commands.Edit;
using Application.Learning.Lessons.Queries.Details;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class LessonsController : ApiController
{
    [HttpGet]
    [Route(MaterialId)]
    public async Task<ActionResult<LessonDetailsOutputModel>> Details(
        [FromRoute] LessonDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    [Authorize]
    [Route(nameof(Create))]
    public async Task<ActionResult<CreateLessonOutputModel>> Create(
        CreateLessonCommand command)
        => await this.Send(command);

    [HttpPost]
    [Authorize]
    [Route(nameof(CreateToCourse))]
    public async Task<ActionResult<CreateLessonOutputModel>> CreateToCourse(
        CreateLessonCommand command)
        => await this.Send(command);

    [HttpPut]
    [Authorize]
    public async Task<ActionResult> Edit(
        EditLessonCommand command)
        => await this.Send(command);

    [HttpDelete]
    [Authorize]
    public async Task<ActionResult> Delete(
        DeleteLessonCommand command)
        => await this.Send(command);
}
