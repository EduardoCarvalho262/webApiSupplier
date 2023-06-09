using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Supplier.Domain.DTOs;
using Supplier.Domain.Models;
using Supplier.Domain.Profiles;
using Supplier.Infra.Context;
using Supplier.Infra.Interfaces;
using Supplier.Infra.Repository;
using Supplier.Service.Interfaces;
using Supplier.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ISupplierService, SupplierService>();
builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();
builder.Services.AddAutoMapper(typeof(SupplierProfile));

builder.Services.AddDbContext<SupplierContext>(options =>
               options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISupplierContext>(provider => provider.GetService<SupplierContext>());

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
