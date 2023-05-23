using Holiday.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<ISearchService, SearchService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//ISearchService searchService = null;
//using (var serviceScope = app.Services.CreateScope())
//{
//    var services = serviceScope.ServiceProvider;

//    searchService = services.GetRequiredService<ISearchService>();
//}

app.MapGet("/weatherforecast", (DateTime? start, DateTime? end) =>
{
    var searchSearch = new SearchService();
    var forecast =
        new
        {
            Time = DateOnly.FromDateTime(DateTime.Now)
        };
    return forecast;
})
.WithName("GetWeatherForecast")
.WithDisplayName("displayname")
.WithOpenApi();

app.Run();