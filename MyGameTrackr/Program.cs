using MyGameTrackr.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHttpClient();                                                   // adds the client factory
builder.Services.AddHttpClient("GetGameDetails", x =>
{
    x.BaseAddress = new Uri("https://api.rawg.io/api/games/");
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ISearchGames,SearchGames>();



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
