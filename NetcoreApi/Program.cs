using Netcore.Application;
using Netcore.Domain;
using Netcore.Infrastructure.Data;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    var services = builder.Services; 
    var env = builder.Environment;
 
    services.AddCors();
    services.AddControllers().AddJsonOptions(x =>
    {
        // serialize enums as strings in api responses (e.g. Role)
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

        // ignore omitted parameters on models to enable optional params (e.g. User update)
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
  
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // configure strongly typed settings object
    services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

    // configure DI for application services
    services.AddSingleton<DataContext>();

  services.AddScoped<IFacultadRepository, FacultadRepository>();
  services.AddScoped<IFacultadService, FacultadService>();

  services.AddScoped<ICarreraRepository, CarreraRepository>();
  services.AddScoped<ICarreraService, CarreraService>();


}

var app = builder.Build();

// ensure database and tables exist
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    //await context.Init();
}

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.MapControllers();

  app.UseSwagger();
  app.UseSwaggerUI();
}

app.Run("https://localhost:4000");