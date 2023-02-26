using AutoMapper;
using Library.BAL.Services;
using LibraryManagement.DAL;
using LibraryManagement.DAL.DBContext;
using LibraryManagement.DAL.Models;
using LibraryManagement.DAL.Models.DTOs;
using LibraryManagement.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder .Services.AddDbContext<ApplicationDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration["connectionStrings:LibraryManagement"]);
});



builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddScoped<IGenericRepository<Publisher>, GenericRepository<Publisher>>();
builder.Services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
builder.Services.AddScoped<IGenericRepository<Book>, GenericRepository<Book>>();
builder.Services.AddScoped<IGenericRepository<Client>, GenericRepository<Client>>();
builder.Services.AddScoped<IGenericRepository<BorrowingOperation>, GenericRepository<BorrowingOperation>>();


builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IPublisherService,PublisherService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IBorrowingOperationService, BorrowingOperationService>();


var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfileConfiguration());
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);



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
