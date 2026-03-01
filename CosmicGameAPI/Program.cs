using CosmicGameAPI.Entities;
using CosmicGameAPI.Service.Helper;
using CosmicGameAPI.Service.Implementation;
using CosmicGameAPI.Service.Interface;
using CosmicGameAPI.Utility;
using CosmicGameAPI.Utility.Constant;
using CosmicGameAPI.Utility.JWT;
using CosmicGameAPI.Utility.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Register the services
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<JWTAuthentication>();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<ICommonService, CommonService>();
builder.Services.AddTransient<IChartHolderService, ChartHolderService>();
builder.Services.AddTransient<IChartsService, ChartsService>();
builder.Services.AddTransient<IBhavaPlanetService, BhavaPlanetService>();
builder.Services.AddSingleton(typeof(IBaseAutoMapper<,>), typeof(BaseAutoMapper<,>));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(GlobalVars.JwtKey)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["AuthToken:Issuer"],
        ValidAudience = builder.Configuration["AuthToken:Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// CORS: allow Blazor WASM dev server + any configured production origin
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", policy =>
{
    policy
        .WithOrigins(
            "https://localhost:7001",
            "http://localhost:5001",
            "https://localhost:7002",
            "http://localhost:5002"
        )
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
}));

builder.Services.AddEndpointsApiExplorer();

// Swashbuckle Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Cosmic Birthchart API",
        Version = "v1",
        Description = "Astrological birth chart generation using the Swiss Ephemeris SDK"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT token. Example: Bearer {token}"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddDbContext<CosmicDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Cosmic Birthchart API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
