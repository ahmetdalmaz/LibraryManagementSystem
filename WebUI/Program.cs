using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddFluentValidation(config =>
{
    config.RegisterValidatorsFromAssemblyContaining<AuthorValidator>();
    config.DisableDataAnnotationsValidation = true;
});

builder.Services.AddAutoMapper(assembly);

builder.Services.AddSingleton<ICategoryDal, EfCategoryDal>();
builder.Services.AddSingleton<ICategoryService, CategoryManager>();

builder.Services.AddSingleton<IAuthorDal, EfAuthorDal>();
builder.Services.AddSingleton<IAuthorService, AuthorManager>();

builder.Services.AddSingleton<IBookDal, EfBookDal>();
builder.Services.AddSingleton<IBookService, BookManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
