using HRManagement.Api;
using HRManagement.Application;
using HRManagement.Infrastructure;
using HRManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddCors(opts =>
{
    opts.AddPolicy("all", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
