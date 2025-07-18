using ThePlannerAPI.Hubs;
using ThePlannerAPI.Services;
using Microsoft.EntityFrameworkCore;
using ThePlannerAPI.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors();

builder.Services.AddScoped<IPlannerService, PlannerEventService>();

builder.Services.AddDbContext<PlannerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Setting up the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => 
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

// Maps the SignalR hub route
app.MapHub<EventHub>("/eventHub");

app.Run();
