using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region

#endregion

#region

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CinemaDbContext>(options => options.UseNpgsql(connectionString));

#endregion

// builder.Services.AddExceptionHandler<ErrorHandlingMiddleware>();
builder.Services.AddProblemDetails();

// builder.Services.AddAutoMapper(typeof(GuestMapping));//TODO

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

app.UseExceptionHandler();

app.Run();
