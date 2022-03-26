using Microsoft.EntityFrameworkCore;
using EntityFrameworkExample;
using EntityFrameworkExample.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Server.IISIntegration;
using System.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = "Server=localhost,1436;Database=EntityFrameworkExample;ConnectRetryCount=0;User ID=sa;Password=1Secure*Password1";

builder.Services
    .AddDbContext<EntityFrameworkExampleContext>(opt =>
        opt.UseSqlServer(connectionString));

builder.Services.AddScoped<IUserSession, UserSession>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = IISDefaults.AuthenticationScheme;
})
.AddCookie(
    cookieOptions =>
    {
        cookieOptions.Cookie.Name = $"EntityFrameworkExample.{Configuration["ASPNETCORE_ENVIRONMENT"]}";
        cookieOptions.Cookie.SecurePolicy = Configuration["ASPNETCORE_ENVIRONMENT"] == "Development"
            ? CookieSecurePolicy.SameAsRequest
            : CookieSecurePolicy.Always;
        cookieOptions.Cookie.HttpOnly = true;
    });


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseDeveloperExceptionPage();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
