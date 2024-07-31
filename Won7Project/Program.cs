using Microsoft.EntityFrameworkCore;
using Won7Project.Data;
using Won7Project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ana = builder.Configuration["Test"];

builder.Services.AddDbContext<StudentsRegistryDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("StudentsDb"))
    );

builder.Services.AddSingleton<SingletonService>();
builder.Services.AddScoped<StudentsService>();
builder.Services.AddScoped<AddressesService>();
builder.Services.AddScoped<SeedService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
