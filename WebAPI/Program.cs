
// The Service Builder for all dependencies
// Relacement for ConfigureServices() of Startup.cs
// CReating the Hosting env. for COnfiguring all Servces
// DbCOntext, Session, Cache, CORS, Custom Services
// Caching, Security, COntroller Request Processing (Filters), etc.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
//1. Register the DBContext in DI Container as as servive
builder.Services.AddDbContext<ApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnStr"));
});

builder.Services.AddDistributedRedisCache(options => {
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddDbContext<CodAuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnStr"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<CodAuthDbContext>();

//2. Regiser Custom services
builder.Services.AddScoped<IService<Category, int>, CategoryService>();
builder.Services.AddScoped<IService<Product, int>, ProductService>();

// Logic for Token Verification
byte[] secretKey = Convert.FromBase64String(builder.Configuration["JWTSettings:SecretKey"]);


builder.Services.AddAuthentication(x =>
{
    // set the Scheme for HEader Value Verification
    // HTTP Request Header MUST use the Authorzation:'Bearer <TOKEN-VALUE>'
    // in Request
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Validate the Token
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true, // Signeture Verification
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



// Register the AUthService
builder.Services.AddScoped<AuthService>();

// Controll for API
// Controll for API
// 3. Now Modify the AddController() service to
// Ignore the default JSON Serialization  for
// Names of Model Class Properties
builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            // SUpress the defualut Camel Casing for Property NAmes
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        })
        .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );

builder.Services.AddCors(options => {
    options.AddPolicy("corspolicy", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

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

// Add the CORS Middleware
app.UseCors("corspolicy");
app.UseAuthentication();
app.UseHttpsRedirection();


app.UseAuthorization();

//Custom Middleware of Exceptions
app.UseRequestException();

app.UseLogRequest();

// USe ROuting internally to map with the API COntroller and Call it  
// THis uses the EndPoint as a Service using AddEndpointsApiExplorer() used in Service Collection
app.MapControllers();

// Run the APplication for HTTP Request Processing
app.Run();
