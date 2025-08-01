var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IServices, MyServices>();
var app = builder.Build();

//app.Use(async(context, next) => {
//    var myService = context.RequestServices.GetRequiredService<IServices>();
//    myService.LogCreation("First MiddleWare !");
//    await next.Invoke();
//});
// Configure the HTTP request pipeline.
// Optional: Customize logging
//builder.Logging.ClearProviders();
builder.Logging.AddConsole();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public interface IServices
{
    void LogCreation(string mes);
}

public class MyServices : IServices
{
    private readonly int Id;

    public MyServices()
    {
        Id = new Random().Next(1000000, 9999999);
    }

    public void LogCreation(string mes)
    {
        Console.WriteLine($"{mes} - Serviec ID: {Id}");
    }
}