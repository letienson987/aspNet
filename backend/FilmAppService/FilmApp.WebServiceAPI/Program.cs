using System.Text;
using Microsoft.EntityFrameworkCore;
using FilmApp.WebServiceCore.Database;
using FilmApp.WebServiceCore.Mappers;
using FilmApp.WebServiceCore.Repositories;
using FilmApp.WebServiceCore.Services;
using FilmApp.WebServiceCore.UnitOfWork;
using FilmApp.WebServiceCore.Validation;
using FilmAppp.WebServiceCore.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoryMapper, CategoryMapper>();
builder.Services.AddTransient<IApplicationUnitOfWork, ApplicationUnitOfWork>();
builder.Services.AddTransient<IServiceValidation, ServiceValidation>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

builder.Services.AddTransient<IFilmsService, FilmsService>();
builder.Services.AddTransient<IFilmsMapper, FilmsMapper>();
builder.Services.AddTransient<IFilmsRepository, FilmsRepository>();

builder.Services.AddTransient<ICommentsService, CommentsService>();
builder.Services.AddTransient<ICommentsMapper, CommentsMapper>();
builder.Services.AddTransient<ICommentsRepository, CommentsRepository>();

builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IUsersMapper, UsersMapper>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();

builder.Services.AddTransient<IRatingsService, RatingsService>();
builder.Services.AddTransient<IRatingsMapper, RatingsMapper>();
builder.Services.AddTransient<IRatingsRepository, RatingsRepository>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)    
    .AddJwtBearer(options =>    
    {    
        options.TokenValidationParameters = new TokenValidationParameters    
        {    
            ValidateIssuer = true,    
            ValidateAudience = true,    
            ValidateLifetime = true,    
            ValidateIssuerSigningKey = true,    
            ValidIssuer = builder.Configuration["Jwt:Issuer"],    
            ValidAudience = builder.Configuration["Jwt:Issuer"],    
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))    
        };    
    });
