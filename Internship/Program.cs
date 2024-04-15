using APIsRepo;
using APIsservices;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Configure CORS
var provider = builder.Services.BuildServiceProvider();
var configuration1 = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options => {
    var frontendURL = configuration1.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
    });
});




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServices1, Services>();
builder.Services.AddScoped<IRepo1, Repo>();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)//appsettings
    .AddEnvironmentVariables()
    .Build();

string connectionString = configuration.GetConnectionString("SqlConnection");//connectionstring


builder.Services.AddScoped<IDbConnection>(provider =>
{
    var connection = new SqlConnection(connectionString);
    return connection;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS middleware
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseEndpoints(endpoints =>
//{
  //  endpoints.MapControllers();
//});

app.Run();
