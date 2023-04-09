using DataLayer;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IArticleRepository, ArticleRepository>();
builder.Services.AddTransient<IUnitOfWorkRepository, UnitOfWork>();
builder.Services.AddTransient<IUnitofWorkService, UnitofWorkService>();
builder.Services.AddScoped<RevisionDbContext>();
builder.Services.AddScoped<FactoryDbContext>();
builder.Services.AddDbContextFactory<RevisionDbContext,FactoryDbContext>();
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
