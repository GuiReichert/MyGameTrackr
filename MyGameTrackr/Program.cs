using Microsoft.EntityFrameworkCore;
using MyGameTrackr.Database;
using MyGameTrackr.Services;

var builder = WebApplication.CreateBuilder(args);


DotNetEnv.Env.Load();                                                               // loads the ".env" package





builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();






builder.Services.AddDbContext<MyGameTrackr_Context>(x=> x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpClient();                                                   // adds the client factory
builder.Services.AddHttpClient("GetGameDetails", x =>
{
    x.BaseAddress = new Uri("https://api.rawg.io/api/games/");
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ISearchGames,SearchGames>();










var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
