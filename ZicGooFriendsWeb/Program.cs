using DataAccessLibrary.DataAccess;
using ZicGooFriendsWeb.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ZicGooFriendsWeb.APIs;
using Microsoft.OpenApi.Models;
using BlazorStrap;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IUserDao, UserDao>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(
    //options => 
    //    {
    //        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
    //        { 
    //            Scheme = "Bearer",
    //            BearerFormat = "JWT",
    //            In = ParameterLocation.Header,
    //            Name = "Authentication",
    //            Description = "Bearer Authentication with JWT Token",
    //            Type = SecuritySchemeType.Http
    //        });
    //        options.AddSecurityRequirement(new OpenApiSecurityRequirement
    //        {
    //            { 
    //                new OpenApiSecurityScheme
    //                { 
    //                    Reference = new OpenApiReference
    //                    { 
    //                        Id="Bearer",
    //                        Type=ReferenceType.SecurityScheme
    //                    }
    //                },
    //                new List<string>()
    //            }
    //        });
    //    }
);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddAuthorization();


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZicGooFriends Open API v1"); });

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.ConfigureUserApi();
app.ConfigureAuthenticationApi();
//app.MapGet("/user",
//    (IUserDao userDao) => {
//        try
//        {
//            return Results.Ok(userDao.GetAllUsers());
//        }
//        catch (Exception ex)
//        {
//            return Results.Problem(ex.Message);
//        }
//    });

app.Run();
