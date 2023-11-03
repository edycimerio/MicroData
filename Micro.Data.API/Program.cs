using Micro.Data.Repository;

using Micro.Data.Domain;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using System;
using Micro.Data.Domain.Dtos;
using Micro.Data.API.Validadores;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRespositorys();

builder.Services.AddServices();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase("ConnMicroData"));

builder.Services.AddScoped<IValidator<ProdutoDto>, PostProdutoValidator>();
builder.Services.AddScoped<IValidator<PedidoDto>, PostPedidoValidator>();

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
