/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: Program.cs                                        //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Interfaces;
using OffRoadPortal.Services;
using NLog.Web;
using OffRoadPortal.Middleware;
using Microsoft.AspNetCore.Identity;
using OffRoadPortal.Entities;
using FluentValidation;
using OffRoadPortal.Models;
using OffRoadPortal.Validators;
using FluentValidation.AspNetCore;
using OffRoadPortal.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OffRoadPortal.Database;
using OffRoadPortal.OtherServices;
using OffRoadPortal.Authorization;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
var authenticationSettings = new AuthenticationSettings();

// Add services to the container.
builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
    };
});

//NLog: Setup
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

//Cors policy
builder.Services.AddControllers().AddFluentValidation();
//builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("HasCar", build => build.RequireClaim("Car"));
    options.AddPolicy("Adult", build => build.AddRequirements(new MinimumAgeRequirement(18)));
});
builder.Services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
builder.Services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandler>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OffRoadPortalDbContext>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<RoleSeeder>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IArticleCommentService, ArticleCommentService>();
builder.Services.AddScoped<IEventCommentService, EventCommentService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
builder.Services.AddScoped<IUserContextService, UserContextService>();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<RoleSeeder>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseResponseCaching();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(@"http://localhost:4200"));

seeder.Seed();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();