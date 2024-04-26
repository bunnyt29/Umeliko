using Umeliko.Application;
using Umeliko.Domain;
using Umeliko.Infrastructure;
using Umeliko.Startup;
using Umeliko.Web;
using Umeliko.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddDomain()
	.AddApplication(builder.Configuration)
	.AddInfrastructure(builder.Configuration)
	.AddWebComponents()
	.AddSwagger();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
else
{
	app.UseInnerExceptionHandler();
	app.UseHsts();
}

app
	.UseValidationExceptionHandler()
	.UseHttpsRedirection()
	.UseRouting()
	.UseCors(options => options
		.AllowAnyOrigin()
		.AllowAnyHeader()
		.AllowAnyMethod())
	.UseSwagger()
	.UseSwaggerUI()
	.UseAuthentication()
	.UseAuthorization()
	.UseEndpoints(endpoints => endpoints
		.MapControllers())
	.Initialize();

app.Run();