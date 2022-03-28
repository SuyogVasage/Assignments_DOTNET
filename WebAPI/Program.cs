// The Service Builder for all dependencies
// Relacement for ConfigureServices() of Startup.cs
// CReating the Hosting env. for COnfiguring all Servces
// DbCOntext, Session, Cache, CORS, Custom Services
// Caching, Security, COntroller Request Processing (Filters), etc.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Controll for API
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Generate a Mapping with API COntrolleers' URL for ROuting
builder.Services.AddEndpointsApiExplorer();

// Generate a API Metadata Documentation for API
builder.Services.AddSwaggerGen();

// Build the Http Pipeline for Request Processing
// Replacement for COnfigure() method of Startup class in Startup.cs
// Confgure Middleware
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Middlwaere to Show Swagger UI in Browser
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// USe ROuting internally to map with the API COntroller and Call it  
// THis uses the EndPoint as a Service using AddEndpointsApiExplorer() used in Service Collection
app.MapControllers();

// Run the APplication for HTTP Request Processing
app.Run();
