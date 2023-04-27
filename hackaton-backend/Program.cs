using hackatonBackend.Configuration.Extensions;
using hackatonBackend.WebApi.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config

builder.Services.AddSetup(configuration);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "hackatonBackend", Version = "v1" });
});

var app = builder.Build();

IWebHostEnvironment environment = builder.Environment;

if (environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HackBackend v1"));

app.UseExceptionHandler(ExceptionHandling.Options);

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

