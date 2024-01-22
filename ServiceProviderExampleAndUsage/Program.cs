using ServiceProviderExampleAndUsage.Abstraction;
using ServiceProviderExampleAndUsage.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
List<Car> cars = new List<Car>()
{
    new Car() { Id = new Guid(), Brand = "BMW", Value = 100, },
    new Car() { Id = new Guid(), Brand = "Audi", Value = 200, }
};
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<List<Car>>(cars);
builder.Services.AddSingleton<ICarService,CarService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.MapGet("/carget", () =>
    {
        

        //CarService carService = new CarService(cars);
        ICarService carService = (ICarService)app.Services.GetService(typeof(ICarService));
        
        var carId = carService?.GetValueByBrand("BMW");

        return carId;



    })
    .WithName("CarGet")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}