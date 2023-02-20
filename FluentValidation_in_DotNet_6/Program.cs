using FluentValidation;
using FluentValidation_in_DotNet_6.Models;
using FluentValidation_in_DotNet_6.Validators;
using System;
using Microsoft.EntityFrameworkCore;
using FluentValidation_in_DotNet_6.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DbConnectionString");

builder.Services.AddDbContext<Database>(options =>
{
    options.UseSqlServer(connectionString);
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Manual Validation
builder.Services.AddScoped<IValidator<Customer>, CustomerValidation>();
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
