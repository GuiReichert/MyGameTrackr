using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyGameTrackr.Database;
using MyGameTrackr.Models.User;
using MyGameTrackr.Services;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);


DotNetEnv.Env.Load();                                                               // loads the ".env" package





builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = """Standard Authorization header using the Bearer scheme. Example: "bearer {token}" """,
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    x.OperationFilter<SecurityRequirementsOperationFilter>();
});






builder.Services.AddDbContext<MyGameTrackr_Context>(x=> x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpClient();                                                   // adds the client factory
builder.Services.AddHttpClient("GetGameDetails", x =>
{
    x.BaseAddress = new Uri("https://api.rawg.io/api/games/");
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ISearchGames,SearchGames>();
builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddScoped<ILibraryServices,LibraryServices>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer( x=> {
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("Token")!)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});










var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}







app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
