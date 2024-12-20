using Application.Movies;
using Application.Movies.Ports;
using Application.Rooms;
using Application.Rooms.Ports;
using Application.Sessions;
using Application.Sessions.Ports;
using Application.TicketPrices;
using Application.TicketPrices.Ports;
using Application.Tickets;
using Application.Tickets.Ports;
using Application.Users;
using Application.Users.Ports;
using Data;
using Domain.Movies.Ports;
using Domain.Rooms.Ports;
using Domain.Sessions.Ports;
using Domain.TicketPrices.Ports;
using Domain.Tickets.Ports;
using Domain.Users.Ports;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region

builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IMovieManager, MovieManager>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

builder.Services.AddScoped<IRoomManager, RoomManager>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

builder.Services.AddScoped<ISessionManager, SessionManager>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();

builder.Services.AddScoped<ITicketManager, TicketManager>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

builder.Services.AddScoped<ITicketPriceManager, TicketPriceManager>();
builder.Services.AddScoped<ITicketPriceRepository, TicketPriceRepository>();

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
