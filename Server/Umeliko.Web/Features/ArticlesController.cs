namespace Umeliko.Web.Features;

using Application.Learning.Articles.Commands.Create;
using Application.Learning.Articles.Commands.Delete;
using Application.Learning.Articles.Commands.Edit;
using Application.Learning.Articles.Queries.Details;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class ArticlesController : ApiController
{
    [HttpGet]
    [Route(MaterialId)]
    public async Task<ActionResult<ArticleDetailsOutputModel>> Details(
        [FromRoute] ArticleDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CreateArticleOutputModel>> Create(
        CreateArticleCommand command)
        => await this.Send(command);

    [HttpPut]
    [Authorize]
    public async Task<ActionResult> Edit(
        EditArticleCommand command)
        => await this.Send(command);

    [HttpDelete]
    [Authorize]
    public async Task<ActionResult> Delete(
        DeleteArticleCommand command)
        => await this.Send(command);
}
