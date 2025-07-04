using CrmApp.Application.Services.Interface;
using CrmApp.Application.UseCase;
using CrmApp.Data;
using CrmApp.Data.Context;
using CrmApp.Data.Repository;
using CrmApp.Domain.Repository;
using CrmApp.Infrastructure.Services;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddFluentValidation(config =>
    config.RegisterValidatorsFromAssemblyContaining<CrmApp.Application.Validation.CriarClienteValidator>());

builder.Services.AddDbContext<CrmDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<CriarClienteUseCase>();
builder.Services.AddScoped<IEmailService, SmtpEmailService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
