using Holiday.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (System.OperatingSystem.IsWindows())
{
    builder.Host.UseWindowsService();
}

if (System.OperatingSystem.IsLinux())
{
    builder.Host.UseSystemd();
}

//builder.Services.AddSingleton<ISearchService, SearchService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/getHoliday", (DateTime start, DateTime end) =>
{
    var searchSearch = new SearchService();
    var result = searchSearch.IsHoliday(start, end);
    return result;
})
.WithOpenApi();



app.Run();