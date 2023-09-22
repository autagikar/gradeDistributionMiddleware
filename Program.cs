using gradeDistributionMiddleware;
using PetaPoco;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Build the configuration from appsettings.json
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

// Create an isntance of PetaPoco DB Class and register it as a signleton service
builder.Services.AddSingleton<Database>(provider =>
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new Database(connectionString, "System.Data.SqlClient");
});
builder.Services.AddSingleton<petaPocoDBClass>(provider =>
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new petaPocoDBClass(connectionString);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowAll");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
