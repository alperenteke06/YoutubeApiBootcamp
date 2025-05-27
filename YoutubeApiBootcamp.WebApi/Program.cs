using FluentValidation;
using System.Reflection;
using YoutubeApiBootcamp.WebApi.Context;
using YoutubeApiBootcamp.WebApi.Entities;
using YoutubeApiBootcamp.WebApi.ValidationRules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/* Context */
builder.Services.AddDbContext<ApiContext>();
/* AutoMapper */
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
/* FluentValidation */
builder.Services.AddScoped<IValidator<Product>, ProductValidator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
