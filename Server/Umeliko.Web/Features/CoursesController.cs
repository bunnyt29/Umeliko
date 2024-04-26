namespace Umeliko.Web.Features;

using Application.Learning.Courses.Commands.Create;
using Application.Learning.Courses.Queries.Details;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class CoursesController : ApiController
{
    [HttpGet]
    [Route(MaterialId)]
    public async Task<ActionResult<CourseDetailsOutputModel>> Details(
        [FromRoute] CourseDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CreateCourseOutputModel>> Create(
        CreateCourseCommand command)
        => await this.Send(command);
}
