using System.Reflection;
using ApiNike.Extensions;
using AspNetCoreRateLimit;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

/* Add AddAPlicationServices */
builder.Services.AddAplicationServices();

/* Add Cors */
builder.Services.ConfigureCors();

/* Add Config RAte Limiting */
builder.Services.ConfigureRatelimiting();

/* Add AutoMApper */
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());


/* Add connection to database */
builder.Services.AddDbContext<ApiNikeContext>(options =>
{
    string connectionStrings = builder.Configuration.GetConnectionString("MysqlConect");
    options.UseMySql(connectionStrings, ServerVersion.AutoDetect(connectionStrings));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<ApiNikeContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var _logger = loggerFactory.CreateLogger<Program>();
        _logger.LogError(ex, "Ocurrio un error durante la migracion !!");
    }
}


app.UseHttpsRedirection();

/* Use Cors */
app.UseCors("CorsPolicy");

/* Use RateLimiting */
app.UseIpRateLimiting();

// Add Authentication(JWT)
/* app.UseAuthentication(); */
app.MapControllers();


app.Run();



