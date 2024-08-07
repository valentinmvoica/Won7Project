using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using Won7Project.Data;
using Won7Project.MiddlewareFilters;
using Won7Project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ana = builder.Configuration["Test"];

builder.Services.AddDbContext<StudentsRegistryDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("StudentsDb"))
    );

builder.Services.AddTransient<SingletonService>();
builder.Services.AddScoped<StudentsService>();
builder.Services.AddScoped<AddressesService>();
builder.Services.AddScoped<SeedService>();

builder.Services.AddControllers(o => {
    o.Filters.Add<CustomExceptionFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o=>AddXmlDoc(o));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddXmlDoc(SwaggerGenOptions o)
{
    var file = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, file));
}
