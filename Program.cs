using AwesomeDevEvents.Mappers;
using AwesomeDevEvents.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DevEventsCs");

builder.Services.AddDbContext<DevEventsDbContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(DevEventProfile).Assembly);

//builder.Services.AddDbContext<DevEventsDbContext>(o => o.UseInMemoryDatabase("DevEventsDb"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    {
        Title = "AwesomeDevEvents",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "devPPC",
            Email = "devppc@gmail.com",
            Url = new Uri("https://devppc.com.br")
        }
    });

    var xmlFile = "AwesomeDevEvents.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
